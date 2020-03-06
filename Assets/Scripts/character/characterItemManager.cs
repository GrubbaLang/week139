using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class characterItemManager : MonoBehaviour
{
    /// <summary>
    /// Callback mostly for UI prompting
    /// </summary>
    public GameObjectGameEvent onAnyHighLight;

    /// <summary>
    /// When the player picks up and Object
    /// </summary>
    public GameObjectGameEvent onAnyPickup;

    /// <summary>
    /// When the player either pickups or leaves 
    /// </summary>
    public GameObjectGameEvent onNoHighLight;

    [SerializeField]
    int pickableLayerIndex;
    [SerializeField]
    Transform itemPoint;
    pickerState currentState = 0;
    

    //nearest stack like behaviour with remove functionality
    LinkedList<GameObject> pickables;

    void Start()
    {
        Debug.Log(string.Format("Player started checking for pickables in layer {0}", LayerMask.LayerToName(pickableLayerIndex)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function assummes collided object always has BasePickable
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == pickableLayerIndex) 
        { 
        

            
        }
    }
}

internal enum pickerState
{
    none, holding
}