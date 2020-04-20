using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLoc : MonoBehaviour
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
            if(Input.GetTouch(0).position.x < 100 && Input.GetTouch(0).position.y > Screen.height - 70)
            {
                Helper.currentScene = 0;
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(70, Screen.height - 70, 1));
    }
}
