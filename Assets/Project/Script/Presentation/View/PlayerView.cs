using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerView : MonoBehaviour,IPlayerInput,IPlayerOutput
{
    public IObservable<long> GetW =>
            Observable.EveryUpdate()
                      .Where(x => Input.GetKeyDown(KeyCode.W));
    public IObservable<long> GetS =>
            Observable.EveryUpdate()
                      .Where(x => Input.GetKeyDown(KeyCode.S));
    public IObservable<long> GetA => 
            Observable.EveryUpdate()
                      .Where(x => Input.GetKeyDown(KeyCode.A));
    public IObservable<long> GetD => 
            Observable.EveryUpdate()
                      .Where(x => Input.GetKeyDown(KeyCode.D));
     
    public Vector3 GetTransform()
    {
        return transform.position;
    }

    public void OnMove(Vector3 position)
    {
        transform.position += position;            
    }
}
