using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Managerscript : NetworkManager {

    public PlayerNumber playerNumber;
    public GameObject player;
	// Use this for initialization
    void Start()
    {
        playerPrefab = player;
        switch (GameController.playerStatus)
        {
            case "Host":
                {
                    print("started as host");
                    StartHost();
                    break;
                }
            case "Client":
                {
                    print("started as client");
                    StartClient();
                    break;
                }
        }
    }
     public override void OnServerDisconnect(NetworkConnection conn)
     {
        GameObject.FindGameObjectWithTag("PlayerNumberText").GetComponent<Text>().text = NetworkManager.singleton.numPlayers.ToString();
        playerNumber.numberofPlayer = NetworkManager.singleton.numPlayers;
        print("actual player are " +playerNumber.numberofPlayer);
     }

    

   



}
