using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public Vector3 hiddenPosition;
    public Rigidbody playerRigidBody;

    void Awake()
    {

    }

    void OnGUI()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = transform.position.z;
            transform.position = temp;
        }
        else if(Input.GetMouseButton(0))
        {

        }
        else if(Input.GetMouseButtonUp(0))
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            /* Jump */
            if(temp.y - transform.position.y > 1.0f)
            {
                /* Jump up right */
                if(temp.x - transform.position.x > 1.0f)
                    playerRigidBody.AddForce(Vector3.right * 100.0f);
                if(transform.position.x - temp.x > 1.0f)
                    playerRigidBody.AddForce(Vector3.left * 100.0f);

                playerRigidBody.AddForce(Vector3.up * 500.0f);
            }
            
            /* Quick Descent */
            if(transform.position.y - temp.y > 1.0f)
            {
                playerRigidBody.AddForce(Vector3.down * 500.0f);
            }

            transform.position = hiddenPosition;
        }
    }
}
