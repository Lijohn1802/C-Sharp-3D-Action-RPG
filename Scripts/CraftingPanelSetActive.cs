using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPanelSetActive : MonoBehaviour
{
    public GameObject craftingpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject dialouge;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)&&Pause.paused==false)
        {
            setactivea();
        }
    }
public static bool craftpanel;
    public void setactivea()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().dead == false && !dialouge.activeInHierarchy)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundOpen");
            craftpanel = true;
            Time.timeScale=0f;
            craftingpanel.SetActive(true);
            
        }
    }
}
