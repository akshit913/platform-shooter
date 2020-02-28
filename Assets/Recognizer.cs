using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recognizer : MonoBehaviour
{
    public Vector3 hiddenPosition;
    public GameObject player;
    public GameObject tap;
    public Rigidbody playerRigidBody;
    public Texture tapDownTexture;
    public Texture movementHalf;
    public Texture shootingHalf;
    private Vector3 tapDownPoint;
    private Vector3 tapDragPoint;
    public float movementSense;
    public float jumpSense;
    public GameObject bullet;

    void Awake()
    {
        tapDragPoint = hiddenPosition;
    }

    void OnGUI () 
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height / 2), shootingHalf);

        if(tapDownPoint != hiddenPosition) 
        {
            GUI.Box(new Rect(tapDownPoint.x - 10, Screen.height - tapDownPoint.y - 10, 20, 20), tapDownTexture);
        }
    }

    void Update()
    {
        /* Initial tap */
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 temp = Input.mousePosition;

            /* Lower half = movement gesture */
            if(temp.y < Screen.height / 2)
            {
                tapDownPoint = temp;
            }

            /* Upper half = shooting gesture */
            else
            {
                if( Mathf.Abs(temp.x - Screen.width / 2) > 20 && Mathf.Abs(temp.y - Screen.height / 2) > 20)
                {
                    Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 1, 1), new Quaternion(0, 0, 0, 1));
                }

            }
        }

        /* Drag */
        else if (Input.GetMouseButton(0))
        {
            if(tapDownPoint != hiddenPosition)
            {
                tapDragPoint = Input.mousePosition;

                if(Mathf.Abs(tapDragPoint.x - tapDownPoint.x) > movementSense)
                {
                    if(tapDragPoint.x > tapDownPoint.x)
                        player.transform.position += new Vector3(0.06f,0,0);
                    else
                        player.transform.position -= new Vector3(0.06f,0,0);
                }
            }
        }

        /* No tap */
        else 
        {
            if(tapDownPoint != hiddenPosition)
            {
                if(tapDragPoint.y - tapDownPoint.y > jumpSense)
                {
                    if(tapDragPoint.x - tapDownPoint.x > jumpSense)
                        playerRigidBody.AddForce(Vector3.right * 100.0f);
                    if(tapDownPoint.x - tapDragPoint.x > jumpSense)
                        playerRigidBody.AddForce(Vector3.left * 100.0f);

                    playerRigidBody.AddForce(Vector3.up * 500.0f);
                }
                
                if(tapDownPoint.y - tapDragPoint.y > jumpSense)
                {
                    playerRigidBody.AddForce(Vector3.down * 500.0f);
                }

                tapDragPoint = hiddenPosition;
                tapDownPoint = hiddenPosition;
            }
        }
    }
}