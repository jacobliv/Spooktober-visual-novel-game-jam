using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmSave : MonoBehaviour {
    private Action save;
    public void SetSave(Action save) {
        this.save = save;
    }

    public void Confirm() {
        save.Invoke();
    }
}
