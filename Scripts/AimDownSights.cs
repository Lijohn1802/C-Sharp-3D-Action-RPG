using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AimDownSights : MonoBehaviour
{
    public CinemachineCameraOffset cam;
    public GameObject Crosshair;
    private Vector3 original = new Vector3(0f,1.5f,3f);
    private Vector3 ADS = new Vector3(0.25f,1.5f,4.5f);
    public float movementTime;
    float lerpvalue;
    float lerpvalueads;
    public GameObject gun;
    public GameObject barrelexit;
    public Camera camer;
    public Animator playeranim;
    void Update()
    {           
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.visible = false;
        }
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.visible = true;
        }
        Debug.DrawLine(camer.transform.position,Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 100f)), Color.red);
        if(Input.GetMouseButton(1))
        {
            playeranim.SetTrigger("Fire");
            RaycastHit hit;
            if(Physics.Raycast(camer.transform.position,Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 100f)) - camer.transform.position,out hit, 100f))
            {
                Debug.DrawRay(camer.transform.position,Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 100f)) - camer.transform.position,Color.yellow);
                Vector3 target  = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, hit.distance));
               //gun.transform.LookAt(target1,Vector3.forward); 
                barrelexit.transform.LookAt(target,Vector3.forward); 
            }
            if(lerpvalue<1)
            {
                lerpvalue += Time.deltaTime/movementTime;
            }
            cam.m_Offset= Vector3.Lerp(cam.m_Offset,ADS,lerpvalue);
            lerpvalueads = 0;
        }
        else
        {
            lerpvalue = 0;
            if(lerpvalueads<1)
            {
                lerpvalueads += Time.deltaTime/movementTime;
            }
            cam.m_Offset= Vector3.Lerp(cam.m_Offset,original,lerpvalueads);
        }
    }
}
