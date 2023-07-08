using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectiles : MonoBehaviour
{
    public GameObject projectiles;
    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(-1 * Time.deltaTime, 0, 0);
    }

    public void CreateProjectiles(Vector3 pos) {
        for (int i = 1; i <= 10; i++) {
            GameObject newProjectiles = Instantiate(projectiles, pos, Quaternion.identity);
            newProjectiles.transform.Rotate(0.0f, 0.0f, (36f*i), Space.Self);
        }  
    } 
}
