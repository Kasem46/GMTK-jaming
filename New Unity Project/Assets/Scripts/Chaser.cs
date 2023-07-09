using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Vector3 mousePos4 = new Vector3();
    public Vector3 point4 = new Vector3();
    public float moveSpeed = 2.5f;
    public float rotateSpeed = 120f;
    public Camera cam;
    public bool moving = false;

    //cool
    public float coolDown = 5f;
    int alphaMod = 1;
    public float alpha = 1;
    public Color MyColor = new Color(255,255,255);

    // Start is called before the first frame update
    void Start(){
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        coolDown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(2) && moving == false && coolDown <= 0f){
            mousePos4 = Input.mousePosition;
            point4 = cam.ScreenToWorldPoint(new Vector3(mousePos4.x, mousePos4.y, +1));
            if (CheckBound(point4) == true){
                moving = true;
            }
        }
        if(moving == true) {
            if (transform.position != point4)
            {
                this.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, point4, moveSpeed * Time.deltaTime);
            }
            else{
                moving = false;
                coolDown = 5f;
            }
        }
        //flashing when unavailable
        if (coolDown > 0f)
        {

            if (alpha >= 1)
            {
                alphaMod = -1;
            }
            else if (alpha <= 0)
            {
                alphaMod = 1;
            }

            alpha += 0.9f * Time.deltaTime * alphaMod;
            MyColor.a = alpha;
            
        }
        else {
            MyColor.a = 1;
        }
        this.GetComponent<SpriteRenderer>().color = MyColor;
    }
    bool CheckBound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -2.75f, 2.75f) || mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
}
