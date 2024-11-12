using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    // input
    private PlayerInputConfigs inputConfig;

    // master's parameter and variable
    public GameObject gameMasterObj;
    private GameParameters gameParams;

    // player's parameter and variable
    private PlayerStatus playerStatus;

    // for ball
    public GameObject ballPrefab;

    // for change color
    private Renderer objectRenderer;
    private Color defaultColor;
    
    // others
    public GameObject theOtherPlayer;
    private PlayerStatus theOtherPlayerStatus;
    

    // Start is called before the first frame update
    void Start() {
        inputConfig = GetComponentInChildren<PlayerInputConfigs>();
        if (inputConfig == null) Debug.LogError("no inputConfig");

        playerStatus = GetComponentInChildren<PlayerStatus>();
        if (playerStatus == null) Debug.LogError("no playerStatus");

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null) Debug.LogError("no objectRenderer");
        defaultColor = objectRenderer.material.color;

        gameParams = gameMasterObj.GetComponent<GameParameters>();
        if (gameParams == null) Debug.LogError("no gameParams");

        theOtherPlayerStatus = theOtherPlayer.GetComponentInChildren<PlayerStatus>();
        if (theOtherPlayerStatus == null) Debug.LogError("no theOtherPlayerStatus");
    }

    // Update is called once per frame
    void Update() {
        // has ball
        if (playerStatus.hasBall) {

            // throw ball
            if (Input.GetKeyUp(inputConfig.actionKey1) & playerStatus.canThrow) {
                GameObject ball = Instantiate(ballPrefab, transform.position + transform.forward * 2, Quaternion.identity);
                Rigidbody ballRb = ball.GetComponent<Rigidbody>();
                ballRb.AddForce(transform.forward * gameParams.s_normal_ball);
                Destroy(ball, gameParams.t_cooldownThrow);
                playerStatus.hasBall = false;
                playerStatus.canThrow = false;
                objectRenderer.material.color = defaultColor;

            // end to set up
            }else if (Input.GetKeyUp(inputConfig.actionKey2)){
                objectRenderer.material.color = defaultColor;

            // set up to throwing ball
            }else if ((Input.GetKey(inputConfig.actionKey1) | Input.GetKey(inputConfig.actionKey2)) & playerStatus.canThrow) {
                objectRenderer.material.color = Color.green;

            // move
            } else {
                if (Input.GetKey(inputConfig.upKey)) transform.position += transform.forward * gameParams.s_normal_player;
                if (Input.GetKey(inputConfig.downKey)) transform.position -= transform.forward * gameParams.s_normal_player;
                if (Input.GetKey(inputConfig.leftKey)) transform.position -= transform.right * gameParams.s_normal_player;
                if (Input.GetKey(inputConfig.rightKey)) transform.position += transform.right * gameParams.s_normal_player;
                objectRenderer.material.color = defaultColor;
            }

        // not has ball
        } else {
            if (playerStatus.canCatch) {
                // try to catch
                if (Input.GetKey(inputConfig.actionKey1)) {
                playerStatus.canCatch = false;

                // move
                } else {
                    if (Input.GetKey(inputConfig.upKey)) transform.position += transform.forward * gameParams.s_normal_player;
                    if (Input.GetKey(inputConfig.downKey)) transform.position -= transform.forward * gameParams.s_normal_player;
                    if (Input.GetKey(inputConfig.leftKey)) transform.position -= transform.right * gameParams.s_normal_player;
                    if (Input.GetKey(inputConfig.rightKey)) transform.position += transform.right * gameParams.s_normal_player;
                }
                objectRenderer.material.color = defaultColor;
            } else {
                objectRenderer.material.color = Color.magenta;
            }
        }


        transform.LookAt(theOtherPlayer.transform);
    }

    void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(inputConfig.actionKey1) & other.CompareTag("Ball") & playerStatus.canCatch) {
            playerStatus.hasBall = true;
            playerStatus.canThrow = false;
        }
    }
}
