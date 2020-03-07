using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultUsable : MonoBehaviour, IBaseUsable
{
    public event Action<GameObject> onThisDeEquip;
    public event Action<GameObject> onThisUse;
    public event Action<GameObject> onThisThrow;

    public GameObject pickableGO;
    public GameObject throwGO;

    [SerializeField]
    Vector2 deEquipVel = Vector2.one;
    
    [SerializeField]
    Vector2 onThrowVel = Vector2.one*Mathf.Deg2Rad;

    public void onDeEquip(Transform oldParent)
    {
        transform.SetParent(oldParent, true);
        pickableGO.SetActive(true);
        gameObject.SetActive(false);
        pickableGO.GetComponent<Rigidbody2D>().velocity = deEquipVel;
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
