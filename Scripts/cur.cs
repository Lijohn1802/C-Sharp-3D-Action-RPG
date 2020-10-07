using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class cur : MonoBehaviour
{
    public Camera referencetomousepos;
    // Start is called before the first frame update
    void Start()
    {
        referencetomousepos = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().maincam;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Time.timeScale==0)
        {
            Cursor.visible = true;
            this.gameObject.SetActive(false);
        }*/
        if(EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.visible = true;
            this.gameObject.SetActive(false);
        }
        var pos = Input.mousePosition;
        pos.z = 50;
        var mousePos2 = referencetomousepos.ScreenToWorldPoint(pos);
        this.gameObject.transform.position = mousePos2;
    }
}
