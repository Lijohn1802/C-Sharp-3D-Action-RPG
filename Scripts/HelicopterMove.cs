using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    Vector3 movement; 
    public Rigidbody rb;
    public float moveSpeed; 
    private GameObject playe;
    // Start is called before the first frame update
    void Start()
    {
        playe = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() 
    {
        if(WithinRadiusofVehicle.Inradius==true)
        {
            movement.x = 1 ;
            playe.transform.position = this.transform.position;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
