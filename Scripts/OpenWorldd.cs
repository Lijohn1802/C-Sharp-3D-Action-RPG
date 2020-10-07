using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWorldd : MonoBehaviour
{
    public GameObject playerr;
    public GameObject[] owobjs; 
    public float rangee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject owobj in owobjs)
        {   
            float distancee = Vector2.Distance(owobj.transform.position, playerr.transform.position);
            if(distancee>rangee)
            {
                owobj.gameObject.SetActive(false);
            }
            if(distancee<rangee)
            {
                owobj.gameObject.SetActive(true);
            }
        }
    }
}
