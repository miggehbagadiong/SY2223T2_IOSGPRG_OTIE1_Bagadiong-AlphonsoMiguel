using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    [Header ("Character")]
    public string characterType;
    public Sprite characterSelectionSprite;
    public Sprite characterInSceneSprite;

    [Header("Components")]
    public int currentLife;
    public int maxLife;
    public int killMultiplier;
}
