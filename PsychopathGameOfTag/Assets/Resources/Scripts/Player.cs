using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField]
    Vector3 initPos;

    [SerializeField]
    float velocity;

    /// <summary>
    /// 向いている方向
    /// </summary>
    private float angleDirection;
    private Vector3 dir;

    public Vector3 Dir { get { return dir; } }

    //現在位置
    Vector3 currentPos;

	// Use this for initialization
	void Start ()
    {
        currentPos = transform.position;
        Initialize();
    }

    void Initialize()
    {
        currentPos = initPos;
        dir = new Vector3(Mathf.Cos(angleDirection), Mathf.Sin(angleDirection), 0.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        transform.position = currentPos;
	}

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        if(MyInput.isMove()) {
            currentPos += MyInput.Direction() * ( velocity * 0.1f );
        }
    }
}
