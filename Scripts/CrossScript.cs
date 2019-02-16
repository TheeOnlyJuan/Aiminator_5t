using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : MonoBehaviour
{
    public GameObject ClickPoint;
    public float speed;
    //public float xMin, xMax, yMin, yMax;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,-5);

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");
        transform.position += new Vector3(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed, 0);
       // transform.position = new Vector3
       //(
       //    Mathf.Clamp(transform.position.x, xMin, xMax),
       //    Mathf.Clamp(transform.position.y, yMin, yMax),
       //    0

       //);
        if (Input.GetMouseButtonUp(0))
        {
            //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //gameObject.GetComponent<Collider2D>().enabled = true;
            Instantiate(ClickPoint, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        }
        //if ((Time.time - startTime) >= lifeTime)
        //{
        //    //CrossHair.collider2D.enabled = false;
        //    //gameObject.GetComponent<Collider2D>().enabled = false;
        //}
    }

}
