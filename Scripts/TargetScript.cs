using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    private float timeInterval;
    private float nextSizeChangTime;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //
        //startTime = Time.time;
        //timeInterval = lifeTime / 40.0f;
        //nextSizeChangTime = 0;

        // cannot pass gameController at unity editor interface
        // have to do this to FIND game controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
        
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    // target life setting
    //    if ((Time.time - startTime) >= lifeTime)
    //    {
    //        Destroy(this.gameObject);
    //        gameController.TargetNumberAddOne();
            
    //    }

    //    // target size changing
    //    //if(Time.time > nextSizeChangTime)
    //    //{
    //     //   transform.localScale += new Vector3(0.0125f, 0.0125f, 0);
    //     //   nextSizeChangTime = Time.time + timeInterval;
    //    //}
        
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        gameController.HitNumberPlusOne();
        //gameController.TargetNumberAddOne();
    }
}
