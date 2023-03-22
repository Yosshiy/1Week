using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGimmick
{
    void Action();
    bool OnAction { get; }
}
