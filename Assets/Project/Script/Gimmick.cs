using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gimmick : MonoBehaviour,IGimmick
{
    [SerializeField] List<GameObject> Bridge;
    bool IGimmick.OnAction => ActionBool;
    public bool ActionBool = false;
    public Gimmick gim;

    public void Action()
    {
        if (!ActionBool)
        {
            ActionBool = true;
            if(gim != null)
            {
                gim.ActionBool = true;
            }

            foreach (GameObject bridge in Bridge)
            {
                var qurt = bridge.transform.eulerAngles + new Vector3(0, 90, 0);
                bridge.transform.DORotate(qurt, 1).OnComplete(() =>
                {
                    ActionBool = false;

                    if (gim != null)
                    {
                        gim.ActionBool = false;
                    }
                }).SetLink(gameObject);
            }
        }
    }
}
