using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public GameObject ExplosivePrefab;
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        if(hitInfo.CompareTag("Bullet")||hitInfo.CompareTag("Explosive"))
        {
            GameObject explosion = Instantiate(ExplosivePrefab, transform.position, Quaternion.identity);        
            Destroy(explosion, 2f);
            //Destroy(hitInfo.gameObject,0.1f);
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("Explosive");
        }
    }
}
