using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinRadiusofVehicle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    public static bool Inradius=false; 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Inradius = true;
        }
    }/*
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            Inradius = false;
        }
    }*/
}
