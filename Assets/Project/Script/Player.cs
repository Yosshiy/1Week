using System.Collections;
using System.Collections.Generic;
using System.Data;
using UniRx;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool Juuden = false;


    void Start()
    {
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.W))
                  .Subscribe(x => OnMove(Vector3.forward));
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.S))
                  .Subscribe(x => OnMove(Vector3.back));
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.A))
                  .Subscribe(x => OnMove(Vector3.left));
        Observable.EveryUpdate()
                  .Where(x => Input.GetKeyDown(KeyCode.D))
                  .Subscribe(x => OnMove(Vector3.right));
    }

    private void OnMove(Vector3 euler)
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position,euler,1))
        {
            transform.position += Vector3.up;
        }

        if (Physics.Raycast(transform.position + euler,Vector3.down,out hit,2))
        {
            if (Vector3.Distance(hit.point, transform.position + euler) > 1f)
            {
                Debug.Log(Vector3.Distance(hit.point, transform.position + euler));
                transform.position += Vector3.down; 
            }

            transform.position += euler;
        }

        JuudenJ();
    }

    void JuudenJ()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit,1))
        {
            if(hit.transform.gameObject.tag == "Sender")
            {
                Juuden = !Juuden;
                if(Juuden == false)
                {
                    var gim = hit.transform.gameObject.GetComponent<Gimmick>();
                    gim.Volt();
                }
            }
        }
    }


}
