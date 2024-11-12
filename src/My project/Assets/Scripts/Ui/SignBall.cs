using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBall : MonoBehaviour {
    public GameObject playerObj;
    private PlayerStatus playerStatus;

    public GameObject signBall;

    // Start is called before the first frame update
    void Start() {
        playerStatus = playerObj.GetComponent<PlayerStatus>();
        if (playerStatus == null) Debug.LogError("no playerStatus");
    }

    // Update is called once per frame
    void Update() {
        if (playerStatus.hasBall) signBall.SetActive(true);
        else signBall.SetActive(false);
    }
}
