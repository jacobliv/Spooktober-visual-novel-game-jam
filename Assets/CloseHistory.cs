using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHistory : MonoBehaviour {
    public GameObject menu;
    public void Close() {
        menu.SetActive(false);
    }
}
