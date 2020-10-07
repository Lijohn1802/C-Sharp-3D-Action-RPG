using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeele : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    { 
        CharacterStats player = hitInfo.GetComponent<CharacterStats>();
        if(hitInfo.tag == "Player")
        { 
            //Debug.Log("HitPlayer");
        if(player!=null)
        {
            player.TakeDamage(damage);
            FindObjectOfType<AudioManager>().PlayPlayerSound("HitPlayer");
        }
        }
    }

  //  IEnumerator Start()
  //  {
     //   yield return new WaitForSeconds(2f);
//        this.transform.GetChild(3).gameObject.SetActive(true);
   // }
}
