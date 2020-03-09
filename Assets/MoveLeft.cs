using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
 public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body.AddForce(Vector3.left * 300.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
