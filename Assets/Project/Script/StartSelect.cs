using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSelect : MonoBehaviour
{
    [SerializeField] Image RightUpImage;
    [SerializeField] Image LeftUpImage;
    [SerializeField] Image RightRowImage;
    [SerializeField] Image LeftRowImage;
    [SerializeField] Image VoltImage;
    Vector3 ru;
    Vector3 rr;
    Vector3 lr;
    Vector3 lu;

    void Start()
    {
        ru = RightUpImage.rectTransform.anchoredPosition;
        lu = LeftUpImage.rectTransform.anchoredPosition;
        rr = RightRowImage.rectTransform.anchoredPosition;
        lr = LeftRowImage.rectTransform.anchoredPosition;

        var x = 480;
        var y = 270;
        var xx = 600;
        var yy = 350;

        RightUpImage.rectTransform.anchoredPosition = new Vector3(x, y);
        LeftRowImage.rectTransform.anchoredPosition = new Vector3(-x, -y);
        LeftUpImage.rectTransform.anchoredPosition = new Vector3(-xx, yy);
        RightRowImage.rectTransform.anchoredPosition = new Vector3(xx, -yy);

        Invoke("VoltAction",1);
    }

    private void VoltAction()
    {
        VoltImage.rectTransform.DOLocalMoveY(-1100,1f).OnComplete(()=>A());
    }

    void A()
    {
        
        RightRowImage.rectTransform.DOLocalMove(rr, 0.6f).SetEase(Ease.OutQuad)
            .OnComplete(() =>
            RightUpImage.rectTransform.DOLocalMove(ru, 0.6f).SetEase(Ease.OutQuad));
        
        LeftUpImage.rectTransform.DOLocalMove(lu, 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() => LeftRowImage.rectTransform.DOLocalMove(lr, 0.6f).SetEase(Ease.OutQuad));

    }
}
