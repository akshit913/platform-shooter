using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (Input.GetTouch(0).position.y < Screen.height / 2)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 3)
                    {
                        Invoke("LoadEasyLevel", 1f);
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width - (Screen.width / 3))
                    {
                        Invoke("LoadHardLevel", 1f);
                    }
                    else
                    {
                        Invoke("LoadMediumLevel", 1f);
                    }
                }
            }
        }
    }

    void LoadEasyLevel()
    {
        Helper.currentScene = 4;
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    void LoadMediumLevel()
    {
        Helper.currentScene = 5;
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    void LoadHardLevel()
    {
        Helper.currentScene = 7;
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }
}


