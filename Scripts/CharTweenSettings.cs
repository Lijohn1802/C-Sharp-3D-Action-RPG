using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharTweenSettings : MonoBehaviour
{
    private float contraction;
    private float contractiontime;
    public LeanTweenType ease;
    void Start()
    {
        contraction = transform.localScale.x * 0.94f;
        contractiontime = 1.75f;

        LeanTween.scaleY(gameObject, contraction, contractiontime).setLoopPingPong().setEase(ease);
        LeanTween.scaleX(gameObject, contraction, contractiontime).setLoopPingPong().setEase(ease);

    }
}
