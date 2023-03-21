using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public interface IPlayerRayEntity
{
    public RaycastHit? DownRay(Vector3 position);
    public Vector3 IsGroundRay(Vector3 position, Vector3 euler);
    public Vector3 DefaultRay(Vector3 position, Vector3 euler);
}

public class PlayerRayEntity : IPlayerRayEntity
{
    const float RayDistance = 1;


    public Vector3 DefaultRay(Vector3 position,Vector3 euler)
    {
        if (Physics.Raycast(position, euler, 1))
        {
           return position + Vector3.up;
        }

        return position;
    }
    
    public Vector3 IsGroundRay(Vector3 position,Vector3 euler)
    {
        RaycastHit hit;

        if (Physics.Raycast(position + euler, Vector3.down, out hit,RayDistance * 2))
        {
            if (Vector3.Distance(hit.point,position + euler) > RayDistance)
            {;
                return position + Vector3.down + euler;
            }

            return position + euler;
        }

        return position;
    }

    public RaycastHit? DownRay(Vector3 position)
    {
        RaycastHit hit;

        if (Physics.Raycast(position, Vector3.down, out hit, 1))
        {
            return hit;
        }

        return null;
    }
}
