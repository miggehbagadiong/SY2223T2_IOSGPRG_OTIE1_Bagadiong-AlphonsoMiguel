using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : Singleton<CanvasManager>
{
    public Canvas characterSelectionCanvas;
    public Canvas gameCanvas;

    public void StartCharacterSelection()
    {
        characterSelectionCanvas.enabled = true;
        gameCanvas.enabled = false;
    }

    public void StartGame()
    {
        characterSelectionCanvas.enabled = false;
        gameCanvas.enabled = true;
    }

}
