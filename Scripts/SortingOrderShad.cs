using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SortingOrderShad: MonoBehaviour
{
    private float sortingorder;
    void Update()
    {   
        this.transform.localPosition = new Vector3 (0.25f,0,-this.transform.parent.transform.localPosition.z);
        sortingorder = this.transform.position.z * 100f;
        this.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(sortingorder)+1; 
    }
}