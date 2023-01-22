using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SwipeController : Singleton<SwipeController>
{
    //Swipe Controls
    Vector2 startTapPos;
    Vector2 endTapPos;
    public bool isTapped = false;

    [SerializeField] float tapRange = 10;
    [HideInInspector] public string swipeDir;

    void Start()
    {
            
    }

    void Update()
    {
#if UNITY_EDITOR
        EditorInput();
#elif UNITY_ANDROID
        DeviceInput();
#endif
    }

    #region Device Inputs
    void EditorInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTapPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTapPos = Input.mousePosition;

            Vector2 v2 = endTapPos - startTapPos;

            if (v2.magnitude > tapRange) 
            {
                Swipe(v2);
            } 
            else
            {
                Tap();
            }
        }
    }

    void DeviceInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                startTapPos = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTapPos = Input.GetTouch(0).position;

                Vector2 v2 = endTapPos - startTapPos;

                if (v2.magnitude > tapRange)
                {
                    Swipe(v2);
                }
                else
                {
                    Tap();
                }
            }
 
        }
    }

    #endregion

    void Swipe(Vector2 vec2)
    {
        float vecX = vec2.x;
        float vecY = vec2.y;

        if (Math.Abs(vecX) > Mathf.Abs(vecY))
        {
            // Left and Right
            if (vecX < 0)
            {
                Debug.Log("Swiped Left!");
                swipeDir = "Left";
                UiManager.Instance.swipeDirTxt.text = swipeDir;

            }
            else
            {
                Debug.Log("Swiped Right");
                swipeDir = "Right";
                UiManager.Instance.swipeDirTxt.text = swipeDir;
            }
        }
        else
        {
            // Down and Up
            if (vecY < 0)
            {
                Debug.Log("Swiped Down");
                swipeDir = "Down";
                UiManager.Instance.swipeDirTxt.text = swipeDir;
            }
            else
            {
                Debug.Log("Swiped Up!");
                swipeDir = "Up";
                UiManager.Instance.swipeDirTxt.text = swipeDir;
            }
        }


    }

    void Tap()
    {
        Debug.Log("Tapped!");
        swipeDir = "Tap";

        UiManager.Instance.swipeDirTxt.text = swipeDir;

        // the dash implementation may also be placed here just remember to look back here
        this.isTapped = true;
    }

    private void ResetSwipes()
    {
        // Reset the swipes back to 0
        startTapPos = Vector2.zero;
    }
}
