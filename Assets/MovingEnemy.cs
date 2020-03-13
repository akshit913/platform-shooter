using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private int frameNumber;
    public GameObject player;
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        frameNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.Distance(transform.position.x, transform.position.y, player.transform.position.x, player.transform.position.y) < 10)
        {
            frameNumber++;

            if (frameNumber >= 120)
            {
                frameNumber = 0;

                if (player.transform.position.x < transform.position.x)
                {
                    rigidBody.AddForce(Vector3.left * 300);
                }
                else
                {
                    rigidBody.AddForce(Vector3.right * 300);
                }
            }
        }

    }
}
