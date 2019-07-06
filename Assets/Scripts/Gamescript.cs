using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamescript : MonoBehaviour {

    public GameObject manager;
	// Use this for initialization
	void Start () {
        createGamemanager();
	}

    private void createGamemanager()
    {
       GameObject managerRace =  Instantiate(manager, transform.position, Quaternion.identity);      
    }
}
