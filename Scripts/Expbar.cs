using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Expbar : MonoBehaviour
{
    public Slider expslider;
    public Text leveltext;
    public int level =1;
    public Text skillpointtext;
    public static int sp = 1;
   // public PlayerController attackdamage;
   public float exp;
    private void Update()
    {
        leveltext.text = "Level: " + level.ToString();
        skillpointtext.text = "SkillPoints: " + sp.ToString();
        if (exp >= 100*(Mathf.Pow(1.2f,level)))
        {
            exp = 0;
            expslider.value = 0;
            level++;
            sp++;
           // attackdamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            //attackdamage.levelup();
        }
        expslider.value = (exp/(100*(Mathf.Pow(1.2f,level))))*100;
    }
    /*
    public void SetMaxHealth(int exp)
    {
        expslider.maxValue = 100;
        expslider.value = 10;
    }
    */
    public void AddExp()
    {
        exp += 1;
    }
}
