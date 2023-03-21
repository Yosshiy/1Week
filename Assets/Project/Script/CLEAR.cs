using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLEAR : MonoBehaviour
{
    [SerializeField] Image RightUpImage;
    [SerializeField] Image LeftUpImage;
    [SerializeField] Image RightRowImage;
    [SerializeField] Image LeftRowImage;
    [SerializeField] Text ClearText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            End();
        }
    }

    public void End()
    {
        RightUpImage.rectTransform.DOLocalMove(new Vector3(480, 270),0.6f).SetEase(Ease.OutQuart)
                    .OnComplete(() => 
                    RightRowImage.rectTransform.DOLocalMove(new Vector3(600,-350), 0.6f)).SetEase(Ease.OutQuad);
        LeftRowImage.rectTransform.DOLocalMove(new Vector3(-480, -270), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() => LeftUpImage.rectTransform.DOLocalMove(new Vector3(-600, 350), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() => ClearText.DOFade(1, 2)));
    }

}
