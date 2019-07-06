using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Clock : NetworkBehaviour {

    [SyncVar]
    private float time;
    public Text timeText;
  
    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        StartCoroutine(waitTime(1));
        timeText.text = "Time :"+(int)time;
    }

    IEnumerator waitTime(float second)
    {
        yield return new WaitForSeconds(second);
        time += Time.deltaTime;
        print("corouting working");
    }
}
