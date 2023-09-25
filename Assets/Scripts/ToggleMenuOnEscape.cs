using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleMenuOnEscape : MonoBehaviour {
    public GameObject       pauseMenu;
    public List<GameObject> otherMenus;
    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            List<GameObject> activeMenus = otherMenus.FindAll(menu => menu.activeSelf);
            if (activeMenus.Count == 0) {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                return;
            }
            foreach (var activeMenu in activeMenus) {
                activeMenu.SetActive(false);
            }
            pauseMenu.SetActive(true);
            
        }
    }
}
