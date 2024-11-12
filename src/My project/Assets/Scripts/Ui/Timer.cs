using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour {
    public GameObject gameMasterObj;
    private GameMaster gameMaster;

    private Text timerText;

    // Start is called before the first frame update
    void Start() {
        gameMaster = gameMasterObj.GetComponent<GameMaster>();
        if (gameMaster == null) Debug.LogError("no gameMaster");

        timerText = GetComponentInChildren<Text> ();
    }

    // Update is called once per frame
    void Update() {
        var lastTime = gameMaster.t_oneGame - gameMaster.nowTime;
        var span = new TimeSpan(0, 0, (int)lastTime);
        timerText.text = span.ToString(@"mm\:ss");
    }
}
