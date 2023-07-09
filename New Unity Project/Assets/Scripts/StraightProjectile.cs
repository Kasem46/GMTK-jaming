using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Color;
using Unity.Mathematics;

public class StraightProjectile : MonoBehaviour
{
    public Camera cam;
    public bool clicked = false;
    public Vector3 point = new Vector3();
    public Vector3 point2 = new Vector3();
    public Vector3 mousePos = new Vector3();
    public Vector3 endDir;
    public double angle = Mathf.PI;
    public GameObject projectile;
    public GameObject bomb;
    public Vector3 point3 = new Vector3();
    public Vector3 mousePos3 = new Vector3();
    public GameManager manager;
    //ball cooldowns
    public int ballcount = 5;
    public float ballInterval = 3;

    //BOMB cooldowns
    public int bombCount = 3;
    public float bombInterval = 10;

    // Start isn't called before the first frame update
    void Start() {
        transform.position = new Vector3(0, 0, 0);
        cam = Camera.main;
        
    }

    // Update isn't called once per frame
    void Update(){
        BallCooldown();
        BOMBCooldown();

        //ball logic
        if (Input.GetMouseButtonDown(0) && clicked == false) { //Places line where player clicked
            mousePos = Input.mousePosition;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            if (checkbound(point) == true) {
                transform.position = point;
                clicked = true;
                }
        } else if (Input.GetMouseButton(0) && clicked == true){ //Angles line towards cursor while mouse is held down
            
            Vector3 mousePos2 = Input.mousePosition;
            point2 = cam.ScreenToWorldPoint(new Vector3(mousePos2.x, mousePos2.y, cam.nearClipPlane));
            float distanceX = point2.x - point.x;
            float distanceY = point2.y - point.y;
            float distanceHypotnuse = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2));

            endDir = new Vector3(distanceX, distanceY);

            CalculateAngle(distanceX,distanceY,distanceHypotnuse);

            //angle in degrees
            //Debug.Log(angle * Mathf.Rad2Deg);
            if (distanceX == 0f && distanceY == 0f) {
                endDir = new Vector3(0,-1);
                angle = Mathf.PI;
            }
            

        } else if(clicked == true){ //Player is not holding, attack can start
            fireProjectile();
            clicked = false;
        }
        if (Input.GetMouseButtonDown(1) == true) {
            mousePos3 = Input.mousePosition;
            point3 = cam.ScreenToWorldPoint(new Vector3(mousePos3.x, mousePos3.y, +1));
            if (CheckBoundBomb(point3) == true && bombCount > 0){
                GameObject newBomb = Instantiate(bomb, point3, Quaternion.identity);
                newBomb.GetComponent<DropBomb>().ArmBomb(point3);
                bombCount -= 1;
            }
        }

        //apply angle 
        this.transform.eulerAngles = new Vector3(0, 0, -(float)(Mathf.Rad2Deg*angle));

    }

    void BallCooldown() {
        //cooldown refreshes
        if (ballInterval <= 0)
        {
            ballInterval = 3f;
            ballcount += 3;
          
        }
        ballcount = Mathf.Clamp(ballcount, 0, 5);
        ballInterval -= Time.deltaTime;
    }

    void BOMBCooldown() {
        if (bombInterval <= 0) {
            bombInterval = 8f;
            bombCount += 2;
        }
        bombCount = Mathf.Clamp(bombCount, 0, 3);
        bombInterval -= Time.deltaTime;
    }

    void fireProjectile() {
        if (ballcount > 0){
            GameObject newProjectile = Instantiate(projectile, point, Quaternion.identity);
            newProjectile.GetComponent<Bullet>().setMove(endDir.normalized, 2f);
            newProjectile.GetComponent<Bullet>().setGameManager(manager);
            ballcount--;
        }
    }

    bool checkbound(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float)mousePos.x, -2.75f, 2.75f) || mousePos.y != Mathf.Clamp((float)mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }
    bool CheckBoundBomb(Vector3 mousePos) {
        if (mousePos.x != Mathf.Clamp((float) mousePos.x, -3.25f, 3.25f) && mousePos.y != Mathf.Clamp((float) mousePos.y, -4.5f, 0f)) { return true; } else { return false; }
    }

    void CalculateAngle(float distanceX, float distanceY, float distanceHypotnuse) {

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
        else if (distanceX > 0f && distanceY == 0f)
        {
            angle = (0.5 * Mathf.PI);
        }
        else if (distanceX < 0f && distanceY == 0f)
        {
            angle = (1.5 * Mathf.PI);
        }

    }
    
}
