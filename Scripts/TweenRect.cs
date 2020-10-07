using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TweenRect : MonoBehaviour
{
    private float contraction;
    private float contractiontime;
    private float Xend;
    private float Yend; 
    private float Movetime;
    public LeanTweenType ease;
    void Start()
    {
        contraction = transform.localScale.x * 0.99f;
        contractiontime = 2;
        Xend = transform.position.x + 0.25f;
        Yend = transform.position.y + 0.25f;
        Movetime =3;
        LeanTween.scale(gameObject.GetComponent<RectTransform>(),gameObject.GetComponent<RectTransform>().localScale * 0.96f, contractiontime).setLoopPingPong().setEase(ease);
        //LeanTween.scaleX(gameObject, contraction, contractiontime).setLoopPingPong().setEase(ease);
        //LeanTween.moveX(gameObject, Xend, Movetime).setLoopPingPong().setEase(ease);
        //LeanTween.moveY(gameObject, Yend, Movetime).setLoopPingPong().setEase(ease);
    }
}
