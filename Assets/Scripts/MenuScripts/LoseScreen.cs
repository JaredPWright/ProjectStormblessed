using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    private Stormfather stormfather;
    // Start is called before the first frame update
    public void Retry()
    {
        stormfather = GameObject.Find("Stormfather").GetComponent<Stormfather>();

        SceneManager.LoadScene(stormfather.scenes[stormfather.currentScene--].name);
    }

    // Update is called once per frame
    public void Quitter()
    {
        Application.Quit();
    }
}
