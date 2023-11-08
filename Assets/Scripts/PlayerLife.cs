using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private int deathCount = 0;

    private void Start()
    {
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);

        if (deathCount > 0)
        {
            deathCount = 0;
        }
        
    }
    private void Update()
    {
        // Debug.Log("Death Count: " + deathCount);
        if (isPlayerFallingOff())
        {
            // Debug.Log("Death Count: " + deathCount);
            resolvePlayerDeath();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("colliding with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy Body"))
        {
            resolvePlayerDeath();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            resolvePlayerWin();
        }
    }

    private void resolvePlayerWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private bool isPlayerFallingOff()
    {
        return GetComponent<Rigidbody>().transform.position.y < -3f;
    }
    
    private void resolvePlayerDeath()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);

        if (deathCount >= 30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  
        }
        else
        {
            reloadLevel();
        }
        
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
