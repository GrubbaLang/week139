using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultThrowable : MonoBehaviour, IBaseThrowable
{
    public GameObject pickableGO;
    public int enemyLayerIndx = 10;
    public float timeToBackToPickable;

    private Coroutine back2pickCor;
    private Rigidbody2D rb;

    public void launchSelf(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (back2pickCor != null)
            StopCoroutine(back2pickCor);
        back2pickCor = StartCoroutine(turnSelfIntoPickabble(timeToBackToPickable));
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(string.Format("Item {0} started checking for enemies in layer {1}", gameObject.name ,LayerMask.LayerToName(enemyLayerIndx)));
    }


    void backToPick()
    {
        pickableGO.SetActive(true);
        pickableGO.transform.position = transform.position;
        pickableGO.transform.rotation = transform.rotation;
        var otherrb = pickableGO.GetComponent<Rigidbody2D>();
        otherrb.velocity = rb.velocity;
        otherrb.angularVelocity = rb.angularVelocity;
        Debug.LogFormat("{0} turned back to pickable", gameObject.name);
        gameObject.SetActive(false);
    }

    IEnumerator turnSelfIntoPickabble(float time)
    {
        yield return new WaitForSeconds(time);
        backToPick();
    }

    void OnCollisionEnter2D(Collision2D otherCol)
    {
        if(otherCol.gameObject.layer == enemyLayerIndx)
        {
            
            //Hitting enemy with throwable code here
        }
        StopCoroutine(back2pickCor);
        back2pickCor = StartCoroutine(turnSelfIntoPickabble(0.3f));
    }
}
