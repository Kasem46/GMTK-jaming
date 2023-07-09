using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 MoveDir;
    public float speed = 1f;
    public int damage = 20;
    public GameManager manager;

    
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

    private void OnTriggerEnter2D(Collider2D collision){
        manager.takeDamage(damage);
        Destroy(gameObject);
    }

    public void setMove(Vector3 moveDir, float moveSpeed) {
        this.MoveDir = moveDir;
        this.speed = moveSpeed;
    }

    public void setGameManager(GameManager manager) {
        this.manager = manager;
    }
}
