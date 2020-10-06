using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouger dialouge;

    public void Start() 
    {/*
        if(this.gameObject.tag =="1")
        {
            Invoke("startdia",0.1f);
        }*/
        //if(this.gameObject.tag=="2Dia")
       // {
            /*this.GetComponent<DialougeTrigger>().*/Invoke("startdia",0.1f);
        //}
    }
    public void startdia()
    {
        //Time.timeScale = 0f;
        FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    }
    //public void TriggerDialouge()
    //{       FindObjectOfType<DialougeManager>().StartDialouge(dialouge);
    //}
}
