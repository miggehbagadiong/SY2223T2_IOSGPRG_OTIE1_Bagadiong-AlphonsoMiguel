using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Singleton<Dash>
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;


    void Start()
    {
        rb = GameManager.Instance.GetPlayer().GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDash();
    }

    public void UpdateDash()
    {
        if (SwipeController.Instance.isTapped == true)
        {
            StartCoroutine(StartDash());
        }
    }

    public IEnumerator StartDash()
    {
        dashTime -= (1 * Time.deltaTime);
        rb.velocity = Vector2.up * dashSpeed;

        yield return new WaitForSeconds(dashTime);

        

        dashTime = startDashTime;

        rb.velocity = Vector2.zero;
        SwipeController.Instance.isTapped = false;
    }

    public IEnumerator LongDash(float longDashTime)
    {
        longDashTime -= (1 * Time.deltaTime);
        rb.velocity = Vector2.up * dashSpeed;

        yield return new WaitForSeconds(dashTime);

        rb.velocity = Vector2.zero;
    }
}
