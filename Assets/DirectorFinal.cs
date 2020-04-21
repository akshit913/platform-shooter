using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorFinal : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject satan;
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

        if (currentStep == 0 && satan.transform.position.y < 0.31f)
            satan.transform.position = new Vector3(satan.transform.position.x, satan.transform.position.y + 0.02f, satan.transform.position.z);
        else if (currentStep == 0)
            currentStep = 1;

        if (currentStep == 1)
        {
            dialogue1.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 2)
        {
            dialogue2.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep == 3)
        {
            dialogue3.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (currentStep >= 4)
        {
            Helper.currentLevel = 0;
            Helper.currentScene = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helper.currentScene);
        }
    }
}
