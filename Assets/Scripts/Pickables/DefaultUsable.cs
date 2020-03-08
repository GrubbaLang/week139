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
    float leaveVel = 1;
    
    [SerializeField, Tooltip("X is throw speed, Y is rotation force")]
    Vector2 onThrowVelTorgue = Vector2.one*Mathf.Deg2Rad;

    public void onDeEquip(Transform oldParent)
    {
        transform.SetParent(oldParent, true);
        pickableGO.transform.position = this.transform.position;
        pickableGO.SetActive(true);
        gameObject.SetActive(false);
        var rb = pickableGO.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.one * leaveVel;
        rb.angularVelocity = 200;
        var rot = transform.rotation.eulerAngles;
        rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);

    }

    public void onPlayerUse()
    {
        throw new System.NotImplementedException();
    }

    public void onThrow(Transform args1)
    {
        throwGO.transform.position = args1.position;
        throwGO.transform.rotation = args1.rotation;
        gameObject.SetActive(false);
        throwGO.SetActive(true);
        var rb = throwGO.GetComponent<Rigidbody2D>();
        rb.angularVelocity = UnityEngine.Random.value * 10 % 2 == 0 ? onThrowVelTorgue.y : -onThrowVelTorgue.y;
        rb.velocity = args1.right * onThrowVelTorgue.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
