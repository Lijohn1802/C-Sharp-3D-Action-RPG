using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Metalss : MonoBehaviour
{
    public static int metal;
    public Text metals;
    public static int wood;
    public Text woods;
    public static int crystal;
    public Text crystals;
    // Start is called before the first frame update
    void Start()
    {
        metal = 50;
        wood = 10;
        crystal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "MetalText")
        {
            metals.text = ": " + metal.ToString();
        }
        if(this.gameObject.tag == "WoodText")
        {
            woods.text = ": " + wood.ToString();
        }
        if(this.gameObject.tag == "CrystalText")
        {
            crystals.text = ": " + crystal.ToString();
        }
    }
}
