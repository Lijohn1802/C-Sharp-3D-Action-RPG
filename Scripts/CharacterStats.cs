using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine.UI;
public class CharacterStats : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth { get; private set;}
    public Stat Damage;
    public Stat Armor;
    
    Freezer _freezer;

    public GameObject TookHitPrefab;
    public GameObject chargraphic;
    public GameObject exp;
    public Animator anim;
    private Quaternion iniRot;
    public Animator animshad;

    
    void Awake()
    {
        exp = GameObject.Find("EXP Bar");
        currentHealth = maxHealth + score*10;
        //this.transform.localScale = new Vector3 (1+(score*0.005f),1+(score*0.005f),1+(score*0.005f));

        GameObject mgr = GameObject.FindWithTag("Manager");
        if(mgr)
        {
            _freezer = mgr.GetComponent<Freezer>();
        }

        iniRot = floatingtextprefab.transform.rotation;
    }  
    public GameObject floatingtextprefab;
    public float totaldamage;
    public float timesincehit=3;
    public void Update()
    {
        timesincehit = timesincehit - Time.deltaTime;
        if(timesincehit<=0)
        {
            floatingtextprefab.SetActive(false);
        }
    }
    private void LateUpdate() 
    {
        floatingtextprefab.transform.rotation = iniRot;
    }
    public void TakeDamage(float Damage)
    {
        timesincehit=3f;
        Damage -= Armor.GetValue();
        Damage = Mathf.Clamp(Damage, 0, int.MaxValue);
        currentHealth -= Damage;
       // Debug.Log(transform.name + "takes" + Damage + "damage" + "CurrentHP = " + currentHealth);
        GameObject blood = Instantiate(TookHitPrefab, transform.position, Quaternion.identity);
        totaldamage = totaldamage + Damage;
        floatingtextprefab.GetComponent<TextMesh>().text = totaldamage.ToString();
        Destroy(blood, 2f);
        LeanTween.color(chargraphic, Color.white, 0.04f).setRepeat(2).setLoopPingPong();
        //GameObject floatingtext = Instantiate(floatingtextprefab, transform.position, Quaternion.identity);
        floatingtextprefab.SetActive(true);
        floatingtextprefab.GetComponent<MeshRenderer> ().sortingOrder = 100;
        //LeanTween.moveY(floatingtextprefab, transform.position.y + 3f,3f);
        //exp.AddExp();
        exp.GetComponent<Expbar>().AddExp();
        if(this.gameObject.tag == "Player")
        {
            StartCoroutine(Knockback());
        }
        if(currentHealth<=0)
        {
            Die();
        }
    }
    IEnumerator Knockback()
    {
        PlayerMovement.moveSpeed = 0;
        yield return new WaitForSeconds(0.25f);
        PlayerMovement.moveSpeed = 20;
    }
    public void incHP()
    {
        if(this.gameObject.tag == "Player" && Moneys.money >=5)
        {
            Moneys.money -=5;
            //maxHealth += 10;
            currentHealth += 10;
        }
    }
    public void incDamage()
    { 
        if(this.gameObject.tag == "Player" && Expbar.sp>=1)
        {
            Projectile.damage +=5;
            Expbar.sp--;
        }
    }
    AIPath aipath;
    public GameObject itemprefab;
   public GameObject itemprefab2;
    public GameObject itemprefab3;
    public GameObject itemprefab4;
    public static float score;
    public Sprite Deathsprite;
    public bool dead = false;
    public virtual void Die()
    {
        _freezer.Freeze();
        if(this.gameObject.transform.GetChild(0).gameObject.tag == "BigBoss")
        {
            Instantiate(itemprefab, new Vector3 (this.transform.position.x + 5,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            Instantiate(itemprefab, new Vector3 (this.transform.position.x + 5,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            Instantiate(itemprefab, new Vector3 (this.transform.position.x + 5,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            Instantiate(itemprefab4, new Vector3 (this.transform.position.x + 2,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            Instantiate(itemprefab4, new Vector3 (this.transform.position.x - 2,this.transform.position.y,this.transform.position.z),Quaternion.identity);
            Instantiate(itemprefab3, new Vector3 (this.transform.position.x - 5,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        }
        if(this.gameObject.transform.GetChild(0).gameObject.tag == "GreenGuy")
        {
            Instantiate(itemprefab2, new Vector3 (this.transform.position.x + 1,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        }
        Instantiate(itemprefab, new Vector3 (this.transform.position.x + 1,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        //Instantiate(itemprefab2, new Vector3 (this.transform.position.x - 1,this.transform.position.y,this.transform.position.z),Quaternion.identity);
        //this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        //anim.SetBool("Dead", true);
        //animshad.SetBool("Dead", true);
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Deathsprite;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Deathsprite;
        this.transform.GetChild(2).gameObject.SetActive(false);
        if(this.gameObject.tag == "Player")
        {
            dead = true;
            this.gameObject.GetComponent<PlayerMovement>().enabled = false;
            this.gameObject.GetComponent<Shooting>().enabled = false;
            GameObject.Find("GUI").transform.Find("Death").gameObject.SetActive(true);
            GameObject.Find("RightSpawn").gameObject.GetComponent<Spawner>().CancelInvoke();
            FindObjectOfType<AudioManager>().PlayPlayerSound("PlayerHurt");
            GameObject.Find("GUI").transform.Find("Ammo").gameObject.SetActive(false);
        }
        Destroy(this.gameObject.GetComponent<Rigidbody2D>());     
        Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        //Destroy(this);
        if(this.gameObject.tag == "Enemy")
        {
        aipath = GetComponent<AIPath>();
        aipath.enabled = false;
        score++;
        Destroy(this.gameObject.transform.GetChild(0).GetComponent<CircleCollider2D>());
        FindObjectOfType<AudioManager>().PlayPlayerSound("EnemyDeath");
        Destroy(gameObject,45f);
        this.transform.GetChild(3).gameObject.SetActive(false);
        //this.GetComponent<SpriteRenderer>().sortingOrder = 2; 
        }
    }    
    /*public static int prevscore = 0;
    public void update()
    {
        if(score > prevscore + 10)
        {
            Debug.Log("Harder");
            prevscore = score;
            if(this.gameObject.tag == "Enemy")
            {
                 currentHealth += score; 
            }
        }
        //this.GetComponent<SpriteRenderer>().sortingOrder = 2; 
    }*/
}
