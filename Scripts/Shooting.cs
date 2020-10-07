using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletForce = 20f;
    public float waittillnextfire;
    public static float firespeed = 6.5f;
    public int maxAmmo = 25;
    public int currentAmmo;
    public float reloadtime;
    
    private bool isReloading = false;
    private bool isReloading2 = false;
    public GameObject muzzlelight;

    public int currentAmmo2;
    public int maxAmmo2 = 8;
    public static int maxammo2=99;

    public int maxAmmo3 = 1;
    // Start is called before the first frame update
    public SimpleCameraShakeInCinemachine shaker;
    void Start()
    {
        currentAmmo = maxAmmo;
        currentAmmo2 = maxAmmo2;
        currentAmmo3 = maxAmmo3;
        LeanTween.alphaText(Reloading.GetComponent<RectTransform>(), 0f, 0.5f).setLoopPingPong();
    }
public GameObject Crosshair;
public static int maxammo=75;

public static int maxammo3 = 3;
    // Update is called once per frame
    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.visible = false;
            Crosshair.gameObject.SetActive(true);
        }
        if(isReloading)
        return;         
        if(Input.GetMouseButton(0))
        {
            if(!EventSystem.current.IsPointerOverGameObject())
        {
            if (waittillnextfire <= 0 && currentAmmo>0&&this.transform.GetChild(1).gameObject.activeSelf)
            {
                Shoot();
                waittillnextfire = 1;
                shaker.Shake();
            }
            if (waittillnextfire <= 0 && currentAmmo<=0&&this.transform.GetChild(1).gameObject.activeSelf)
            {
                FindObjectOfType<AudioManager>().PlayPlayerSound("EmptyMag");
                waittillnextfire = 1;
            }
            if (waittillnextfire <= 0 && currentAmmo2>0&&this.transform.GetChild(0).gameObject.activeSelf)
            {
                Shoot2();
                waittillnextfire = 1;
                shaker.Shake();
            }
            if (waittillnextfire <= 0 && currentAmmo2<=0&&this.transform.GetChild(0).gameObject.activeSelf)
            {
                FindObjectOfType<AudioManager>().PlayPlayerSound("EmptyMag");
                waittillnextfire = 1;
            }
            if (waittillnextfire <= 0 && maxammo3>0&&this.transform.GetChild(4).gameObject.activeSelf)
            {
                Shoot3();
                waittillnextfire = 1;
                //shaker.Shake();
            }
            if (waittillnextfire <= 0 && currentAmmo3<=0&&this.transform.GetChild(4).gameObject.activeSelf)
            {
                FindObjectOfType<AudioManager>().PlayPlayerSound("EmptyMag");
                waittillnextfire = 1;
            }
            if (waittillnextfire <= 0 &&this.transform.GetChild(5).gameObject.activeSelf)
            {
                StartCoroutine(Shoot4());
                waittillnextfire = 1;

                //shaker.Shake();
            }
        }
        }
        waittillnextfire -= Time.deltaTime * firespeed;
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo<maxAmmo && maxammo>0 && this.transform.GetChild(1).gameObject.activeSelf)
        {
            StartCoroutine(Reload());
        }
        if(currentAmmo<=0 && maxammo>0 && this.transform.GetChild(1).gameObject.activeSelf)
        {
            StartCoroutine(Reload());
            //currentAmmo = maxAmmo;
        }
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo2<maxAmmo2 && maxammo2>0  && this.transform.GetChild(0).gameObject.activeSelf)
        {
            StartCoroutine(Reload2());
        }
        if(currentAmmo2<=0 && maxammo2>0 && this.transform.GetChild(0).gameObject.activeSelf)
        {
            StartCoroutine(Reload2());
            //currentAmmo = maxAmmo;
        }
        if(WithinRadiusofVehicle.Inradius==true)
        {
            this.gameObject.GetComponent<PlayerMovement>().enabled=false; 
            this.gameObject.GetComponent<CircleCollider2D>().enabled=false;
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(5).gameObject.SetActive(false);
        }  
    }
    public float bulletspread;
    void Shoot()
    {
        if(this.transform.GetChild(1).gameObject.activeSelf)
        {
            currentAmmo--;
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0,0,180));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D player = this.gameObject.GetComponent<Rigidbody2D>();
        //player.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().PlayPlayerSound("Fire");
        Muzzle();
        Shell();
    } 
    void Shoot2()
    {
        if(this.transform.GetChild(0).gameObject.activeSelf)
        {
            currentAmmo2--;
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0,0,180));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D player = this.gameObject.GetComponent<Rigidbody2D>();
        //player.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().PlayPlayerSound("Fire");
        Muzzle();
        Shell();
    } 
    public int currentAmmo3;
    public GameObject grenade;
    void Shoot3()
    {
        if(this.transform.GetChild(4).gameObject.activeSelf)
        {
            maxammo3--;
        }
        GameObject bullet = Instantiate(grenade, firePoint.position, firePoint.rotation * Quaternion.Euler(0,0,180));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 60f, ForceMode2D.Impulse);
        Rigidbody2D player = this.gameObject.GetComponent<Rigidbody2D>();
        //player.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        //FindObjectOfType<AudioManager>().PlayPlayerSound("Fire");
        //Muzzle();
        //Shell();
    }     
    public GameObject meeleindicator;
    IEnumerator Shoot4()
    { 
        GameObject meele = Instantiate(meeleindicator, new Vector3(this.transform.position.x+1,this.transform.position.y+1,this.transform.position.z), this.transform.rotation);
        Destroy(meele, 0.2f); 
        FindObjectOfType<AudioManager>().PlayPlayerSound("AxeSwing");
        if(this.transform.GetChild(5).gameObject.activeSelf)
        {
            transform.GetChild(5).GetChild(4).GetComponent<CircleCollider2D>().enabled = true;
        }
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(5).GetChild(4).GetComponent<CircleCollider2D>().enabled = false;
    } 
    public Transform shellposition;
    public GameObject shellprefab;
    private Rigidbody2D rbshell;
    public float shellspeed;
    public float shellpositionx;
    void Shell()
    {
        GameObject shell = Instantiate(shellprefab, shellposition.position, shellposition.rotation);
        Rigidbody2D rbshell = shell.GetComponent<Rigidbody2D>();
        rbshell.MovePosition(rbshell.position + new Vector2(shellpositionx,0) * shellspeed * Time.fixedDeltaTime);
        Destroy(shell,45f);
    }
    void Muzzle()
    {        
        GameObject muzzle = Instantiate(muzzlelight, firePoint.position,this.transform.rotation * Quaternion.Euler(0,0,180) );
        Destroy(muzzle,1/(firespeed*4));
    }
    public GameObject Reloading;
    IEnumerator Reload()
    {
        isReloading = true;
        FindObjectOfType<AudioManager>().PlayPlayerSound("Reload");
        //Reloading.GetComponent<Text>().color = new Color(255,255,109)
        Reloading.SetActive(true);
        yield return new WaitForSeconds(reloadtime);
        Reloading.SetActive(false);
        if((maxAmmo-currentAmmo)<maxammo)
        {
            isReloading = false;
            maxammo = maxammo - (maxAmmo - currentAmmo);
            currentAmmo = currentAmmo + (maxAmmo - currentAmmo);
        }
        if((maxAmmo-currentAmmo)>=maxammo && isReloading == true)
        {
            currentAmmo = currentAmmo + maxammo;
            maxammo = 0;
            isReloading = false;
        }
    }
    IEnumerator Reload2()
    {
        isReloading = true;
        FindObjectOfType<AudioManager>().PlayPlayerSound("Reload");
        //Reloading.GetComponent<Text>().color = new Color(255,255,109)
        Reloading.SetActive(true);
        yield return new WaitForSeconds(reloadtime);
        Reloading.SetActive(false);
        if((maxAmmo2-currentAmmo2)<maxammo2)
        {
            isReloading = false;
            maxammo2 = maxammo2 - (maxAmmo2 - currentAmmo2);
            currentAmmo2 = currentAmmo2 + (maxAmmo2 - currentAmmo2);
        }
        if((maxAmmo2-currentAmmo2)>=maxammo2 && isReloading == true)
        {
            currentAmmo2 = currentAmmo2 + maxammo2;
            maxammo2 = 0;
            isReloading = false;
        }
    }
}
