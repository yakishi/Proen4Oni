using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    /// <summary>
    /// タイマー
    /// </summary>
    static public Timer timer;
    public Timer Timer { get { return timer; } }

    /// <summary>
    /// ターン
    /// </summary>
    public enum Turn
    {
        red,
        blue
    }

    static private Turn turn_;
    public Turn turn {
        set
        {
            turn_ = value;
        }

        get
        {
            return turn_;
        }
    }

    // Use this for initialization
    void Start () {
        timer = new Timer(60.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (timer.isRunning()) {
            timer.Update();
        }
	}
}
