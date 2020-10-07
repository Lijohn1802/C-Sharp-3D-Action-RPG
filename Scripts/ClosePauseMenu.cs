using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
     //public GameObject resume;
         public GameObject dialouge;
    public void Resume()
    {

        FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
        if(!dialouge.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
        this.gameObject.SetActive(false);
        Pause.paused=false;
    }
}
