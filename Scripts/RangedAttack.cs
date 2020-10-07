using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void shoot()
    {
        GameObject bulleter = Instantiate(Projectilees, this.transform.position, this.transform.rotation * Quaternion.Euler(0,0,180));
        Rigidbody2D rbs = bulleter.GetComponent<Rigidbody2D>();
        rbs.AddForce(this.transform.up * bulletForce, ForceMode2D.Impulse);
    }
    public GameObject Projectilees;
    public int bulletForce;
    //private bool playInside=false;
    private void OnTriggerEnter2D(Collider2D hitInfo) 
    {
        if(hitInfo.gameObject.tag == "Player")
        {
            InvokeRepeating("shoot",1f,2);
        }
    }

    private void OnTriggerExit2D(Collider2D hitInfo) 
    {
        if(hitInfo.gameObject.tag == "Player")
        {
            CancelInvoke();
        }
    }
}
