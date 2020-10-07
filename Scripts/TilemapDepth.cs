using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class TilemapDepth : MonoBehaviour
{
    private float sortingorder;
    // Start is called before the first frame update
    void Start()
    {
           }
    void Update()
    {
sortingorder = this.transform.position.z * 100f;
        this.GetComponent<TilemapRenderer>().sortingOrder = -Mathf.RoundToInt(sortingorder); 
 
    }
}
