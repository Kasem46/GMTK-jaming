using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public Vector3 mousePos = new Vector3();
    public Vector3 point = new Vector3();
    public bool moveDown = false;
    public Camera cam;
    // Start is called before the first frame update
    void Start(){
        transform.position = new Vector3(0, 0, 0);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(1) ){ //Places line where player clicked
            mousePos = Input.mousePosition;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            if (checkbound(point) == true){
                transform.position = point;
                moveDown = true;
            }
        }
        if (moveDown == true) {
            transform.Translate(0, -.05f, 0);
        }
    }
    bool checkbound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -2.75f, 2.75f) && mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
}
