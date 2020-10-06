using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActivatorScript : MonoBehaviour
{
    public GameObject craftingpanel;
    public GameObject attrandskillspanel;
    public GameObject pausemenu;
    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)/*&& Pause.paused==false*/)
        {
            SetCraftingPanelActive();
        }
        if(Input.GetKeyDown("`")/*&& Pause.paused==false*/)
        {
            SetAttrSkillsPanelActive();
        }
        if(Input.GetKeyDown(KeyCode.Escape)/*&&CraftingPanelSetActive.craftpanel==false*/)
        {
            pause();
            Cursor.lockState = CursorLockMode.None;
        }
    }
public static bool craftpanel;
    public void SetCraftingPanelActive()
    {
        //if(/*GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().dead == false && !dialouge.activeInHierarchy*/)
        {
            //FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundOpen");
            //craftpanel = true;
            Time.timeScale=0f;
            craftingpanel.SetActive(true);
        }
    }
    public void SetAttrSkillsPanelActive()
    {
        //if(/*GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().dead == false && !dialouge.activeInHierarchy*/)
        {
            //FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundOpen");
            //craftpanel = true;
            Time.timeScale=0f;
            attrandskillspanel.SetActive(true);
        }
    }
    public void pause()
    {   //if(CraftingPanelSetActive.craftpanel==false)
        //{    
            FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundOpen");
            //paused = true;
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
        //}
        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = false;
            Time.timeScale = 1f;
            pausemenu.SetActive(false);
        }*/
    }
}
