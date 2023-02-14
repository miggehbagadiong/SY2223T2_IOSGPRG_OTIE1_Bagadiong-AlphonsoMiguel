
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : Singleton<CharacterManager>
{
    public CharacterDatabase characterData;

    public SpriteRenderer selectedCharacterSprite;

    private int currCharacterIndex = 0;
    
    void Start()
    {
        UpdateCharacter(currCharacterIndex);
    }

    public void OnRightButtonPressed()
    {
        currCharacterIndex++;

        if (currCharacterIndex >= characterData.CharacterCount)
        {
            currCharacterIndex = 0;
        }

        UpdateCharacter(currCharacterIndex);
    }

    public void OnLeftButtonPressed()
    {
        currCharacterIndex--;

        if (currCharacterIndex < 0)
        {
            currCharacterIndex = characterData.CharacterCount - 1;
        }

        UpdateCharacter(currCharacterIndex);
    }

    private void UpdateCharacter(int characterIndex)
    {
        Character character = characterData.GetCharacter(characterIndex);
        selectedCharacterSprite.sprite = character.characterSelectionSprite;

    }

}
