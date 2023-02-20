using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    [Header ("Swipe Direction")]
    public TextMeshProUGUI swipeDirTxt;

    [Header("Rotating Arrow")]
    public TextMeshProUGUI rotArrowDirTxt;

    [Header("Score")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI killsTxt;

    [Header("Player")]
    public TextMeshProUGUI lifePointTxt;

    [Header("System")]
    public TextMeshProUGUI swipeDisabledTxt;


}
