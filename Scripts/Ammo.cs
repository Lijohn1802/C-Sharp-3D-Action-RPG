using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ammo : MonoBehaviour
{
    public Text ammo;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        if(player.transform.GetChild(0).gameObject.activeSelf)
        {
            ammo.text = player.GetComponent<Shooting>().currentAmmo2.ToString() + "/" + Shooting.maxammo2.ToString();
        }
        if(player.transform.GetChild(1).gameObject.activeSelf)
        {
            ammo.text = player.GetComponent<Shooting>().currentAmmo.ToString() + "/" + Shooting.maxammo.ToString();
        }        
        if(player.transform.GetChild(4).gameObject.activeSelf)
        {
            ammo.text = Shooting.maxammo3.ToString();
        }
        if(player.transform.GetChild(5).gameObject.activeSelf)
        {
            ammo.text = "---";
        }
    }
}
