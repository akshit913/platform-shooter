using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            if(Input.GetTouch(0).position.y < Screen.height / 2)
            {
                //left
                if (Input.GetTouch(0).position.x < Screen.width / 3)
                {
                    Invoke("LoadLevelMenu", 1f);
                }

                //right
                else if (Input.GetTouch(0).position.x > Screen.width - (Screen.width / 3))
                {
                    Invoke("LoadTutorial", 1f);
                }

                //middle
                else
                {
                    Invoke("LoadCampaign", 1f);
                }
            }
        }
    }

    void LoadLevelMenu()
    {
        Helper.currentScene = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    void LoadTutorial()
    {
        Helper.currentScene = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    void LoadCampaign()
    {
        Helper.currentScene = 2;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
