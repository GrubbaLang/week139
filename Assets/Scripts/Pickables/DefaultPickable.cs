using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPickable : MonoBehaviour, BasePickable
{
    public event Action<GameObject> onThisHighLight;
    public event Action<GameObject> onThisPickup;
    public GameObject UsableGO { get => usableGO.gameObject; }



    [SerializeField]
    DefaultUsable usableGO;


    public void onHighlight()
    {
        throw new System.NotImplementedException();
    }

    public GameObject onPickup()
    {
        gameObject.SetActive(false);
        usableGO.gameObject.SetActive(true);
        onThisPickup?.Invoke(usableGO.gameObject);
        return usableGO.gameObject;
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
