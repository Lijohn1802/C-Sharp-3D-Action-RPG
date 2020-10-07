using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDia : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Start()
    {  
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
