using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageEnemy : MonoBehaviour
{
    private int ticks;
    public GameObject hostage;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ticks = 800;
    }

    // Update is called once per frame
    void Update()
    {
        if (Helper.Distance(transform.position.x, transform.position.y, player.transform.position.x, player.transform.position.y) < 10)
        {
            if (ticks > 0)
            {
                ticks -= 1;
            }
            else
            {
                ((SpriteRenderer)GetComponent<SpriteRenderer>()).color = new Color(255, 0, 0);
                Destroy(hostage);
            }
        }
    }
}
