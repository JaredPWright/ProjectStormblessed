using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
