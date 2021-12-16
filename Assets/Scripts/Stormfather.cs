using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Stormfather : MonoBehaviour
{
    private Waypoints waypoints;
    public static int regularEnemiesKilled = 0;
    public static bool bossDead = false;
    private bool level1Loaded = false;
    public static int spheresCollected = 0;

    public TextMeshProUGUI textUpdate;
    public TextMeshProUGUI sphereUpdate;
    
    public List<Scene> scenes = new List<Scene>();
    public int currentScene = 0;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scenes.Add(SceneManager.GetActiveScene());
        currentScene++;
    }

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().name == "Level1") && !level1Loaded)
        {
            waypoints = GetComponent<Waypoints>();
            textUpdate = GameObject.Find("CrabsKilled").GetComponent<TextMeshProUGUI>();
            sphereUpdate = GameObject.Find("SpheresCollected").GetComponent<TextMeshProUGUI>();
            Debug.Log("about to load waypoints");
            waypoints.LoadWaypoints();
            level1Loaded = true;
        }

        if(level1Loaded)
        {
            textUpdate.text = "Small Greatshells Defeated: " + regularEnemiesKilled.ToString();
            sphereUpdate.text = "Spheres Collected: " + spheresCollected.ToString();
        }

        if(bossDead && regularEnemiesKilled >= 7)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

}
