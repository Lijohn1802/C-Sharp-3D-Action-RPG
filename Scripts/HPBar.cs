using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    public Slider hp;
    public GameObject player;

    public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = (player.GetComponent<CharacterStats>().currentHealth/player.GetComponent<CharacterStats>().maxHealth)*100; 
        HPText.text = " " + (player.GetComponent<CharacterStats>().currentHealth) + "/" + (player.GetComponent<CharacterStats>().maxHealth);
    }
}
