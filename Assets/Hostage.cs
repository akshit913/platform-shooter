using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnGUI()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ChargedShot") || other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(gameObject);
            Helper.currentLevel = Helper.currentScene;
            Helper.currentScene = 10;
            UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        }
        else if (other.gameObject.tag.Equals("play"))
        {
            if(Helper.currentScene == 7)
            {
                Helper.currentLevel = 11;
                Helper.currentScene = 9;
                UnityEngine.SceneManagement.SceneManager.LoadScene(9);
            }
            else
            {
                Helper.currentLevel = Helper.currentScene + 1;
                Helper.currentScene = 9;
                UnityEngine.SceneManagement.SceneManager.LoadScene(9);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
