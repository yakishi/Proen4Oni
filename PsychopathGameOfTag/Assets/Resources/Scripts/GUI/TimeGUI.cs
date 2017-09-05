using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGUI : MonoBehaviour {

    /// <summary>
    /// ゲーム
    /// </summary>
    [SerializeField]
    Game game;

    /// <summary>
    /// タイマー
    /// </summary>
    Timer timer;

    /// <summary>
    /// テキスト
    /// </summary>
    [SerializeField]
    Text timeText;

	// Use this for initialization
	void Start () {
        timer = game.Timer;
	}
	
	// Update is called once per frame
	void Update () {
        timer = game.Timer;

        Debug.Log(timer.RemainTime.ToString());

        if(timer.RemainTime > 0.0f) {
            timeText.text = timer.RemainTime.ToString();

            if (game.turn == Game.Turn.red) {
                timeText.color = Color.red;
            }
            else {
                timeText.color = Color.blue;
            }
        }
        else {
            timer.Reset();

            if (game.turn == Game.Turn.red) {
                game.turn = Game.Turn.blue;
            }
            else {
                game.turn = Game.Turn.red;
            }
        }
    }
}
