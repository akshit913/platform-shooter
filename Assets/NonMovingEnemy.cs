using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMovingEnemy : MonoBehaviour
{
    private int frameNumber;
    public GameObject player;
    public GameObject chargedShot;

    // Start is called before the first frame update
    void Start()
    {
        frameNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frameNumber++;
        if(frameNumber >= 120)
        {
            frameNumber = 0;

            float xMagnitude = player.transform.position.x - transform.position.x;
            float yMagnitude = player.transform.position.y - transform.position.y;
            float total = 300.0f;
            float xForce = (xMagnitude / Mathf.Abs(yMagnitude)) * total;
            float yForce = (yMagnitude / Mathf.Abs(xMagnitude)) * total;

            if(xForce > total)
                xForce = total;
            if(yForce > total)
                yForce = total;
            if(xForce < total * -1.0f)
                xForce = total * -1.0f;
            if(yForce < total * -1.0f)
                yForce = total * -1.0f;

            var clone = Instantiate(chargedShot, new Vector3(transform.position.x, transform.position.y, 1), new Quaternion(0, 0, 0, 1));
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(xForce, yForce, 0));
        }
    }
}
