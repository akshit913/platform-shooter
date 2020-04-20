using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    private float heightOffset;

    private void Start()
    {
        float bottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        heightOffset = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 6.0f, 0)).y - bottomY;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(Target.position.x, Target.position.y + heightOffset, Target.position.z);
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
