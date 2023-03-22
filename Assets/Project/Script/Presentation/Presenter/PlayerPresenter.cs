using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IPlayerInput
{
    public IObservable<long> GetW { get; }
    public IObservable<long> GetS { get; }
    public IObservable<long> GetA { get; }
    public IObservable<long> GetD { get; }
}

public interface IPlayerOutput
{
    void OnMove(Vector3 position);
    public Vector3 GetTransform();
}


public class PlayerPresenter : IDisposable
{
    readonly IPlayerInput Input = default;
    readonly IPlayerOutput Output = default;
    readonly IPlayerUseCase UseCase = default;
    CompositeDisposable Disposable;


    public PlayerPresenter(IPlayerInput input,IPlayerOutput output,IPlayerUseCase useCase)
    {
        UseCase = useCase;
        Input = input;
        Output = output;
        Disposable = new CompositeDisposable();
        Begin();
    }

    void Begin()
    {
        SetUp();
        Event();
    }

    void SetUp()
    {

    }

    void Event()
    {
        Input.GetW
             .Subscribe(x => {

                 Output.OnMove(UseCase.DefaultRay(Output.GetTransform(), Vector3.forward));
                 Output.OnMove(UseCase.IsGroundRay(Output.GetTransform(), Vector3.forward));

             }).AddTo(Disposable);

        Input.GetS
             .Subscribe(x => {

                 Output.OnMove(UseCase.DefaultRay(Output.GetTransform(), Vector3.back));
                 Output.OnMove(UseCase.IsGroundRay(Output.GetTransform(), Vector3.back));

             }).AddTo(Disposable);

        Input.GetA
             .Subscribe(x => {

                 Output.OnMove(UseCase.DefaultRay(Output.GetTransform(), Vector3.left));
                 Output.OnMove(UseCase.IsGroundRay(Output.GetTransform(), Vector3.left));

             }).AddTo(Disposable);
        
        Input.GetD
             .Subscribe(x => {

                 Output.OnMove(UseCase.DefaultRay(Output.GetTransform(), Vector3.right));
                 Output.OnMove(UseCase.IsGroundRay(Output.GetTransform(), Vector3.right));

             }).AddTo(Disposable);
    }

    public void Dispose()
    { 
         Disposable?.Dispose();
    }
}
