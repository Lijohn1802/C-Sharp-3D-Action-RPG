using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOwn : MonoBehaviour
{
    public float damage = 10f; 
    public float range = 100f; 
    public GameObject barrel;
    public Camera cam;
    //public Animator pistolanim;
    public Animator playeranim;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    //public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    //public Transform casingExitLocation;
    public float shotPower = 100f;
    private float waittillnextfire;
    private float currentAmmo;
    public float firespeed;
    public float maxammo;
    public int maxclipammo;
    private void Start() 
    {
        currentAmmo = maxclipammo;
    }
    void Update()
    {
        waittillnextfire -= Time.deltaTime * firespeed;
        if(waittillnextfire <= 0 && currentAmmo>0 && Input.GetMouseButton(0))
        {
            Shoot();
            CasingRelease();
            //pistolanim.SetTrigger("Fire");
            waittillnextfire = 1;
            currentAmmo--;
        }
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo<maxclipammo && maxammo>0)
        {
            StartCoroutine(Reload());
        }
        if(currentAmmo<=0 && maxammo>0)
        {
            StartCoroutine(Reload());
            //currentAmmo = maxAmmo;
        }
        
    }

    public void Shoot()
    {
        FindObjectOfType<AudioManager>().PlayPlayerSound("Pistol");
        FindObjectOfType<AudioManager>().PlayPlayerSound("PistolStreet");
        //GameObject tempFlash;
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
    }

    void CasingRelease()
    {
         GameObject casing;
        //casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }
    private bool isReloading;
    public float reloadtime; 
    IEnumerator Reload()
    {
        playeranim.SetTrigger("Reloading");
        isReloading = true;
        FindObjectOfType<AudioManager>().PlayPlayerSound("Reload");
        yield return new WaitForSeconds(reloadtime);
        if((maxclipammo-currentAmmo)<maxammo)
        {
            isReloading = false;
            maxammo = maxammo - (maxclipammo - currentAmmo);
            currentAmmo = currentAmmo + (maxclipammo - currentAmmo);
        }
        if((maxclipammo-currentAmmo)>=maxammo && isReloading == true)
        {
            currentAmmo = currentAmmo + maxammo;
            maxammo = 0;
            isReloading = false;
        }
    }
}
