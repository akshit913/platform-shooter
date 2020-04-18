using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject multi;
    public GameObject mshot;
    public GameObject sling;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject normal;
    public GameObject quick;
    public GameObject multishot;
    public GameObject slingshot;
    // public GameObject screen6;
    // public GameObject screen7;
    // public GameObject screen8;

    public GameObject player;
    private int currentStep;
    private int hurdle;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = 0;
        hurdle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentStep == 1)
        {
            screen1.GetComponent<SpriteRenderer>().enabled = false;
            screen2.GetComponent<SpriteRenderer>().enabled = true;
            right.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(currentStep == 2)
        {
            screen2.GetComponent<SpriteRenderer>().enabled = false;
            right.GetComponent<SpriteRenderer>().enabled = false;
            screen3.GetComponent<SpriteRenderer>().enabled = true;
            left.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 3)
        {
            screen3.GetComponent<SpriteRenderer>().enabled = false;
            left.GetComponent<SpriteRenderer>().enabled = false;
            screen4.GetComponent<SpriteRenderer>().enabled = true;
            up.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 4)
        {
            screen4.GetComponent<SpriteRenderer>().enabled = false;
            up.GetComponent<SpriteRenderer>().enabled = false;
            screen5.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (hurdle == 1)
        {
            screen5.GetComponent<SpriteRenderer>().enabled = false;
            normal.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (player.transform.position.x > 52f)
        {
            normal.GetComponent<SpriteRenderer>().enabled = false;
            multi.GetComponent<SpriteRenderer>().enabled = true;
            quick.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (player.transform.position.x > 88f)
        {
            multi.GetComponent<SpriteRenderer>().enabled = false;
            quick.GetComponent<SpriteRenderer>().enabled = false;
            mshot.GetComponent<SpriteRenderer>().enabled = true;
            multishot.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (player.transform.position.x > 95f)
        {
            mshot.GetComponent<SpriteRenderer>().enabled = false;
            multishot.GetComponent<SpriteRenderer>().enabled = false;
            sling.GetComponent<SpriteRenderer>().enabled = true;
            slingshot.GetComponent<SpriteRenderer>().enabled = true;
        }
        

        // if (currentStep == 7)
        // {
        //     dialogue6.GetComponent<SpriteRenderer>().enabled = false;
        //     dialogue7.GetComponent<SpriteRenderer>().enabled = true;
        // }

        // if (currentStep == 8)
        // {
        //     dialogue7.GetComponent<SpriteRenderer>().enabled = false;
        //     dialogue8.GetComponent<SpriteRenderer>().enabled = true;
        // }

        // if (currentStep == 9)
        // {
        //     dialogue8.GetComponent<SpriteRenderer>().enabled = false;
        //     dialogue9.GetComponent<SpriteRenderer>().enabled = true;
        // }

        // if (currentStep == 10)
        // {
        //     dialogue9.GetComponent<SpriteRenderer>().enabled = false;
        //     dialogue10.GetComponent<SpriteRenderer>().enabled = true;
        // }

        // if(currentStep >= 11)
        // {
        //     dialogue10.GetComponent<SpriteRenderer>().enabled = false;

        //     if (satan.transform.position.y > -5f)
        //         satan.transform.position = new Vector3(satan.transform.position.x, satan.transform.position.y - 0.02f, satan.transform.position.z);
        //     else
        //         currentStep++;
        // }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && player.transform.position.x < 22f)
        {
            currentStep++;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && player.transform.position.x > 22f)
        {
            hurdle++;
        }
        // if(currentStep >= 12)
        // {
        //     UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        // }
    }
}
