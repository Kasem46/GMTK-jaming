using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Vector3 mousePos4 = new Vector3();
    public Vector3 point4 = new Vector3();
    public float moveSpeed = .5f;
    public Camera cam;
    // Start is called before the first frame update
    void Start(){
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButton(2)){
            mousePos4 = Input.mousePosition;
            point4 = cam.ScreenToWorldPoint(new Vector3(mousePos4.x, mousePos4.y, +1));
            if (CheckBound(point4) == true){
                transform.position = Vector3.MoveTowards(transform.position, point4, moveSpeed * Time.deltaTime);
            }
            
        }
    }
    bool CheckBound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -2.75f, 2.75f) || mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
}
