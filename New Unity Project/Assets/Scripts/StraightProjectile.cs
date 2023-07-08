using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class StraightProjectile : MonoBehaviour
{
    public Camera cam;
    public bool clicked = false;
    public Vector3 point = new Vector3();
    public Vector3 point2 = new Vector3();
    public Vector3 mousePos = new Vector3();
    public double angle = Mathf.PI;


    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector3(0, 0, 0);
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            mousePos = Input.mousePosition;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            transform.position = point;
            clicked = true;
        } else if (!Input.GetMouseButtonDown(0) && clicked == true){ //I think Gagreil broke it
            
            Vector3 mousePos2 = Input.mousePosition;
            point2 = cam.ScreenToWorldPoint(new Vector3(mousePos2.x, mousePos2.y, cam.nearClipPlane));
            float distanceX = point2.x - point.x;
            float distanceY = point2.y - point.y;
            float distanceHypotnuse = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2));
            if (distanceX > 0f && distanceY > 0f)
            {
                //any sin cos or tan
                angle = Mathf.Asin(distanceX / distanceHypotnuse);
            }
            else if (distanceX < 0f && distanceY > 0f)
            {
                //sine
                angle = Mathf.Asin(distanceY / distanceHypotnuse) + 1.5 * Mathf.PI;
            }
            else if (distanceX < 0f && distanceY < 0f)
            {
                //tan
                angle = Mathf.Atan(distanceX / distanceY) + Mathf.PI;
            }
            else if (distanceX > 0f && distanceY < 0f)
            {
                //cos
                angle = Mathf.Acos(distanceX / distanceHypotnuse) + 0.5 * Mathf.PI;
            }
            else if (distanceX == 0f && distanceY > 0f)
            {
                angle = 0.0;
            }
            else if (distanceX > 0f && distanceY == 0f) {
                angle = (0.5 * Mathf.PI);
            } else if (distanceX < 0f && distanceY == 0f) {
                angle = (1.5 * Mathf.PI);
            }

            //angle in degrees
            Debug.Log(angle * Mathf.Rad2Deg);

            

        }
        //apply angle (declan broke it)
        this.transform.eulerAngles = new Vector3(0, 0, -(float)(Mathf.Rad2Deg*angle));

    }
}
