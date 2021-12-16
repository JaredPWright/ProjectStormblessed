using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public float startTime = 10.0f;
    public float spawnRepeat = 3.5f;
    
    private int waypointGroupAccessKey = 0;
    //For keeping track of which patrol route to spawn on
    private int spawnIndex = 0;

    public void BeginSpawn()
    {
        Debug.Log("Beginning spawn");
        foreach(Transform waypoint in Waypoints.waypointGroup1)
        {
            waypointGroupAccessKey++;
            for(int i = 0; i < 3; i++)
            {
                SpawnEnemy();
            }
        }

        GameObject tempObject = Instantiate(bossPrefab, Waypoints.waypointGroup1[(int)Random.Range(0.0f, (float)Waypoints.waypointGroup1.Length) - 1].position, Quaternion.identity);
    }

    public void SpawnEnemy()
    {
        //Increment the spawnIndex counter
        spawnIndex++;

        //create as many cases as there are waypoint groups
        //Basically, this rotates through the arrays and spawns a
        //creature at a different patrol route every time. It increments
        //a counter that resets once you run out of patrol paths to
        //spawn on. 
        GameObject crab = Instantiate(enemyPrefab, Waypoints.waypointGroup1[waypointGroupAccessKey].position, Quaternion.identity);
        AssignWaypoints(Waypoints.waypointGroup1, crab);

        void AssignWaypoints(Transform[] transforms, GameObject crabObject)
        {
            EnemyManager enemyManager = crabObject.GetComponentInChildren<EnemyManager>();
            for(int i = 0; i < transforms.Length; i++)
            {
                enemyManager.destination.Add(transforms[i]);
            }
        }
    }
}