using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum CharacterSelect
//{
//    Default = 1, // no special attributes
//    Alive = 2, // have five max life instead of three
//    Fast = 3 // can fill ten percent of the dash gauge every time you kill enemy
//};

public class CharacterSelection : MonoBehaviour
{
    [Header ("Character")]    
    public Sprite[] playerSelectionSprites;
    public Sprite[] onScenePlayerSprites;
    public SpriteRenderer characterImage;

    [Header("Values")]
    public int currentCharacterIndex = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter(int characterIndex)
    {
        //if (selectIndex == 0)
        //    GameManager.Instance.player.SetPlayerParameters(3, 1);
        //else if (selectIndex == 1)
        //    GameManager.Instance.player.SetPlayerParameters(5, 1);
        //else if (selectIndex == 2)
        //    GameManager.Instance.player.SetPlayerParameters(3, 2);

        if (characterIndex == 0)
        {
            //GameManager.Instance.player.SetPlayerParameters(3, 1,)
        }
        else if (characterIndex == 1)
        {

        }
        else
        {

        }

    }

    public void OnSelectGameButtonPressed()
    {

    }

    public void OnLeftButtonPressed()
    {
        // back to previous character

        if (currentCharacterIndex <= 0 && currentCharacterIndex == 0)
        {
            currentCharacterIndex = playerSelectionSprites.Length - 1;
            characterImage.sprite = playerSelectionSprites[currentCharacterIndex];
        }
        else
        {
            characterImage.sprite = playerSelectionSprites[--currentCharacterIndex];
            currentCharacterIndex %= playerSelectionSprites.Length;
        }
    }

    public void OnRightButtonPressed() 
    {
        // go to next character

        if (currentCharacterIndex >= playerSelectionSprites.Length - 1)
        {
            currentCharacterIndex = 0;
            characterImage.sprite = playerSelectionSprites[currentCharacterIndex];
        }
        else
        {
            characterImage.sprite = playerSelectionSprites[++currentCharacterIndex];
            currentCharacterIndex %= playerSelectionSprites.Length;
        }
    }


}
