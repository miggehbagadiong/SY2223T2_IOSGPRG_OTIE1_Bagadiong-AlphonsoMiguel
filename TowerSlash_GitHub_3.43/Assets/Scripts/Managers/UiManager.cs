using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI swipeDirTxt;

    // Start is called before the first frame update
    void Start()
    {
        SwipeController.Instance.swipeDir = swipeDirTxt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update the swipe direction
        SwipeController.Instance.swipeDir = swipeDirTxt.ToString();
    }
}
