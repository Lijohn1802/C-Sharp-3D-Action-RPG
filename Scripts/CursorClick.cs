using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorClick : MonoBehaviour
{
    public LeanTweenType ease;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        LeanTween.scaleY(gameObject, 0, 1f).setLoopPingPong().setEase(ease);
        LeanTween.scaleX(gameObject, 0, 1f).setLoopPingPong().setEase(ease);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
