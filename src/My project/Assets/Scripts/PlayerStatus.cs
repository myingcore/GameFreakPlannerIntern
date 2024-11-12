using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    // master's parameter and variable
    public GameObject gameMasterObj;
    private GameParameters gameParams;

    // parameter about user
    public bool hasBall;
    public bool canCatch;
    public float countNextCatch;
    public bool canThrow;
    public float countNextThrow;
    public int score;

    // others
    public GameObject theOtherPlayer;
    private PlayerStatus theOtherPlayerStatus;

    void Start() {
        gameParams = gameMasterObj.GetComponent<GameParameters>();
        if (gameParams == null) Debug.LogError("no gameParams");

        theOtherPlayerStatus = theOtherPlayer.GetComponent<PlayerStatus>();
        if (theOtherPlayerStatus == null) Debug.LogError("no theOtherPlayerStatus");

        score = 0;
        canCatch = true;
        countNextCatch = 0;
        canThrow = true;
        countNextThrow = 0;
    }

    void Update() {
        if (!canCatch) {
            countNextCatch += Time.deltaTime;
            if(countNextCatch >= gameParams.t_cooldownCatch) {
                canCatch = true;
                countNextCatch = 0;
            }
        }

        if (!canThrow) {
            countNextThrow += Time.deltaTime;
            if (countNextThrow >= gameParams.t_cooldownThrow) {
                canThrow = true;
                countNextThrow = 0;

                if (! theOtherPlayerStatus.hasBall) {
                    hasBall = true;
                }
            }
        }
    }
}
