using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenemanager : MonoBehaviour {

    public GameObject NetworkObject;
    // Use this for initialization
    void Start () {
		print (GameController.carSelected);
        GameObject networkObject = (GameObject)Instantiate(NetworkObject, NetworkObject.transform.position, Quaternion.identity);
    }
}
