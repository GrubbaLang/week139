using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultUsable : MonoBehaviour, IBaseUsable
{
    public event Action<GameObject> onThisDeEquip;
    public event Action<GameObject> onThisUse;
    public event Action<GameObject> onThisThrow;

    [SerializeField]
    GameObject pickableGO;
    [SerializeField]
    GameObject usableGO;

    [SerializeField]
    Vector2 deEquipVel = Vector2.one;
    
    [SerializeField]
    Vector2 onThrowVel = Vector2.one*Mathf.Epsilon;

    public void onDeEquip()
    {
        throw new System.NotImplementedException();
    }

    public void onPlayerUse()
    {
        throw new System.NotImplementedException();
    }

    public void onThrow()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
