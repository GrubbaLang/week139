using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputToArrow : MonoBehaviour
{
    Vector2 inputVector;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        float angle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        spr.enabled = inputVector.sqrMagnitude != 0;
    }
}
