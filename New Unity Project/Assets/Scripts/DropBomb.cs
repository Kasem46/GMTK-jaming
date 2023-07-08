using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public static bool moveDown = false;
    public GameObject projectiles;
    public float explodePoint;
    float timer = 0;

    // Start is called before the first frame update
    void Start(){
 
    }

    // Update is called once per frame
    void Update(){
        if (moveDown == true) {
            explodePoint = (Random.value + 0.2f) * 10f;
            transform.Translate(0, -2f * Time.deltaTime, 0);
            if (timer >= explodePoint) {
                projectiles.GetComponent<ExplosionProjectiles>().CreateProjectiles(transform.position);
                Destroy(this.gameObject);
                timer = 0f;
            } else {
                timer += Time.deltaTime;
            }
            
        }

    }
    bool checkbound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -3.75f, 3.75f) && mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
    public void ArmBomb(Vector3 pos) {
        moveDown = true;
        
    }
}
