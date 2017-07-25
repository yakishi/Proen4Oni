using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput{

    public static bool isMove()
    {
        return !(HorizontalAxis() == 0 && VerticallAxis() == 0);
    }

    public static float HorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }
    public static float VerticallAxis()
    {
        return Input.GetAxis("Vertical");
    }

    public static Vector3 Direction()
    {
        Vector3 ret = Vector3.zero;

        ret = new Vector3(HorizontalAxis(), 0, VerticallAxis()).normalized;

        return ret;
    }
}
