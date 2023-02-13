using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Default = 1, // no special attributes
    Alive = 2, // have five max life instead of three
    Fast = 3 // can fill ten percent of the dash gauge every time you kill enemy
};

public class CharacterSelection : MonoBehaviour
{
    [Header ("Character")]
    public Character selectedCharacter;
    public Sprite[] playerSprites;

    [Header("Values")]
    public int selectIndex;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter()
    {
        //if (selectIndex == 0)
        //    GameManager.Instance.player.SetPlayerParameters(3, 1);
        //else if (selectIndex == 1)
        //    GameManager.Instance.player.SetPlayerParameters(5, 1);
        //else if (selectIndex == 2)
        //    GameManager.Instance.player.SetPlayerParameters(3, 2);


    }

    public void OnSelectGameButtonPressed()
    {

    }

}
