using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] Image Volt;
    float PositionY;

    private void Start()
    {
        PositionY = Volt.rectTransform.localPosition.y;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Volt.transform.DOLocalMoveY(PositionY, 0.5f);

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Volt.rectTransform.DOLocalMoveY(PositionY + 100,0.5f);
        Volt.rectTransform.DOLocalRotate(new Vector3(0, 360, 0), 0.5f, RotateMode.FastBeyond360);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Stage1");
    }
}
