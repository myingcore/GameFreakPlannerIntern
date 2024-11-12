using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public GameObject playerObj;
    private PlayerStatus playerStatus;

    private Text scoreText;


    // Start is called before the first frame update
    void Start() {
        playerStatus = playerObj.GetComponent<PlayerStatus>();
        if (playerStatus == null) Debug.LogError("no playerStatus");

        scoreText = GetComponentInChildren<Text> ();
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = $"Score: {playerStatus.score}";
    }
}
