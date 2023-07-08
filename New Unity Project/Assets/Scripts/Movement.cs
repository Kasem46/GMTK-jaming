using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    double speed;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0) * Time.deltaTime;
        transform.Translate(0, (float)-2.5, -1);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (counter > 1) {
            speed = (1 / (double)(counter * .7));
            counter = 0;
        } else {
            speed = 1;
        }
        if (Input.GetKey(KeyCode.W) ) {
            transform.Translate(0, (float)(.07 * speed), 0) ;
            counter++;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -(float)(.07 * speed), 0);
            counter++;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-(float)(.07 * speed), 0, 0);
            counter++;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate((float)(.07 * speed), 0, 0);
            counter++;
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp((float)transform.position.x, (float)-2.75, (float)2.75);
        pos.y = Mathf.Clamp((float)transform.position.y, (float)-4.5, 0);
        transform.position = new Vector3(pos.x, pos.y, -1);
        //Raycasts
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null) {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(distance);
        }
    }
}
