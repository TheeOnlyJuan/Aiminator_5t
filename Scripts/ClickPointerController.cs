﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointerController : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    private GameController5Target gameController;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        // CrossHair.collider2D.enabled = true;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController5Target>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - startTime) >= lifeTime)
        {
            //CrossHair.collider2D.enabled = false;
            Debug.Log("destoryed");
            gameController.Miss();
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("h");
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        Debug.Log("Uhhhh");
    }
}
