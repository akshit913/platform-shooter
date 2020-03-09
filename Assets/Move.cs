using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body.AddForce(Vector3.right * 300.0f);  
    }

    // Update is called once per frame
    void Update()
    {
    }
}
