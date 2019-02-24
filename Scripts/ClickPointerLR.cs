using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPointerLR : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    private GameControllerLR gameController;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        // CrossHair.collider2D.enabled = true;

        GameObject gameControllerObject = GameObject.FindWithTag("GameLR");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameControllerLR>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameControllerLR' script!");
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        Debug.Log("Uhhhh");
    }
}
