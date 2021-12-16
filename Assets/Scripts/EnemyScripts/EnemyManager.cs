using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// this line goes BEFORE the "public class" declaration, and just makes sure
// that WHATEVER GameObject this script is on MUST have a NavMeshAgent, or
// the game won't even run... as we saw in class
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyManager : MonoBehaviour
{
    public int enemyHealth = 5;
    //[SerializeField] private Slider healthBar;
    public bool alreadyDied = false;
    public GameObject sphereDrop;

    //From ChasePlayer
    NavMeshAgent navMeshAgent;
    public List<Transform> destination;
    private int a = 1;
    public bool chasingPlayer = false;
    [SerializeField] GameObject playerTransform;

    [SerializeField] private GameObject parentObject;

    // RaycastGunScript raycastGunScript;

// Start is called before the first frame update

   // Start is called before the first frame update
    void Start()
    {
      navMeshAgent = GetComponent<NavMeshAgent>();
      SetDestination();
      if(gameObject.CompareTag("BeegCrab"))
      {
        enemyHealth = 15;
      }
    }

    // Update is called once per frame
    void Update()
    {
      if(enemyHealth <= 0 && !alreadyDied)
      {
        // Debug.Log(enemyHealth);
        alreadyDied = true;
        KillAfterAnim();
      }
      
      if(chasingPlayer)
      {
        playerTransform = GameObject.Find("Player");
      }

      //healthBar.value = enemyHealth;
    }

    void KillAfterAnim()
    {
      if(this.gameObject.CompareTag("RegularCrab"))
        Stormfather.regularEnemiesKilled++;
      else if(this.gameObject.CompareTag("BeegCrab"))
        Stormfather.bossDead = true;
      Destroy(this.gameObject);
    }

    void SetDestination() 
    {
      if(chasingPlayer && !alreadyDied)
      {
        navMeshAgent.SetDestination(playerTransform.transform.position);
        navMeshAgent.speed += 5;
      }
      else
      {
        navMeshAgent.SetDestination(destination[a].transform.position);
        navMeshAgent.speed = 5;
      }
    }

    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Path" && !alreadyDied)
      {
        a++;
        SetDestination();
        if(a > (destination.Count - 1))
        {
          a = 0;
        }
      }
    }

    void OnDestroy()
    {
      GameObject tempSpawn = Instantiate(sphereDrop, transform.position, Quaternion.identity);
    }
}