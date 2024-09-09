using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIAnimationManager : MonoBehaviour
{
   public GameObject button;
   public Vector3 shrinkSize, enlargeSize;
   public float animationDuration;
   public Vector3 finalPos;
    public Vector3 initialPos;
    public Vector3 rotation;

    public Ease easing;

   public void ShrinkUI()
    {
        button.transform.DOScale(shrinkSize, animationDuration).OnComplete(() => button.transform.DOScale(Vector3.one, animationDuration));
    }

    public void EnlargeUI()
    {
        button.transform.DOScale(enlargeSize, animationDuration);
    }

    public void MoveButton()
    {
        button.transform.DOLocalMove(finalPos, animationDuration).SetEase(easing).OnComplete(()=> EnlargeUI());
    }

    public void ReversePositionButton()
    {
        button.transform.DOLocalMove(initialPos,animationDuration).SetEase(easing).OnComplete(() => MoveButton());
    }

    public void ShakeButton()
    {
        button.transform.DOShakePosition(5, 100, 10, 90);
        button.transform.DOShakeScale(5, 100, 10, 90);
    }

    public void FadeButton()
    {
        Image colorButton;
        colorButton = button.GetComponent<Image>(); 
        colorButton.DOFade(0,animationDuration);
    }

    public void RotateButton()
    {
        button.transform.DOLocalRotate(rotation, 5 ,RotateMode.FastBeyond360);
    }
    
    public void JumpButton()
    {
        button.transform.DOLocalJump(finalPos, 10f, 6,3);
    }
}
