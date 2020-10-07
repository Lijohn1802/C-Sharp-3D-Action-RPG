using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PressSpaceFlash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(DialougeManager.corunning==false)
        {*/
            if(this.gameObject.transform.GetComponent<Text>().isActiveAndEnabled == true)
            {
                StartCoroutine(disableagain());
            }
            if(this.gameObject.transform.GetComponent<Text>().isActiveAndEnabled == false)
            {
                StartCoroutine(enableagain());
            }
        //}
       // if(DialougeManager.corunning==true)
       // {
         //   this.gameObject.transform.GetComponent<Text>().enabled = false;
        //}
    }

    IEnumerator enableagain()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        this.gameObject.transform.GetComponent<Text>().enabled = true;
    }
    IEnumerator disableagain()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        this.gameObject.transform.GetComponent<Text>().enabled = false;
    }
}
