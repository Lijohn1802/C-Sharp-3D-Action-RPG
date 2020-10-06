using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrAndSkills : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("`"))
        {
            exitattrandskills();
        }
    }
    public void exitattrandskills()
    {
        //FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        //Cursor.visible = false;
        //crosshair.gameObject.SetActive(true);
        //CraftingPanelSetActive.craftpanel = false;
    }
}
