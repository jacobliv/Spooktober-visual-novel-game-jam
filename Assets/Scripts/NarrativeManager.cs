using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour {
    #region Dialogue

    [Header("Dialogue")] 
    [SerializeField] private SpokenTextCanvas dialogueUI;
    #endregion
    
    #region General
    [Header("General")]
    public  Image         background; 
    public Image            characterImage;
    public GameObject       characterCanvas;
    public GameObject       mainBackgroundCanvas;
    public List<GameObject> otherCanvases;
    public NarrationItem    startingNarrativeItem;
    public NarrationItem    currentNarrativeItem;
    public GameObject       creditsCanvas;
    #endregion

    #region Audio
    [Header("Audio")]
    public  AudioSource audioSource;
    private Coroutine   _audioCoroutine;
    #endregion
    
    #region Multi Choice Dialogue

    [Header("Multiple Choice Dialogue")]

    #endregion

    #region Characters

    [Header("Characters")]
    public Character mainCharacter;
    public List<Character> characters;
    #endregion

    [Header("History")] public AddAndRemoveHistory historyManager;
    private                    NarrativeHistory    _narrativeHistory;

    private void Start() {
        _narrativeHistory = GetComponent<NarrativeHistory>();
        _narrativeHistory.Reset();
        currentNarrativeItem = startingNarrativeItem;
        PrepareNarrativeArea();

        RunNarrativeItem();
    }

    public void AdvanceNarrative(int option = 0) {
        StopPreviousItem();
        if (currentNarrativeItem.next1 == null && currentNarrativeItem.next2 == null) {
            creditsCanvas.SetActive(true);
            return;
        }
        dialogueUI.ui.SetActive(true);
   

        MoveNarrativeForward(option);
        
        PrepareNarrativeArea();
        RunNarrativeItem();
    }

    private void MoveNarrativeForward(int option) {
        if (option == -1) return;
        if ((option==1 && currentNarrativeItem.next2==null) || currentNarrativeItem.next1.narrativeItem == null) {
            Debug.LogWarning($"Current narrative doesn't have a next at index {option}");
        }

        NextNarrative next = option == 0 ? currentNarrativeItem.next1 : currentNarrativeItem.next2;
        SaveChoice(next);
        Debug.Log(currentNarrativeItem+"    "+historyManager);
        
        historyManager.Add(currentNarrativeItem.name,(currentNarrativeItem.character !=null?currentNarrativeItem.character.name:""),currentNarrativeItem.line);
        currentNarrativeItem = next.narrativeItem;
    }
    
    private void SaveChoice(NextNarrative next) {
        _narrativeHistory.AddNarrativeHistory(currentNarrativeItem,next);
    }

    public void GoBack() {
        if( _narrativeHistory.positiveValue.ContainsKey(currentNarrativeItem.name)) {
            _narrativeHistory.positiveActions -= _narrativeHistory.positiveValue[currentNarrativeItem.name];
            _narrativeHistory.choices--;
        }
        currentNarrativeItem = _narrativeHistory.linearHistory[^1];
        historyManager.Remove(currentNarrativeItem.name);

        _narrativeHistory.linearHistory.RemoveAt(_narrativeHistory.linearHistory.Count-1);
        AdvanceNarrative(-1);
    }
    

    private void PrepareNarrativeArea() {
        if(currentNarrativeItem.next1 == null && currentNarrativeItem.next2 == null) return;
        characterImage.sprite = null;
        characterImage.color=Color.clear;

        SetSpokenTextDefaults();
    }

    private void StopPreviousItem() {
        if(_audioCoroutine != null) {
            StopCoroutine(_audioCoroutine);
        }        
        if(audioSource != null) {
            audioSource.Stop();
        }        
    }

    private void RunNarrativeItem() {
        if (currentNarrativeItem == null) return;
       
        
        if(currentNarrativeItem.name.Equals("O1")) {
            dialogueUI.backButton.gameObject.SetActive(false);
        } else if (!dialogueUI.backButton.gameObject.activeSelf) {
            dialogueUI.backButton.gameObject.SetActive(true);
        }
        
        // update text area
        UpdateSpokenText(); 
        SetupCharacter();


        // update background
        background.sprite = currentNarrativeItem.background;
        _audioCoroutine=StartCoroutine(PlayAudioClips());

        
        
    }
    private void UpdateSpokenText() {
        SetupText();
        background.sprite = currentNarrativeItem.background;

        // FIXME Look into this a bit more
        if (currentNarrativeItem.next2 != null) {
            dialogueUI.multiDialogueChoicePanel.SetActive(true);
            dialogueUI.dialogueNavigationButtonPanel.SetActive(false);
            dialogueUI.multiDialogueChoice1.text = currentNarrativeItem.next1.shortenedLine;
            dialogueUI.multiDialogueChoice2.text = currentNarrativeItem.next2.shortenedLine;
        } 

    }

    private void SetupText() {
        if (currentNarrativeItem.dialogueType.Equals(DialogueType.Internal)) {
            dialogueUI.lineText.fontStyle = FontStyles.Italic;
        }
        if (currentNarrativeItem.dialogueType.Equals(DialogueType.Physical)) {
            dialogueUI.lineText.fontStyle = FontStyles.Bold;
        }
        dialogueUI.lineText.text = currentNarrativeItem.line;
        dialogueUI.animateIn.AnimateText();
        dialogueUI.characterName.text = currentNarrativeItem.character != null
            ? $"{currentNarrativeItem.character.name}: {currentNarrativeItem.character.title}"
            : "";
    }

    private void SetSpokenTextDefaults() {
        dialogueUI.multiDialogueChoicePanel.SetActive(false);
        dialogueUI.dialogueNavigationButtonPanel.SetActive(true);
        dialogueUI.nextButton.transform.gameObject.SetActive(true);
        dialogueUI.lineText.fontStyle = FontStyles.Normal;
    }

    private IEnumerator PlayAudioClips() {
        foreach (AudioClip clip in currentNarrativeItem.sounds) {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitWhile(() => audioSource.isPlaying);
        }
    }

    public void SetupCharacter() {
        if (currentNarrativeItem.characterArt == CharacterEnum.None) {
            characterCanvas.SetActive(false);

        }

        // var sprite = characters.Find((c)=>c.name.Equals("Rob")).sprite;
        // switch (currentNarrativeItem.characterArt) {
        //     default:
        //         throw new ArgumentOutOfRangeException();
        // }
        // characterCanvas.SetActive(true);
        // characterImage.rectTransform.sizeDelta = sprite.bounds.size*20;
        // characterImage.sprite = sprite;
        // characterImage.color=Color.white;
        //
    }



}
