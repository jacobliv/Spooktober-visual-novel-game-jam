using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCursorOnAwake : MonoBehaviour {
    public Texture2D arrow;
    private void Start() {
        Debug.Log("Changing");
        Cursor.SetCursor(arrow,Vector2.zero,CursorMode.ForceSoftware);

    }
}
