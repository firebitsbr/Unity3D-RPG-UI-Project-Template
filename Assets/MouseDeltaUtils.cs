using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseDeltaUtils {

    static Vector3 LastMousePos = Input.mousePosition;

    public static Vector3 MouseDelta(this MonoBehaviour Object)
    {
        var Delta = Input.mousePosition - LastMousePos;

        LastMousePos = Input.mousePosition;

        return Delta;
    }
}
