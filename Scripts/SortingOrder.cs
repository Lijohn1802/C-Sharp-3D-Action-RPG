using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SortingOrder: MonoBehaviour
{
    private float sortingorder;
    void Update()
    {
        sortingorder = -this.transform.localPosition.z * 100f;
        this.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(sortingorder); 
    }
}