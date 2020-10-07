using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static int damage = 40;
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
        CharacterStats enemy = hitInfo.GetComponent<CharacterStats>();
        if(enemy!=null)
        {
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitEnemy");
            //FindObjectOfType<AudioManager>().PlayPlayerSound("ZombieMoan");
        }
        
        if(hitInfo.CompareTag("MetalObj"))
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("MetalProj");
            GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
            Destroy(blood, 2f);
            Instantiate(itemprefab, new Vector3 (this.transform.position.x + 25,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        }
    }
}