using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public static bool moveDown = false;
    
    public static float explodePoint;

    // Start is called before the first frame update
    void Start(){
 
    }

    // Update is called once per frame
    void Update(){
        if (moveDown == true) {
            transform.Translate(0, -2f * Time.deltaTime, 0);
            if (explodePoint >= (((int)transform.position.y) * 10)) {
                Destroy(this.gameObject);
            }
        }

    }
    bool checkbound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -3.75f, 3.75f) && mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
    public void ArmBomb(Vector3 pos) {
        moveDown = true;
        explodePoint = Random.Range(0, -50);
    }
}
