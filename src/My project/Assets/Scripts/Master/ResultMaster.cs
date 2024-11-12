using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultMaster : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Scores;
    public Text Winner;
    void Start() {
        Scores.text = $"{ResultSender.player1Score} - {ResultSender.player2Score}";

        if (ResultSender.player1Score > ResultSender.player2Score) Winner.text = "Player 1 Win !";
        else if (ResultSender.player2Score > ResultSender.player1Score) Winner.text = "Player 2 Win !";
        else Winner.text = "Draw";        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Space)) GoTitle();
    }

    void GoTitle() {

        SceneManager.LoadScene("Title");
    }
}
