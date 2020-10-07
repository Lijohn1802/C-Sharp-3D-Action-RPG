using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Moneys : MonoBehaviour
{
    public static int money;
    public Text moneyy;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "MoneyText")
        {
            moneyy.text = ": " + money.ToString();
        }

    }
}
