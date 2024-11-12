using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    // variable
    public float nowTime;
    public float t_oneGame = 10;

    private GameParameters gameParameters;

    public GameObject player1;
    private PlayerStatus player1Status;

    public GameObject player2;
    private PlayerStatus player2Status;

    // Start is called before the first frame update
    void Start() {
        gameParameters = GetComponent<GameParameters>();
        if (gameParameters == null) Debug.LogError("no gameParameters");

        player1Status = player1.GetComponent<PlayerStatus>();
        if (player1Status == null) Debug.LogError("no player1Status");

        player2Status = player2.GetComponent<PlayerStatus>();
        if (player2Status == null) Debug.LogError("no player2Status");

        nowTime = 0;

        player1Status.hasBall = true;
        player2Status.hasBall = false;
    }

    // Update is called once per frame
    void Update() {
        nowTime += Time.deltaTime;
        if (nowTime >= t_oneGame) GameOver() ;
    }

    public void GameOver() {
        ResultSender.player1Score = player1Status.score;
        ResultSender.player2Score = player2Status.score;
        SceneManager.LoadScene("Result");
    }
}
