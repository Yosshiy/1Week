using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gimmick : MonoBehaviour
{
    [SerializeField] GameObject KO;
    public void Volt()
    {
        var poy = KO.transform.eulerAngles + new Vector3(0,90,0);
        KO.transform.DORotate(poy,1);
    }
}

public interface IGimmick
{

}