using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private PlayerStatus player1Status;
    private PlayerStatus player2Status;

    // Start is called before the first frame update
    void Start() {
        player1 = GameObject.Find("Player1Charactor");
        player1Status = player1.GetComponentInChildren<PlayerStatus>();
        if (player1Status == null) Debug.LogError("no player1Status");

        player2 = GameObject.Find("Player2Charactor");
        player2Status = player2.GetComponentInChildren<PlayerStatus>();
        if (player2Status == null) Debug.LogError("no player2Status");
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.name == "Player1Charactor") {
            player2Status.score += 1;
        } else if (other.name == "Player2Charactor") {
            player1Status.score += 1;
        }
        Destroy(gameObject);
    }
}
