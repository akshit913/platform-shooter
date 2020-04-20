﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Helper.currentLevel = Helper.currentScene;
            Helper.currentScene = 8;
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helper.currentScene);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ChargedShot") || other.gameObject.tag.Equals("Bullet") || other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Lava"))
        {
            Helper.currentLevel = Helper.currentScene;
            Helper.currentScene = 8;
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helper.currentScene);
        }
    }

    void Update()
    {
        if(transform.position.y < -20)
        {
            Helper.currentLevel = Helper.currentScene;
            Helper.currentScene = 8;
            UnityEngine.SceneManagement.SceneManager.LoadScene(Helper.currentScene);
        }
    }
}
