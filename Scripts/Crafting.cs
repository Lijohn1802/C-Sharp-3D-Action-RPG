using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crafting : MonoBehaviour
{
    public GameObject craftingpanel;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            exitcrafting();
        }
    }

    public void exitcrafting()
    {
        FindObjectOfType<AudioManager>().PlayPlayerSound("ButtonSoundClose");
        Time.timeScale = 1f;
        craftingpanel.SetActive(false);
        Cursor.visible = false;
        crosshair.gameObject.SetActive(true);
        CraftingPanelSetActive.craftpanel = false;
    }

    public void craftbullets()
    { 
        if(Metalss.metal<5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Error");
        }
        if(Metalss.metal>=5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Blacksmith");
            Metalss.metal = Metalss.metal - 5;
            Shooting.maxammo = Shooting.maxammo + 10;
        }
    }
public Item ak47;
    public void craftAK47()
    { 
        if(Metalss.metal<50 || Metalss.wood<10 || Metalss.crystal<1)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Error");
        }
        if(Metalss.metal>=50 && Metalss.wood>=10 && Metalss.crystal>=1)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Blacksmith");
            Metalss.metal = Metalss.metal - 50;
            Metalss.wood = Metalss.wood - 10;
            Metalss.crystal = Metalss.crystal - 1;
            Inventory.instance.Add(ak47);
        }
    }
    public void craftgrenade()
    { 
        if(Metalss.metal<5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Error");
        }
        if(Metalss.metal>=5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Blacksmith");
            Metalss.metal = Metalss.metal - 5;
            Shooting.maxammo3 = Shooting.maxammo3 + 1;
        }
    }
    public GameObject WoodWall;
    public void craftwoodwall()
    { 
        if(Metalss.wood<5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Error");
        }
        if(Metalss.wood>=5)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("Blacksmith");
            Metalss.wood = Metalss.wood - 5;
            Instantiate(WoodWall, GameObject.FindGameObjectWithTag("Player").transform.position,Quaternion.Euler(GameObject.FindGameObjectWithTag("Player").transform.rotation.z,90,-90));
        }
    }
}
