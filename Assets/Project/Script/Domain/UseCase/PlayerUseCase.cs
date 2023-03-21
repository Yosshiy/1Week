using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUseCase
{

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


}
