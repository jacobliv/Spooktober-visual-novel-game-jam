using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpokenTextCanvas : MonoBehaviour {
    public TextMeshProUGUI characterName;
    public GameObject      ui;
    public TextMeshProUGUI lineText;
    public AnimateInText   animateIn;
    public GameObject      dialogueNavigationButtonPanel;

    public Button          nextButton;
    public Button          backButton;
    
    public GameObject      multiDialogueChoicePanel;
    public TextMeshProUGUI multiDialogueChoice1;
    public TextMeshProUGUI multiDialogueChoice2;
}
