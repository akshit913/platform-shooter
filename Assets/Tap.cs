using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    public Vector3 hiddenPosition;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = position.z;
            position = temp;
            transform.position = position;
        }
        else if(Input.GetMouseButton(0))
        {

        }
        else 
        {
            position = hiddenPosition;
            transform.position = position;
        }
    }
}
