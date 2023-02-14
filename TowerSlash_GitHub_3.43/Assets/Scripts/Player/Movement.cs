using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //if (GameManager.Instance.isGameActive)
        //    MoveUp();

        MoveUp();

    }

    private void MoveUp()
    {
        float up = playerSpeed * Time.deltaTime;
        this.transform.position += new Vector3(0, up, 0);
    }
}
