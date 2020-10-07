using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {        
            FindObjectOfType<AudioManager>().PlayPlayerSound("PickUp");
            if(this.gameObject.tag == "GunOfIce")
            {
                Moneys.money++;
            }
            if(this.gameObject.tag == "ShieldOfFire")
            {
                Shooting.maxammo += 20;
            }
            if(this.gameObject.tag == "Metal")
            {
                Metalss.metal++;
            }
            if(this.gameObject.tag == "Wood")
            {
                Metalss.wood++;
            }
            if(this.gameObject.tag == "Crystal")
            {
                Metalss.crystal++;
            }
            if(this.gameObject.tag == "Pistol")
            {
                PickUp();
            }   
            Destroy(gameObject);
        }
    }
    void PickUp()
    {
//        Debug.Log("Picking Up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
        {

        }
    }

}
