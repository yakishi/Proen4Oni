using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    [SerializeField]
    GameObject focusObj;

    [SerializeField]
    float speedMag = 1.0f;  //カメラの回転速度倍率

    // Use this for initialization
    void Start() {
        //注視点のオブジェクトをカメラの親にする
        Transform trans = this.transform;
        transform.parent = focusObj.transform;

        // カメラの方向を注視点に向ける
        trans.LookAt(focusObj.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
        if (MyInput.isRotate()) {
            CameraRotate(MyInput.Rotation());
        }
	}

    /// <summary>
    /// カメラの回転
    /// </summary>
    void CameraRotate(Vector3 tmpEulerAngle)
    {

        Vector3 eulerAngle = tmpEulerAngle * speedMag;
        Vector3 focusPos = focusObj.transform.position;
        Transform trans = this.transform;

        // 回転前のカメラ情報を保存
        Vector3 preUpV, preAngle, prePos;
        preUpV = trans.up;
        preAngle = trans.localEulerAngles;
        prePos = trans.position;

        // カメラの回転
        // 横方向はグローバル座標系のY軸で回転
        trans.RotateAround(focusPos, Vector3.up, eulerAngle.y);
        // 縦軸方向はカメラのローカル座標系のX軸で回転
        trans.RotateAround(focusPos, trans.right, -eulerAngle.x);

        // カメラを注視点に向ける
        trans.LookAt(focusPos);

        // ジンバルロック対策
        Vector3 up = trans.up;
        if (Vector3.Angle(preUpV, up) > 30.0f) {
            trans.localEulerAngles = preAngle;
            trans.position = prePos;
        }
    }
}
