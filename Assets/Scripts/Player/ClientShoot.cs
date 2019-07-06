using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClientShoot : NetworkBehaviour {

    public GameObject explosionParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {  
            print("player shooted");

            var ExplosionParticle = (GameObject)Instantiate(explosionParticle, explosionParticle.transform.position, explosionParticle.transform.rotation);
            ExplosionParticle.transform.position = other.gameObject.transform.position;
            Instantiate(ExplosionParticle, ExplosionParticle.transform.position, ExplosionParticle.transform.rotation);
            //NetworkServer.Destroy(other.transform.parent.parent.gameObject);
            NetworkServer.Destroy(other.transform.parent.parent.gameObject);
           // Destroy(other.transform.parent.parent.gameObject);
            Destroy(ExplosionParticle, 2f);
        }
    }
}
