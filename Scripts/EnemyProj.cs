using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProj : MonoBehaviour
{
    public static int damage = 5;
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 6f);
    }
    public GameObject TookHitPrefab;
        public GameObject ExplosivePrefab;
        public GameObject itemprefab;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Player"))
        {
        CharacterStats player = hitInfo.GetComponent<CharacterStats>();
        if(player!=null)
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitEnemy");
            //FindObjectOfType<AudioManager>().PlayPlayerSound("ZombieMoan");
        }
        }
        if(hitInfo.CompareTag("MetalObj"))
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("MetalProj");
            GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
            Destroy(blood, 2f);
            Instantiate(itemprefab, new Vector3 (this.transform.position.x + 25,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        }
/*
        if(hitInfo.CompareTag("ExplosiveBarrel"))
        {
                    GameObject explosion = Instantiate(ExplosivePrefab, transform.position, Quaternion.identity);        
                    Destroy(explosion, 2f);
            Destroy(hitInfo.gameObject);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("Explosive");
        }*/
    }
}