using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseUsable
{
    event Action<GameObject> onThisDeEquip;
    event Action<GameObject> onThisUse;
    event Action<GameObject> onThisThrow;
    void onPlayerUse();
    void onThrow();
    void onDeEquip();
}
