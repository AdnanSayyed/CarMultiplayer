using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Playerscript : NetworkBehaviour
{
    public Renderer playerRenderer;
    public Material materialOne;
    public Material materialTwo;
    public GameObject carBody;
    public float carSpeed = 1f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    private bool canShoot = false;

    public GameObject gunPrefab;
    public GameObject gunCollectablePrefab;
    public bool bulletActivated = false;

    [SyncVar] public string carMaterial;
    [SyncVar] public string mymaterialName;

    public GameObject[] gunSpawnPoints;

    public Rigidbody rb;

    [SyncVar]
    public int numberofPlayer = 0;

    public AudioClip blastClip,shootClip,MusicClip;

    public override void OnStartServer()
    {
        
    }

    [Command]
    public void CmdNumberOfPlayer()
    {
       RpcPlayerNum();
    }

    [ClientRpc]
    public void RpcPlayerNum()
    {
        print("number of player:" + numberofPlayer);
        if (!isLocalPlayer)
        {
            numberofPlayer = NetworkManager.singleton.numPlayers;
        }
    }
    
    public override void OnStartClient()
    {
        //base.OnStartClient();
      CmdChangeMaterial(mymaterialName);
    }


    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        //Instantiate(gunCollectablePrefab, gunCollectablePrefab.transform.position,gunCollectablePrefab.transform.rotation);
        SoundManager.instance.PlayMusic(MusicClip);
        Instantiate(gunCollectablePrefab, gunSpawnPoints[Random.Range(0, 5)].transform.position, gunSpawnPoints[Random.Range(0,5)].transform.rotation);
        Instantiate(gunCollectablePrefab, gunSpawnPoints[Random.Range(1, 4)].transform.position, gunSpawnPoints[Random.Range(0, 5)].transform.rotation);
       
        switch (GameController.materialSelected)
        {
            case "materialOne":
                {
                    mymaterialName = "matOne";
                    break;
                }
            case "materialTwo":
                {
                    mymaterialName = "matTwo";
                    print("materialTwo work");
                    break;
                }
        }
        carBody.GetComponent<Renderer>().material = Resources.Load(mymaterialName) as Material;
        CmdChangeMaterial(mymaterialName);

        #region
        /* if(GameController.materialSelected == "materialOne")
         {
             carMaterial = "materialOne";
         }
         else
         {
             carMaterial = "materialTwo";
         }

         if (carMaterial == "materialOne")
         {
             //playerRenderer.material = materialOne;
             gameObject.transform.GetChild(6).GetChild(0).GetComponentInChildren<Renderer>().material = Resources.Load("matOne") as Material;
         }
         else
         {
             //playerRenderer.material = materialTwo;
             gameObject.transform.GetChild(6).GetChild(0).GetComponentInChildren<Renderer>().material = Resources.Load("matTwo") as Material;
         }
         CmdChangeMaterial(carMaterial);
         */
        #endregion
    }


    [Command]
    public void CmdChangeMaterial(string namemat)
    {
        carBody.GetComponent<Renderer>().material = Resources.Load(namemat) as Material;
        RpcChangeMaterial(namemat);
        #region
        /*
        if (myMaterial == "materialOne")
        {
            //playerRenderer.material = materialOne
            gameObject.transform.GetChild(6).GetChild(0).GetComponentInChildren<Renderer>().material = Resources.Load("matOne") as Material;
        }
        else
        {
           // playerRenderer.material = materialTwo;
            gameObject.transform.GetChild(6).GetChild(0).GetComponentInChildren<Renderer>().material = Resources.Load("matTwo") as Material;
        }*/
        #endregion
    }


    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;

        if (GameController.playerStatus == "Host")
        {
            //transform.position = new Vector3(-3, 0.5f, 3);
           transform.position = new Vector3(-225.37f, 6.18f, -882.6f);
        }
        else
        {
            // transform.position = new Vector3(3, 0.5f, 3);
            transform.position = new Vector3(-201.1f, 6.18f, -882.6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        #region
        /* switch(GameController.carSelected)
         {
             case "Carone":
                 {
                     // GetComponent<Renderer>().material = materialOne;
                     playerRenderer.material = materialOne;
                     print("materialOne");
                     break;
                 }
                 case "Cartwo":
                 {
                     // GetComponent<Renderer>().material = materialTwo;
                     playerRenderer.material = materialTwo;
                     print("materialTwo");
                     break;
                 }
         }*/
        //GetComponent<Renderer> ().material = myMaterial;
        #endregion
     
        if (!canShoot)
        {
            if (Input.GetKey(KeyCode.LeftControl) && bulletActivated)
            {
                CmdSpawnBullet();
                canShoot = true;
                SoundManager.instance.PlayOtherSound(shootClip);
            }
            
        }
       var x = Input.GetAxis("Horizontal") * Time.deltaTime * 300;
       var z = Input.GetAxis("Vertical") * Time.deltaTime*20f;
       transform.Rotate(0, x, 0);
       transform.Translate(0, 0, z);


    }

    [ClientRpc]
    void RpcChangeMaterial(string whichmat)
    {
        carBody.GetComponent<Renderer>().material = Resources.Load(whichmat) as Material;
    }

    [Command]
    void CmdSpawnBullet()
    {
        RpcSpawnBulletOnEachPC(); 
    }

    [ClientRpc]
    void RpcSpawnBulletOnEachPC()
    {
        var bullet1 = (GameObject)Instantiate(bulletPrefab, bulletSpawn1.position, bulletSpawn1.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward  * 200;
        StartCoroutine("waitTime");
        Destroy(bullet1, 6f);
    }
    private IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.3f);
        canShoot = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("enemy touched");
          //  rb.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            print("player shooted");
         
            SoundManager.instance.PlayOtherSound(blastClip);
            NetworkServer.Destroy(transform.parent.parent.gameObject);
        }
       
      if (collision.gameObject.tag == "GunCollectable")
        {
             Destroy(collision.gameObject);
             bulletActivated = true;
            gunPrefab.SetActive(true); 
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("enemy untouched");
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
