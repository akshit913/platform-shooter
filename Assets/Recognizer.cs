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
    public GameObject leftBullet;
    public int touchAreaOffset = 17;
    private List<Point> gesturePoints;

    void Awake()
    {
        tapDragPoint = hiddenPosition;
        gesturePoints = new List<Point>();
    }

    void OnGUI () 
    {
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
            tapDownPoint = temp;
            gesturePoints.Add(new Point { x = temp.x, y = temp.y });
        }

        /* Drag */
        else if (Input.GetMouseButton(0))
        {

            if(tapDownPoint != hiddenPosition)
            {
                tapDragPoint = Input.mousePosition;
                gesturePoints.Add(new Point { x = tapDragPoint.x, y = tapDragPoint.y });

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
                /* Lower half = movement gesture */
                if(tapDownPoint.y < (Screen.height / 2) - touchAreaOffset)
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
                }
                /* Upper half = shooting gesture */
                else
                {
                    if(gesturePoints.Count > 30)
                    {
                        Point p = gesturePoints[gesturePoints.Count - 1];
                        
                    }
                    else
                    {
                        if(tapDownPoint.x < Screen.width / 2)
                            Instantiate(leftBullet, new Vector3(player.transform.position.x - 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                        else
                            Instantiate(bullet, new Vector3(player.transform.position.x + 1, player.transform.position.y, 1), new Quaternion(0, 0, 0, 1));
                    }
                }

            }

            tapDragPoint = hiddenPosition;
            tapDownPoint = hiddenPosition;
            gesturePoints.Clear();
        }
    }
}

class Point
{
    public float x, y;
}