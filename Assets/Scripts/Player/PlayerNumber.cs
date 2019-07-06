using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// calculates connected player number
/// </summary>
public class PlayerNumber : NetworkBehaviour {

    [SyncVar(hook ="OnPlayerNumChange")]
    public int numberofPlayer = 0;
    public Text noOfPlayer;

    public override void OnStartServer()
    {
        base.OnStartServer();
        numberofPlayer = NetworkManager.singleton.numPlayers;
        noOfPlayer = GameObject.FindGameObjectWithTag("PlayerNumberText").GetComponent<Text>();
        noOfPlayer.text ="No Of Player: "+ numberofPlayer.ToString();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        noOfPlayer = GameObject.FindGameObjectWithTag("PlayerNumberText").GetComponent<Text>();
        noOfPlayer.text = "No Of Player: " + numberofPlayer.ToString(); 
    }
   
    void OnPlayerNumChange(int numberOfPlayer)
    {
        noOfPlayer.text = "No Of Player: " + numberofPlayer.ToString();
        Debug.Log("Sync hook working");
    }
}
