using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UniRx;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool Juuden = false;
    [SerializeField] Image Thunder;

    void Start()
    {
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.W))
                  .Subscribe(x => OnMove(Vector3.forward)).AddTo(this);
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.S))
                  .Subscribe(x => OnMove(Vector3.back)).AddTo(this);
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.A))
                  .Subscribe(x => OnMove(Vector3.left)).AddTo(this);
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.D))
                  .Subscribe(x => OnMove(Vector3.right)).AddTo(this);
    }

    private void OnMove(Vector3 euler)
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, euler, 0.6f))
        {
            transform.position += Vector3.up;
        }

        if (Physics.Raycast(transform.position + euler,Vector3.down,out hit,2))
        {
            if (Vector3.Distance(hit.point, transform.position + euler) > 1f)
            {
                transform.position += Vector3.down; 
            }

            transform.position += euler;
        }

        transform.rotation = Quaternion.LookRotation(euler);
        JuudenJ();
    }

    void JuudenJ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,1))
        {
            if(hit.transform.gameObject.tag == "Sender")
            {
                if(Juuden == true)
                {
                    var gim = hit.transform.gameObject.GetComponent<IGimmick>();
                    if (!gim.OnAction)
                    {
                        gim.Action();
                        Juuden = false;
                        Thunder.DOFillAmount(0, 0.5f).SetEase(Ease.InOutFlash).SetLink(gameObject); ;

                    }
                }
                else
                {
                    Juuden = true;
                    Thunder.DOFillAmount(1, 0.5f).SetEase(Ease.InOutFlash).SetLink(gameObject); ;
                }
            }
            

            if(hit.transform.gameObject.tag == "Goal")
            {
                transform.position -= new Vector3(0,1,0);
                hit.transform.GetComponent<IGimmick>().Action();
            }
        }
       
    }


}
