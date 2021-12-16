using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //Make a private Transform array for every Patrol Route
    //Make sure that you name them like WaypointGroupSomeNumber0, WaypointGroupSomeNumber1, WaypointGroupSomeNumber2, etc., etc.
    public static Transform[] waypointGroup1 = new Transform[12];

    //This is called a Jagged Array- in simpler terms, an array of an array.
    //Depending on how many patrol routes you have, you can tell it how many
    //arrays it'll hold. I've put 3 here as a placeholder value.
    public static Transform[][] waypointGroups = new Transform[6][];

    private Spawn spawn;

    public void LoadWaypoints()
    {
        spawn = GetComponent<Spawn>();
        Debug.Log("CallingLoadWaypoints");
        //Perform this operation for every waypoint group
        for(int i = 0; i < waypointGroup1.Length; i++)
        {
            //Load the waypoints by name. Make sure your conventions are consistent. 
            waypointGroup1[i] = GameObject.Find("PotentialBossSpawn" + i.ToString()).GetComponent<Transform>();
            Debug.Log(waypointGroup1[i].name);
        }
        

        //Load the waypointGroup arrays into this jagged array.
        waypointGroups[0] = waypointGroup1;

        spawn.BeginSpawn();
    }
}