using UnityEngine;
using UnityEngine.Networking;

public class EnemyTarget : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Enemy")
        {
            //Destroy(other.transform.parent.parent.gameObject);
            NetworkServer.Destroy(other.transform.parent.parent.gameObject);
            print("enemy destroy");
        }
    }
}
