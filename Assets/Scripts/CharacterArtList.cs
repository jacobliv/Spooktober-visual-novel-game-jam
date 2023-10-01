using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterArtList : ScriptableObject {
    [SerializeField] public List<ArtValue> characterArt;
}

[Serializable]
public class ArtValue {
    [SerializeField] public Art    art;
    [SerializeField] public Sprite sprite;
}

public enum Art{
Omar_Neutral,
    Omar_Happy,
    Omar_Shocked,
    Omar_Confused,
    Omar_Sad,
    Omar_Bashful,
    Omar_Angry,
    SG_Smirking,
    SG_Annoyed,
    SG_Neutral,
    SG_Confused,
    SG_Stern,
    SG_Shocked,
    Iggy_Neutral,
    Iggy_Fuming,
    Iggy_Excited,
    Akilla_Disgusted,
    Akilla_Outraged,
    Akilla_Annoyed,
    NA,
    Gin_Smile,
    Gin_Pondering,
    Leah_Smile,
    Leah_Confused,
    Mason_Shadow,
    Mason_Neutral,
    Mason_NoKnife,
    Edie_Neutral,
    Edie_Confused,
    Mirror_Item,
    ClosedPizza_Item,
    UnfoldedBlanket_Item,
    OpenPizza_Item,
    FoldedBlanket_Item,
    Apartment_Hallway,
    The_13th_Pizza,
    Outside_Apartment,
    Akillas_Apartment,
    Black_screen,
    Dead_Omar_CG,
    Inside_Car,
    Eat_Brains,
    OmarMirror_Item
}