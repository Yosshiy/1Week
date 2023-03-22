using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CLEAR : MonoBehaviour,IGimmick
{
    [SerializeField] Image RightUpImage;
    [SerializeField] Image LeftUpImage;
    [SerializeField] Image RightRowImage;
    [SerializeField] Image LeftRowImage;
    [SerializeField] Text ClearText;
    [SerializeField] Text ClearText2;
    bool OnClear = false;
    bool ActionBool;
    public bool OnAction => ActionBool;

    private void Start()
    {
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.Space))
                  .Where(x => OnClear == true)
                  .Subscribe(x => SceneManager.LoadScene("Select"));
    }

    public void Action()
    {
        RightUpImage.rectTransform.DOLocalMove(new Vector3(480, 270), 0.6f).SetEase(Ease.OutQuart)
                    .OnComplete(() =>
                    RightRowImage.rectTransform.DOLocalMove(new Vector3(600, -350), 0.6f)).SetEase(Ease.OutQuad);
        LeftRowImage.rectTransform.DOLocalMove(new Vector3(-480, -270), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() => LeftUpImage.rectTransform.DOLocalMove(new Vector3(-600, 350), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        OnClear = true;
                        ClearText.DOFade(1, 2);
                        ClearText2.DOFade(1, 2);

                    }));
    }

}
