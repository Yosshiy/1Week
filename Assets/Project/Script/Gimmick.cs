using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gimmick : MonoBehaviour,IGimmick
{
    [SerializeField] GameObject Bridge;
    bool IGimmick.OnAction => ActionBool;
    bool ActionBool = false;

    public void Action()
    {
        ActionBool = true;
        var qurt = Bridge.transform.eulerAngles + new Vector3(0,90,0);
        Bridge.transform.DORotate(qurt,1).OnComplete(() => ActionBool = false);
    }
}
