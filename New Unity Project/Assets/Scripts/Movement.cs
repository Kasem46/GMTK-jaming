using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //double speed;
    public float speed = 1;

    //int counter;
    public float distanceUp = (float)10.0;
    public float distanceDown = (float)10.0;
    public float distanceLeft = (float)10.0;
    public float distanceRight = (float)10.0;
    public float distanceUpRight = (float)10.0;
    public float distanceUpLeft = (float)10.0;
    public float distanceDownRight = (float)10.0;
    public float distanceDownLeft = (float)10.0;
    public float distanceUpUpRight = (float)10.0;
    public float distanceRightRightUp = (float)10.0;
    public float distanceRightRightDown = (float)10.0;
    public float distanceDownDownRight = (float)10.0;
    public float distanceDownDownLeft = (float)10.0;
    public float distanceLeftLeftDown = (float)10.0;
    public float distanceLeftLeftUp = (float)10.0;
    public float distanceUpUpLeft = (float)10.0;
    public Vector3 randomPos;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0) * Time.deltaTime;
        transform.Translate(0, (float)-2.5, -1);
        randomPos = GenerateNewRandom();
        //counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /* This is old manual moving code
         if (counter > 1) {
            speed = (1 / (double)(counter * .7));
            counter = 0;
        } else {
            speed = 1;
        }
        if (Input.GetKey(KeyCode.W) ) {
            transform.Translate(0, (float)(.07 * speed), 0) ;
            counter++;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -(float)(.07 * speed), 0);
            counter++;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-(float)(.07 * speed), 0, 0);
            counter++;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate((float)(.07 * speed), 0, 0);
            counter++;
        }
        */
        
        //Raycast
        Vector2 Diagonal = new Vector2(-1, 1);
        Vector2 UUR = new Vector2(.5f, 1);
        Vector2 RRU = new Vector2(1, .5f);
        Vector2 RRD = new Vector2(1, -.5f);
        Vector2 DDR = new Vector2(.5f, -1);

        //Dectect hits
        //Up
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null){ 
            distanceUp = Mathf.Abs(hit.point.y - transform.position.y);
        }else{
            distanceUp = 10;
        }
        //UpUpRight
        hit = Physics2D.Raycast(transform.position, UUR);
        if (hit.collider != null){ 
            distanceUpUpRight = Pythagorian(hit.point, transform.position);
        }else{
            distanceUpUpRight = 10;
        }
        //UpRight
        hit = Physics2D.Raycast(transform.position, Vector2.one);
        if (hit.collider != null){
            distanceUpRight = Pythagorian(hit.point, transform.position);
        }else{
            distanceUpRight = 10;
        }
        //RightRightUp
        hit = Physics2D.Raycast(transform.position, RRU);
        if (hit.collider != null){ 
            distanceRightRightUp = Pythagorian(hit.point, transform.position);
        }else{
            distanceRightRightUp = 10;
        }
        //Right
        hit = Physics2D.Raycast(transform.position, -Vector2.left);
        if (hit.collider != null){
            distanceRight = Mathf.Abs(hit.point.x - transform.position.x);
        }else{
            distanceRight = 10;
        }
        //RightRightDown
        hit = Physics2D.Raycast(transform.position, RRD);
        if (hit.collider != null){
            distanceRightRightDown = Pythagorian(hit.point, transform.position);
        } else {
            distanceRightRightDown = 10;
        }
        //DownRight
        hit = Physics2D.Raycast(transform.position, -Diagonal);
        if (hit.collider != null){
            distanceDownRight = Pythagorian(hit.point, transform.position);
        }else{
            distanceDownRight = 10;
        }
        //DownDownRight
        hit = Physics2D.Raycast(transform.position, DDR);
        if (hit.collider != null){
            distanceDownDownRight = Pythagorian(hit.point, transform.position);
        } else {
            distanceDownDownRight = 10;
        }
        //Down
        hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null){ 
            distanceDown = Mathf.Abs(hit.point.y - transform.position.y);
        }else{
            distanceDown = 10;
        }
        //DownDownLeft
        hit = Physics2D.Raycast(transform.position, -UUR);
        if (hit.collider != null){
            distanceDownDownLeft = Pythagorian(hit.point, transform.position);
        } else {
            distanceDownDownLeft = 10;
        }
        //DownLeft
        hit = Physics2D.Raycast(transform.position, -Vector2.one);
        if (hit.collider != null){
            distanceDownLeft = Pythagorian(hit.point, transform.position);
        }else{
            distanceDownLeft = 10;
        }
        //LeftLeftDown
        hit = Physics2D.Raycast(transform.position, -RRU);
        if (hit.collider != null){
            distanceLeftLeftDown = Pythagorian(hit.point, transform.position);
        } else {
            distanceLeftLeftDown = 10;
        }
        //Left
        hit = Physics2D.Raycast(transform.position, Vector2.left);
        if (hit.collider != null){
            distanceLeft = Mathf.Abs(hit.point.x - transform.position.x);
        }else{
            distanceLeft = 10;
        }
        //LeftLeftUp
        hit = Physics2D.Raycast(transform.position, -RRD);
        if (hit.collider != null){
            distanceLeftLeftUp = Pythagorian(hit.point, transform.position);
        } else {
            distanceLeftLeftUp = 10;
        }
        //UpLeft
        hit = Physics2D.Raycast(transform.position, Diagonal);
        if (hit.collider != null){
            distanceUpLeft = Pythagorian(hit.point, transform.position);
        }else{
            distanceUpLeft = 10;
        }
        hit = Physics2D.Raycast(transform.position, -RRU);
        if (hit.collider != null){
            distanceLeftLeftDown = Pythagorian(hit.point, transform.position);
        } else {
            distanceLeftLeftDown = 10;
        }
        //UpUpLeft
        hit = Physics2D.Raycast(transform.position, -DDR);
        if (hit.collider != null){
            distanceUpUpLeft = Pythagorian(hit.point, transform.position);
        } else {
            distanceUpUpLeft = 10;
        }
        
        float[] distances = new float[16] { distanceUp, distanceUpUpRight, distanceUpRight, distanceRightRightUp, distanceRight, distanceRightRightDown, distanceDownRight, distanceDownDownRight, distanceDown, distanceDownDownLeft, distanceDownLeft, distanceLeftLeftDown, distanceLeft, distanceUpUpLeft, distanceUpLeft, distanceLeftLeftUp };
        int smallest = getSmallest(distances);
        //What to do
        switch (smallest){
            case 0:
               transform.Translate(new Vector3(0, -1f, 0)*Time.deltaTime*speed);
               break;
            case 1:
                transform.Translate(new Vector3(-.45f, -.9f, 0) * Time.deltaTime * speed);
                break;
            case 2:
               transform.Translate(new Vector3(-.9f, -.9f, 0)* Time.deltaTime*speed);
               break;
            case 3:
                transform.Translate(new Vector3(-.9f, -.45f, 0) * Time.deltaTime * speed);
                break;
            case 4:
               transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime*speed);
               break;
            case 5:
                transform.Translate(new Vector3(-.9f, .45f, 0) * Time.deltaTime * speed);
                break;
            case 6:
               transform.Translate(new Vector3(-.9f, .9f, 0) * Time.deltaTime*speed);
               break;
            case 7:
                transform.Translate(new Vector3(-.45f, .9f, 0) * Time.deltaTime * speed);
                break;
            case 8:
                transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime*speed);
                break;
            case 9:
                transform.Translate(new Vector3(.45f, .9f, 0) * Time.deltaTime * speed);
                break;
            case 10:
                transform.Translate(new Vector3(.9f, .9f, 0) * Time.deltaTime*speed);
                break;
            case 11:
                transform.Translate(new Vector3(.9f, .45f, 0) * Time.deltaTime * speed);
                break;
            case 12:
                transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime*speed);
                break;
            case 13:
                transform.Translate(new Vector3(.9f, -.45f, 0) * Time.deltaTime * speed);
                break;
            case 14:
                transform.Translate(new Vector3(.9f, -.9f, 0) * Time.deltaTime*speed);
                break;
            case 15:
                transform.Translate(new Vector3(.45f, -.9f, 0) * Time.deltaTime * speed);
                break;
            case 16:
                transform.position = Vector3.MoveTowards(transform.position, randomPos, 1 * Time.deltaTime * speed);
                counter++;
                if(counter == 20) {
                    randomPos = GenerateNewRandom();
                    counter = 0;
                }
                break;
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp((float)transform.position.x, -2.75f, 2.75f);
        pos.y = Mathf.Clamp((float)transform.position.y, -4.5f, 0f);
        transform.position = new Vector3(pos.x, pos.y, -1);
    }

    float Pythagorian(Vector2 point, Vector3 pos)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(point.x - pos.x), 2) + Mathf.Pow(Mathf.Abs(point.y - pos.y), 2)); return distance;
    }

    int getSmallest(float[] array)
    {
        float smallestVal = 11;
        int position = 0;
        for (int i = 0; i < 16; i++)
        {
            if (array[i] < smallestVal)
            {
                smallestVal = array[i];
                position = i;
            }
        }
        if (smallestVal > 2) { 
            position = 16; 
        } return position;
    }
    Vector3 GenerateNewRandom() {
        randomPos = new Vector3(Random.Range(-2.75f, 2.75f), Random.Range(-4.5f, 0f), -1); return randomPos;
    }
}
