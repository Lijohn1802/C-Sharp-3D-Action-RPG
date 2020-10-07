using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[ExecuteInEditMode]
public class TilemapShadow : MonoBehaviour
{
    private float sortingorder;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3 (0.25f,this.transform.parent.transform.position.y,-this.transform.parent.transform.localPosition.z);
        sortingorder = -this.transform.position.z * 100f;
        this.GetComponent<TilemapRenderer>().sortingOrder = Mathf.RoundToInt(sortingorder)+1; 
        this.GetComponent<Tilemap>().color = new Color(0,0,0,0.75f);
    }
}