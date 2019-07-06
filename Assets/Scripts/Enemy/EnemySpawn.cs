using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemySpawn : NetworkBehaviour
{
    public GameObject enemyCar;
    public float EnemySpeed;

    private Transform spawnPoint1, spawnPoint2, spawnPoint3;
    private Transform navTarget1, navTarget2, navTarget3;

    private bool collisionDone = false;
    private bool isSpawning = false;

    [SerializeField]
    float enemySpawnTime = 5f;
   
    private void Start()
    {
        spawnPoint1 = GameObject.Find("EnemySpawnOne").transform;
        spawnPoint2 = GameObject.Find("EnemySpawnTwo").transform;
        spawnPoint3 = GameObject.Find("EnemySpawnThree").transform;

        navTarget1 = GameObject.Find("EnemyTarget1").transform;
        navTarget2 = GameObject.Find("EnemyTarget2").transform;
        navTarget3 = GameObject.Find("EnemyTarget3").transform;

        collisionDone = true;
    }

    private IEnumerator waitTime()
    {
        collisionDone = false;
        yield return new WaitForSeconds(Random.Range(10,15));
        print("working");
        collisionDone = true;
    }

    private void Update()
    {

        if (!isLocalPlayer)
            return;

            if (!isSpawning)
            {
                print("spawning");
                CmdSpawnEnemy();
                isSpawning = true;
                StartCoroutine("ResetEnemySpawnTime");
            }
    }

    IEnumerator ResetEnemySpawnTime()
    {
        yield return new WaitForSeconds(enemySpawnTime);
        isSpawning = false;
    }

    [Command]
    void CmdSpawnEnemy()
    {
        RpcSpawnEnemyOnEachPC();
    }

    [ClientRpc]
    void RpcSpawnEnemyOnEachPC()
    {
        if (collisionDone) {
        GameObject enemy1 = (GameObject)Instantiate(enemyCar, spawnPoint1);
        GameObject enemy2 = (GameObject)Instantiate(enemyCar, spawnPoint2);
        GameObject enemy3 = (GameObject)Instantiate(enemyCar, spawnPoint3);

        enemy1.GetComponent<NavMeshAgent>().speed = 30f;
        enemy2.GetComponent<NavMeshAgent>().speed = 30f;
        enemy3.GetComponent<NavMeshAgent>().speed = 30f;

        enemy1.GetComponent<NavMeshAgent>().destination = navTarget1.position;
        enemy2.GetComponent<NavMeshAgent>().destination = navTarget2.position;
        enemy3.GetComponent<NavMeshAgent>().destination = navTarget3.position;

        StartCoroutine("waitTime");
    }
    }
 
  
}
