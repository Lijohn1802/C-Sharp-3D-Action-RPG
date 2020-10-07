using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Wood")
        {
            Metalss.wood ++;
            FindObjectOfType<AudioManager>().PlayPlayerSound("GetWood");
        }
        if(other.gameObject.tag == "MetalObj")
        {
            Metalss.metal ++;
            FindObjectOfType<AudioManager>().PlayPlayerSound("MetalProj");
        }
        if(other.gameObject.tag == "Stone")
        {
            Metalss.crystal ++;
            FindObjectOfType<AudioManager>().PlayPlayerSound("GetStone");
        }        
        CharacterStats enemy = other.GetComponent<CharacterStats>();
        if(enemy!=null)
        {
            enemy.TakeDamage(Projectile.damage);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitEnemy");
        }
    }
}
