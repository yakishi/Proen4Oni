using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    [SerializeField]
    Vector3 initPos;
    
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
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentPos += MyInput.Direction();

        transform.position = currentPos;
	}

    void Move()
    {
        if(MyInput.isMove()) {
            Debug.Log("(" + MyInput.Direction().x + " , " + MyInput.Direction().y + " , " + MyInput.Direction().z + ")");
            currentPos += MyInput.Direction();
        }
    }
}
