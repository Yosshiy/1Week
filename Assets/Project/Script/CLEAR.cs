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
    [SerializeField] Image VoltImage;
    [SerializeField] Text ClearText;
    [SerializeField] Text ClearText2;
    [SerializeField] AudioSource CAudio;
    bool OnClear = false;
    bool ActionBool;
    public bool OnAction => ActionBool;

    private void Start()
    {
        OnClear = true;
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.Space))
                  .Where(x => OnClear == true)
                  .Subscribe(x => Load()).AddTo(this);
    }

    public void Action()
    {
        RightUpImage.rectTransform.DOLocalMove(new Vector3(480, 270), 0.6f).SetEase(Ease.OutQuart)
                    .OnComplete(() =>
                    RightRowImage.rectTransform.DOLocalMove(new Vector3(600, -350), 0.6f)).SetEase(Ease.OutQuad).SetLink(gameObject);
        LeftRowImage.rectTransform.DOLocalMove(new Vector3(-480, -270), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() => LeftUpImage.rectTransform.DOLocalMove(new Vector3(-600, 350), 0.6f).SetEase(Ease.OutQuad)
                    .OnComplete(() =>
                    {
                        
                        ClearText.DOFade(1, 1.2f).SetLink(gameObject);
                        ClearText2.DOFade(1, 1.2f).SetLink(gameObject);
                        VoltImage.rectTransform.DOLocalMoveY(0, 1f).OnComplete(() => OnClear = true).SetLink(gameObject);

                    })).SetLink(gameObject);
    }

    void Load()
    {
        ClearText.DOFade(0, 1).SetLink(gameObject);
        ClearText2.DOFade(0, 1).SetLink(gameObject);
        CAudio.DOFade(0, 1).OnComplete(()=>SceneManager.LoadScene("SelectDammy")).SetLink(gameObject);
    }

}
