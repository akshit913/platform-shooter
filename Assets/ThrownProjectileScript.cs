using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownProjectileScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
