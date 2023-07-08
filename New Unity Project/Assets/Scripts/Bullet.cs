using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 MoveDir;
    public float speed = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveDir * speed * Time.deltaTime,Space.World);
    }

    public void setMove(Vector3 moveDir, float moveSpeed) {
        this.MoveDir = moveDir;
        this.speed = moveSpeed;
    }
}
