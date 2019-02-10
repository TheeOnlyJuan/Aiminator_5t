using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    public GameObject ClickPoint;
    public float lifeTime;
    private float startTime;
    // public float speed;
    // private Rigidbody2D rb2d;
    //private float mouseX;
    //private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(0, 0);


        //============================================================================
        // this black is for keyboard moving
        //============================================================================
        // rb2d = GetComponent<Rigidbody2D>();
        // ===========================================================================
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
            startTime = Time.time;
            //gameObject.GetComponent<Collider2D>().enabled = true;
            Instantiate(ClickPoint, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);

        }
        //if ((Time.time - startTime) >= lifeTime)
        //{
        //    //CrossHair.collider2D.enabled = false;
        //    //gameObject.GetComponent<Collider2D>().enabled = false;
        //}
    }
    // FixedUpdate is called after each physic calculation

    void FixedUpdate()
    {
        // move crosshair to current mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        // click mouse left button to generate a collider box
        
        

        //============================================================================
        // this black is for keyboard moving
        //============================================================================
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        //
        //rb2d.AddForce(new Vector2(moveHorizontal * speed, moveVertical * speed));
        //============================================================================
    }
}
