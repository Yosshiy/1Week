using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public interface IPlayerUseCase
{
    public void ChangeCharging(bool value);

    public IGimmick GetInterface(RaycastHit hit);

    public RaycastHit? DownRay(Vector3 position);

    public Vector3 IsGroundRay(Vector3 position, Vector3 euler);

    public Vector3 DefaultRay(Vector3 position, Vector3 euler);
}


public class PlayerUseCase : IPlayerUseCase
{
    IPlayerRayEntity RayEntity = default;
    IPlayerEntity Entity = default;


    public PlayerUseCase(IPlayerEntity entity,IPlayerRayEntity rayentity)
    {
        RayEntity = rayentity;
        Entity = entity;
    }

    public void ChangeCharging(bool value)
    {
        Entity.ChangeCharging(value);
    }

    public IGimmick GetInterface(RaycastHit hit)
    {
        return Entity.GetInterface(hit);
    }

    public RaycastHit? DownRay(Vector3 position)
    {
        return RayEntity.DownRay(position);
    }

    public Vector3 IsGroundRay(Vector3 position, Vector3 euler)
    {
        return RayEntity.IsGroundRay(position, euler);
    }

    public Vector3 DefaultRay(Vector3 position, Vector3 euler)
    {
        return RayEntity.DefaultRay(position, euler);
    }


}
