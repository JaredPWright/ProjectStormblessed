using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float playerHealth = 100.0f;

    void Update()
    {
        if(playerHealth <= 0.0f)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
