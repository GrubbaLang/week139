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
    private bool firstCol = false;
    private throwableStateTracker stateTracker;

    public void launchSelf(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        firstCol = true;
        if (back2pickCor != null)
            StopCoroutine(back2pickCor);
        back2pickCor = StartCoroutine(turnSelfIntoPickabble(timeToBackToPickable));
    }

    void Start()
    {
        stateTracker = GetComponent<throwableStateTracker>();
        this.enabled = false;
        Debug.Log(string.Format("Throwable {0} started checking for enemies in layer {1}", gameObject.name ,LayerMask.LayerToName(enemyLayerIndx)));
    }


    void backToPick()
    {
        stateTracker.goToPickable();
        Debug.LogFormat("{0} turned back to pickable", gameObject.name);
    }

    IEnumerator turnSelfIntoPickabble(float time)
    {
        yield return new WaitForSeconds(time);
        backToPick();
    }

    void OnCollisionEnter2D(Collision2D otherCol)
    {
        if (this.enabled)
        {
            if (otherCol.gameObject.layer == enemyLayerIndx && firstCol)
            {

                //Hitting enemy with throwable code here
            }
            firstCol = false;


            back2pickCor = StartCoroutine(turnSelfIntoPickabble(0.1f)); 
        }
    }
}
