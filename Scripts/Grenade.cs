using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public static int damage = 0;
    // Update is called once per frame
    private void Start() 
    {
        Destroy(this.gameObject, 6f);
    }
    void Update()
    {
        
    }
    public GameObject TookHitPrefab;
        //public GameObject ExplosivePrefab;
        //public GameObject itemprefab;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        CharacterStats enemy = hitInfo.GetComponent<CharacterStats>();
        if(enemy!=null)
        {
            //enemy.TakeDamage(damage);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitEnemy");
            FindObjectOfType<AudioManager>().PlayPlayerSound("Explosive");
            GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(hitInfo.CompareTag("MetalObj"))
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("MetalProj");
            //Instantiate(itemprefab, new Vector3 (this.transform.position.x + 25,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            FindObjectOfType<AudioManager>().PlayPlayerSound("Explosive");
            GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(hitInfo.CompareTag("Explosive"))
        {
            FindObjectOfType<AudioManager>().PlayPlayerSound("MetalProj");
            //Instantiate(itemprefab, new Vector3 (this.transform.position.x + 25,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            FindObjectOfType<AudioManager>().PlayPlayerSound("Explosive");
            GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}