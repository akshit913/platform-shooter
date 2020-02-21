using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recognizer : MonoBehaviour
{
    public Vector3 hiddenPosition;
    public GameObject player;
    public GameObject tap;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = transform.position.z;
            transform.position = temp;

            if(Mathf.Abs(transform.position.x - tap.transform.position.x) > 0.5f)
            {
                if(transform.position.x > tap.transform.position.x)
                    player.transform.position += new Vector3(0.03f,0,0);
                else
                    player.transform.position -= new Vector3(0.03f,0,0);
            }


        }
        else 
        {
            transform.position = hiddenPosition;
        }
    }
}
