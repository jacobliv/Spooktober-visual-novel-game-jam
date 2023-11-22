using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using STOP_MODE = FMODUnity.STOP_MODE;

public class NarrativeManager : MonoBehaviour {
    #region Dialogue

    [Header("Dialogue")] 
    [SerializeField] private SpokenTextCanvas dialogueUI;
    #endregion
    
    #region General
    [Header("General")]
    [SerializeField] public GameObject rigorMortisCanvas;
    public NarrationItem deadEnd;
    public SliderManager rigorMortisSlider;
    public Image         characterImage;
    public string        startingNarrative;
    public NarrationItem currentNarrativeItem;
    public GameObject    creditsCanvas;

    #endregion

    #region Background

    [Header("Background")] 
    public GameObject currentBackground;
    public BackgroundManager        backgroundManager;

    #endregion
    #region Audio
    [Header("Audio")]
    public  AudioSource             audioSource;
    private        Coroutine          _sfxCoroutine;
    public         SoundList          soundList;
    public         StudioEventEmitter fmodEmitter;
    private static EventInstance      sfx_control;

    #endregion
    
    #region Multi Choice Dialogue

    [Header("Multiple Choice Dialogue")] 
    public TextMeshProUGUI first;
    public TextMeshProUGUI second;
    public GameObject      multipleChoiceCanvas;
    #endregion
    
    [Header("History")] public AddAndRemoveHistory historyManager;
    private                    NarrativeHistory    _narrativeHistory;

    private Dictionary<string, int[]> values = new Dictionary<string, int[]> {
        // 2,5
        {"[D2O-14a]", new []{2,5}},
        {"[D2O-24a]", new []{2,2}},
        {"[D2O-67a]", new []{5,3}},
        {"[D2O-82a]", new []{5,3}},
        //2,8
        {"[D3O-12a]", new []{2,0}},
        {"[D3C1-2a]", new []{8,3}},
        {"[D3O-25a]",new []{2,8}},
    };
// Normal all the way : 2, 2, 3, 3, 2, 2 = 14
// Bad all the way: 5, 2, 5, 5
    /*
     [D2O-14]
 Focus on the Voices - Normal 2
 Ignore the Voices  - Bigger 5

[D2O-24]
 Apartment #518 - Normal 2
 Apartment #519 - Normal 2

[D2O-67]
Try to Explain - Larger 5
RUN. - More than Normal (Less than 1st option) 3

[D2O-82]
Forget the leg! - Larger 5
Put it back on. - More than normal (Less than 1st Option) 3

[D3O-12]
Call Leah - Normal 2
Screw the Gate! - No Change 0

[D3C1-2]
Drive through the gate. - Larger Amount 8
Climb over the gate. -  More than normal (Slightly less than the other) 3

[D3O-25a]
Knock Calmly - Normal 2
Kick It Back Down! - Larger 8

[D3O-79b]
Make it Stop - No change
Step Back -  No change*/
    
    private void Start() {
        _narrativeHistory = GetComponent<NarrativeHistory>();
        _narrativeHistory.Reset();
        currentNarrativeItem = FindStartNarrative();
        PrepareNarrativeArea();
    
        RunNarrativeItem();
    }

    private NarrationItem FindStartNarrative() {
        NarrationItem narrationItem= Resources.Load("Narrative/"+startingNarrative) as NarrationItem;

        // string assetPath = AssetDatabase.FindAssets($"t:NarrationItem {startingNarrative} dir:Narrative")
        //     .Select(AssetDatabase.GUIDToAssetPath)
        //     .FirstOrDefault();
        //
        // if (string.IsNullOrEmpty(assetPath)) {
        //     throw new FileNotFoundException($"Couldn't find the narrative item {startingNarrative}");
        // }

        return narrationItem;
    
    }

    public void AdvanceNarrative(int option = 0) {
        StopPreviousItem();
        if (currentNarrativeItem.next1.narrativeItem == null && currentNarrativeItem.next2.narrativeItem == null) {
            creditsCanvas.SetActive(true);
            return;
        }
        dialogueUI.ui.SetActive(true);
        if (currentNarrativeItem.next2.narrativeItem != null && values.ContainsKey(currentNarrativeItem.id)) {
            int value = values[currentNarrativeItem.id][option];
            rigorMortisSlider.IncrementBar(value);
            

            
        }
        

        MoveNarrativeForward(option);
        
        PrepareNarrativeArea();
        RunNarrativeItem();
    }

    private void MoveNarrativeForward(int option) {
        if (option == -1) return;
        if ((option==1 && currentNarrativeItem.next2.narrativeItem==null) || currentNarrativeItem.next1.narrativeItem == null) {
            Debug.LogWarning($"Current narrative doesn't have a next at index {option}");
        }
        historyManager.Add(currentNarrativeItem.name,(currentNarrativeItem.character !=null?currentNarrativeItem.character.name:
                               currentNarrativeItem.unknownCharacter?"???":""),currentNarrativeItem.line);
        if (rigorMortisSlider.currentVal >= rigorMortisSlider.totalValue) {
            currentNarrativeItem = deadEnd;

        }
        else {
            NextNarrative next = option == 0 ? currentNarrativeItem.next1 : currentNarrativeItem.next2;
            SaveChoice(next);
            currentNarrativeItem = next.narrativeItem;

        }
        
        
    }
    
    private void SaveChoice(NextNarrative next) {
        _narrativeHistory.AddNarrativeHistory(currentNarrativeItem,next);
    }

    public void CloseMulti() {
        multipleChoiceCanvas.SetActive(false);
    }
    public void GoBack() {
        if( _narrativeHistory.positiveValue.ContainsKey(currentNarrativeItem.name)) {
            rigorMortisSlider.IncrementBar(-_narrativeHistory.positiveValue[currentNarrativeItem.name]);
            _narrativeHistory.choices--;
        }
        currentNarrativeItem = _narrativeHistory.linearHistory[^1];
        historyManager.Remove(currentNarrativeItem.name);

        _narrativeHistory.linearHistory.RemoveAt(_narrativeHistory.linearHistory.Count-1);
        AdvanceNarrative(-1);
    }
    

    private void PrepareNarrativeArea() {
        if(currentNarrativeItem.next1.narrativeItem == null && currentNarrativeItem.next2.narrativeItem == null) return;
        characterImage.sprite = null;
        characterImage.color=Color.clear;
        if(currentBackground!=null) {
            // currentBackground.GetComponent<FadeInAndOutBackground>().FadeOut();
        }

        SetSpokenTextDefaults();
    }

    private void StopPreviousItem() {
        if(_sfxCoroutine != null) {
            StopCoroutine(_sfxCoroutine);
        }        
        if(audioSource != null) {
            audioSource.Stop();
        }        
    }

    private void RunNarrativeItem() {
        if (currentNarrativeItem == null) return;
        if (currentNarrativeItem.id.Equals("[D1SG-44]")) {
            rigorMortisCanvas.SetActive(true);
        }
        
        if(currentNarrativeItem.name.Equals("O1")) {
            dialogueUI.backButton.gameObject.SetActive(false);
        } else if (!dialogueUI.backButton.gameObject.activeSelf) {
            dialogueUI.backButton.gameObject.SetActive(true);
        }

        // if (currentBackground != null) {
        //     currentBackground.GetComponent<FadeInAndOutBackground>().FadeOut();
        //
        // }

        backgroundManager.Manage(currentNarrativeItem);
        // currentBackground = backgroundArt.Find(ba=>ba.art.Equals(currentNarrativeItem.background)).gameObject;
        // currentBackground.GetComponent<FadeInAndOutBackground>().FadeIn();
        UpdateOnScreenCharacters();
        // update text area
        UpdateSpokenText(); 
        SetupCharacter();

        _sfxCoroutine=StartCoroutine(PlaySFXAudioClips());
        ControlBackgroundMusic.instance.ChangeSong(currentNarrativeItem.music);
        ControlBackgroundMusic.instance.ChangeAmbient(currentNarrativeItem.ambience);

    }

    private void UpdateOnScreenCharacters() {
        // update whoever is showing on screen
        // update whoever is active in current background/scene for shading
        // update character expressions
        // backgroundManager.ManageCharacters(currentNarrativeItem,characterArtList);
        // if (currentBackground.TryGetComponent(typeof(CharacterPositionManager), out var positionManager)) {
        //     ((CharacterPositionManager)positionManager).ManagePositions(currentNarrativeItem, characterArtList);
        //     currentBackground.GetComponent<ActiveCharacterShading>().MakeActive(currentNarrativeItem);
        //
        // }
    }

    private void UpdateSpokenText() {
        SetupText();

        // FIXME Look into this a bit more
        if (currentNarrativeItem.next2.narrativeItem != null) {
            multipleChoiceCanvas.SetActive(true);
            first.text = currentNarrativeItem.next1.shortenedLine;
            second.text = currentNarrativeItem.next2.shortenedLine;
            
        } 

    }

    private void SetupText() {
        // if (currentNarrativeItem.dialogueType.Equals(DialogueType.Internal)) {
        //     dialogueUI.lineText.fontStyle = FontStyles.Italic;
        // }
        // if (currentNarrativeItem.dialogueType.Equals(DialogueType.Physical)) {
        //     dialogueUI.lineText.fontStyle = FontStyles.Bold;
        // }
        if(currentNarrativeItem.next1.narrativeItem!=null && currentNarrativeItem.next2.narrativeItem==null) {
            dialogueUI.lineText.text = currentNarrativeItem.line;
        }   
        dialogueUI.animateIn.AnimateText();
        dialogueUI.characterName.text = currentNarrativeItem.character != null
            ? $"{currentNarrativeItem.character.name}"
            : currentNarrativeItem.unknownCharacter?"???":"";
    }

    private void SetSpokenTextDefaults() {
        multipleChoiceCanvas.SetActive(false);
        dialogueUI.dialogueNavigationButtonPanel.SetActive(true);
        dialogueUI.nextButton.transform.gameObject.SetActive(true);
        dialogueUI.lineText.fontStyle = FontStyles.Normal;
    }

    private IEnumerator PlaySFXAudioClips() {
        foreach (Sounds clip in currentNarrativeItem.sounds) {
            Sound sound = soundList.sounds.Find(s => s.sound.Equals(clip));
            if(sound == null) continue;
            EventReference eventReference = EventReference.Find($"event:/SFX/{clip.ToString().ToLower()}");
            


            sfx_control.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            sfx_control = RuntimeManager.CreateInstance(eventReference.Path);
            sfx_control.start();
            sfx_control.release();
            
            
            
            yield return null;
        }
    }

    public void SetupCharacter() {
        // if (currentNarrativeItem.characterArt == Art.NA) {
        //     characterCanvas.SetActive(false);
        //
        // }

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
