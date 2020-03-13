using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageEnemy : MonoBehaviour
{
    private int currentColorValue;
    public GameObject hostage;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentColorValue = 255;
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.Distance(transform.position.x, transform.position.y, player.transform.position.x, player.transform.position.y) < 10)
        {
            if (currentColorValue > 0)
            {
                currentColorValue -= 1;
            }
            else
            {
                ((SpriteRenderer)GetComponent<SpriteRenderer>()).color = new Color(255, currentColorValue, currentColorValue);
                Destroy(hostage);
            }
        }
    }
}
