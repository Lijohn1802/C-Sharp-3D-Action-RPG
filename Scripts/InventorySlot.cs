using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image Icon;

    Item item;
    public Sprite pistol;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)&&this.gameObject.tag=="1")
        {
            if(item.name=="Pistol")
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Shooting.firespeed = 3.0f;
                Projectile.damage = 160;
            }
            if(item.name=="Rifle")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 200;
                Shooting.firespeed = 6.5f;
            }
            if(item.name=="Grenade")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 0;
                Shooting.firespeed = 0.5f;
            }
            if(item.name=="Axe")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
                Projectile.damage = 400;
                Shooting.firespeed = 2f;
            }
        }        
        if(Input.GetKeyDown(KeyCode.Alpha2)&&this.gameObject.tag=="2")
        {
            if(item.name=="Pistol")
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Shooting.firespeed = 3.0f;
                Projectile.damage = 160;
            }
            if(item.name=="Rifle")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 200;
                Shooting.firespeed = 6.5f;
            }
            if(item.name=="Grenade")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 0;
                Shooting.firespeed = 0.5f;
            }
            if(item.name=="Axe")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
                Projectile.damage = 400;
                Shooting.firespeed = 2f;
            }
        }        
        if(Input.GetKeyDown(KeyCode.Alpha3)&&this.gameObject.tag=="3")
        {
            if(item.name=="Pistol")
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Shooting.firespeed = 3.0f;
                Projectile.damage = 160;
            }
            if(item.name=="Rifle")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 200;
                Shooting.firespeed = 6.5f;
            }
            if(item.name=="Grenade")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 0;
                Shooting.firespeed = 0.5f;
            }
            if(item.name=="Axe")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
                Projectile.damage = 400;
                Shooting.firespeed = 2f;
            }
        }        
        if(Input.GetKeyDown(KeyCode.Alpha4)&&this.gameObject.tag=="4")
        {
            if(item.name=="Pistol")
            {
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Shooting.firespeed = 3.0f;
                Projectile.damage = 160;
            }
            if(item.name=="Rifle")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 200;
                Shooting.firespeed = 6.5f;
            }
            if(item.name=="Grenade")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                Projectile.damage = 0;
                Shooting.firespeed = 0.5f;
            }
            if(item.name=="Axe")
            {            
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).gameObject.SetActive(true);
                Projectile.damage = 400;
                Shooting.firespeed = 2f;
            }
        }        
        if(Input.GetKeyDown(KeyCode.Alpha5)&&this.gameObject.tag=="5")
        {
            Debug.Log("Change Sprite and add meele");
            //UseItem();
        }        
        if(Input.GetKeyDown(KeyCode.Alpha6)&&this.gameObject.tag=="6")
        {
            Debug.Log("Change Sprite and add meele");
            //UseItem();
        }        
        if(Input.GetKeyDown(KeyCode.Alpha7)&&this.gameObject.tag=="7")
        {
            
        }        
        if(Input.GetKeyDown(KeyCode.Alpha8)&&this.gameObject.tag=="8")
        {
            //UseItem();
        }        
        if(Input.GetKeyDown(KeyCode.Alpha9)&&this.gameObject.tag=="9")
        {
            //UseItem();
        }
    }
    public void Additem(Item newItem)
    {
        item = newItem;

        Icon.sprite = item.icon;
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void UseItem()
    {
        if(item!=null)
        {
            item.Use();
        }
    }
}
