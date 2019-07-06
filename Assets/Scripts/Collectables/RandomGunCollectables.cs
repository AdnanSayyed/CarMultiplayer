using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// spawns gun collectables at given positions
/// </summary>
public class RandomGunCollectables : MonoBehaviour {

    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6;
    public float spawnRate = 2f;
    float nextSpawn = 0f;

    int whatToSpawn;
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;

                case 2:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;

                case 3:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;

                case 4:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;

                case 5:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;

                case 6:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
	}
}
