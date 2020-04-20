using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director2 : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;
    public GameObject dialogue6;
    public GameObject dialogue7;
    public GameObject dialogue8;
    public GameObject dialogue9;
    public GameObject dialogue10;
    public GameObject dialogue11;
    public GameObject satan;
    public GameObject bricks1;
    public GameObject bricks2;
    public GameObject bricks3;
    public GameObject bricks4;
    public GameObject bricks5;

    private int currentStep;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && currentStep > 0)
        {
            currentStep++;
        }

        if (currentStep == 0 && satan.transform.position.y > 2.0f)
            satan.transform.position = new Vector3(satan.transform.position.x, satan.transform.position.y - 0.02f, satan.transform.position.z);
        else if (currentStep == 0)
            currentStep = 1;

        if (currentStep == 1)
        {
            dialogue1.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 2)
        {
            dialogue1.GetComponent<SpriteRenderer>().enabled = false;
            dialogue2.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 3)
        {
            dialogue2.GetComponent<SpriteRenderer>().enabled = false;
            dialogue3.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 4)
        {
            dialogue3.GetComponent<SpriteRenderer>().enabled = false;
            dialogue4.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 5)
        {
            dialogue4.GetComponent<SpriteRenderer>().enabled = false;
            dialogue5.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 6)
        {
            dialogue5.GetComponent<SpriteRenderer>().enabled = false;
            dialogue6.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 7)
        {
            dialogue6.GetComponent<SpriteRenderer>().enabled = false;
            dialogue7.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 8)
        {
            dialogue7.GetComponent<SpriteRenderer>().enabled = false;
            dialogue8.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 9)
        {
            dialogue8.GetComponent<SpriteRenderer>().enabled = false;
            dialogue9.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 10)
        {
            dialogue9.GetComponent<SpriteRenderer>().enabled = false;
            dialogue10.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 11)
        {
            dialogue10.GetComponent<SpriteRenderer>().enabled = false;
            dialogue11.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep >= 12)
        {
            dialogue11.GetComponent<SpriteRenderer>().enabled = false;

            if (satan.transform.position.y < 6.66f)
            {
                satan.transform.position = new Vector3(satan.transform.position.x, satan.transform.position.y + 0.02f, satan.transform.position.z);
                
                bricks1.transform.position = new Vector3(bricks1.transform.position.x, bricks1.transform.position.y - 0.03f, bricks1.transform.position.z);
                bricks2.transform.position = new Vector3(bricks2.transform.position.x, bricks2.transform.position.y - 0.02f, bricks2.transform.position.z);
                bricks3.transform.position = new Vector3(bricks3.transform.position.x, bricks3.transform.position.y - 0.05f, bricks3.transform.position.z);
                bricks4.transform.position = new Vector3(bricks4.transform.position.x, bricks4.transform.position.y - 0.04f, bricks4.transform.position.z);
                bricks5.transform.position = new Vector3(bricks5.transform.position.x, bricks5.transform.position.y - 0.03f, bricks5.transform.position.z);
            }
            else
                currentStep++;
        }

        if (currentStep >= 13)
        {
            Helper.currentScene++;
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helper.currentScene);
        }
    }
}
