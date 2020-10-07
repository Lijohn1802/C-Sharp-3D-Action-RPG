using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        CharacterStats player = hitInfo.GetComponent<CharacterStats>();

        if(player!=null)
        {
            player.TakeDamage(800f);
            //Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitEnemy");
            //FindObjectOfType<AudioManager>().PlayPlayerSound("ZombieMoan");
        }
    }
}
