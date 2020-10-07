using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (dashTime <=0)
        {
            dashTime = startDashTime;
           // rb.velocity = Vector2.zero;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            dashTime -= Time.deltaTime;
            //rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
            rb.velocity = (movement * dashSpeed);
        }
    }
}
