using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour{
    public float moveSpeed = .5f;
    public Camera cam;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, cube.GetComponent<Transform>().position, moveSpeed * Time.deltaTime);
        if (Input.GetMouseButton(2)){
            
        }
    }
}
