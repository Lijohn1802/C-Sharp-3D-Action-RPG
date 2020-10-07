using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&CraftingPanelSetActive.craftpanel==false)
        {
            pause();
        }
    }
public GameObject pausemenu;

public static bool paused = false;
    public void pause()
    {   if(CraftingPanelSetActive.craftpanel==false)
        {    
            FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundOpen");
            paused = true;
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = false;
            Time.timeScale = 1f;
            pausemenu.SetActive(false);
        }*/
    }
}
