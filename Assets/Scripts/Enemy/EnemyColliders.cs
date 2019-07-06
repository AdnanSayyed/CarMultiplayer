using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyColliders : NetworkBehaviour
{
    public GameObject explosionParticle;
    public AudioClip blastSound;
    public bool shooted = false;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "Bullet")
        {
            shooted = true;
            SoundManager.instance.PlayOtherSound(blastSound); 
            var ExplosionParticle= (GameObject)Instantiate(explosionParticle, explosionParticle.transform.position, explosionParticle.transform.rotation);
            Debug.Log("shooting damage");
            ExplosionParticle.transform.position = other.gameObject.transform.position;            
            NetworkServer.Destroy(gameObject);
            Destroy(ExplosionParticle,3f);
        }
    }
}
