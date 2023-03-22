using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IPlayerEntity
{
    IReactiveProperty<bool> GetCharging {  get; }
    public IGimmick GetInterface(RaycastHit hit);
    public void ChangeCharging(bool value);
}

public class PlayerEntity : IPlayerEntity
{
    IReactiveProperty<bool>  IPlayerEntity.GetCharging => Charging;
    ReactiveProperty<bool> Charging = default;

    public PlayerEntity()
    {
        Charging = new ReactiveProperty<bool>(false);
    }

    public void ChangeCharging(bool value)
    {
        Charging.Value = value;
    }

    public IGimmick GetInterface(RaycastHit hit)
    {
        return hit.transform.GetComponent<IGimmick>();
    }
}
