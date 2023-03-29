using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [Header("Aim Components")]
    public float offSet;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // link to this: https://github.com/Pinakineman/Rotae-an-object-using-joystick-in-unity-2D/blob/master/Boring%20code%20(main%20one%20).txt
        
        Vector3 rotMove = (Vector3.up * PlayerManager.Instance.pAimJoystick.Horizontal + Vector3.left * PlayerManager.Instance.pAimJoystick.Vertical) - transform.position;
        float angle = Mathf.Atan2(PlayerManager.Instance.pAimJoystick.Vertical, PlayerManager.Instance.pAimJoystick.Horizontal) * Mathf.Rad2Deg;

        if (PlayerManager.Instance.pAimJoystick.Horizontal != 0 || PlayerManager.Instance.pAimJoystick.Vertical != 0)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, rotMove);
            transform.rotation = Quaternion.AngleAxis(angle + offSet, Vector3.forward);
        }

    }
}
