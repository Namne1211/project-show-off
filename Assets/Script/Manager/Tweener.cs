using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum AnimationTypes
{
    Move,
    Scale,
    ScaleX,
    ScaleY,
    Fade
}
/// <summary>
/// building tool for gameobject tweening animation
/// </summary>
public class Tweener : MonoBehaviour
{
    public GameObject objToAnimate;

    public AnimationTypes animationtype;
    public LeanTweenType easeType;
    public float duration;
    public float delay;
    public float enddelay;

    public bool loop;
    public bool pingpong;

    public bool startPosOffset;
    public Vector3 StartPos;
    public Vector3 EndPos;

    private LTDescr _tweenobj;

    public bool showOnenable;
    public bool WorkOnDisable;

    public void OnEnable()
    {
        if (showOnenable)
        {
            Show();
        }
    }

    public void Show()
    {
        HandleTween();
    }

    public void HandleTween()
    {
        if (objToAnimate == null)
        {
            objToAnimate = gameObject;
        }

        switch (animationtype)
        {
            case AnimationTypes.Move:
                Move();
                break;
            case AnimationTypes.Scale:
                Scale();
                break;
            case AnimationTypes.Fade:
                Fade();
                break;
        }
        _tweenobj.setDelay(delay);
        _tweenobj.setEase(easeType);

        if (loop)
        {
            _tweenobj.loopCount = int.MaxValue;
        }
        if (pingpong)
        {
            _tweenobj.setLoopPingPong();
        }
    }

    public void Move()
    {
        objToAnimate.GetComponent<RectTransform>().anchoredPosition = StartPos;

        _tweenobj = LeanTween.move(objToAnimate.GetComponent<RectTransform>(), EndPos, duration);
    }

    public void Scale()
    {
        if (startPosOffset)
        {
            objToAnimate.GetComponent<RectTransform>().localScale = StartPos;
        }
        _tweenobj = LeanTween.scale(objToAnimate, EndPos, duration);
    }

    public void Fade()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        if (startPosOffset)
        {
            objToAnimate.GetComponent<CanvasGroup>().alpha = StartPos.x;
        }
        _tweenobj = LeanTween.alphaCanvas(objToAnimate.GetComponent<CanvasGroup>(), EndPos.x, duration);

    }

    void SwapDirec()
    {
        var temp = StartPos;
        StartPos = EndPos;
        EndPos = temp;
    }

    public void OnDisable()
    {
        
        SwapDirec();

        HandleTween();

        SwapDirec();

    }

}
