using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {
    private bool                  saved;
    public  GameObject            confirmationModal;
    public  TextMeshProUGUI       dayText;
    public  TextMeshProUGUI       date;
    public  TextMeshProUGUI       time;
    public  GameObject            empty;
    public  Image                 image;
    public  GameObject            menu;
    public  ScreenshotSaveCapture capture;
    public  NarrativeManager      narrativeManager;
    public int                   saveSlot;

    public void TryToSave() {
        if (saved) {
            OpenConfirmation();
            return;
        } 
        SaveGame();
    }

    private void OpenConfirmation() {
        confirmationModal.SetActive(true);
        confirmationModal.GetComponent<ConfirmSave>().SetSave(SaveGame);
    }

    public void SaveGame() {
        saved = true;
        dayText.gameObject.SetActive(true);
        dayText.text = "Day "+ NarrativeManager.Instance.currentNarrativeItem.day;
        date.gameObject.SetActive(true);
        DateTime currentDateTime = DateTime.Now;
        string currentDate = currentDateTime.ToString("MM/dd/yyyy");
        date.text = currentDate+"";
        time.gameObject.SetActive(true);

        // Format the time part with a custom format
        string currentTimeString = currentDateTime.ToString("hh:mm:ss tt");
        time.text = currentTimeString;
        empty.SetActive(false);
        SaveData saveData = narrativeManager.GetSaveData();
        string jsonData = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData"+saveSlot, jsonData);
        PlayerPrefs.Save();
        
        
        capture.Capture(saveSlot,image);
    }
    
    
    
    
    
}
