using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //double speed;
    //int counter;
    public float distanceUp = (float)10.0;
    public float distanceDown = (float)10.0;
    public float distanceLeft = (float)10.0;
    public float distanceRight = (float)10.0;
    public float distanceUpRight = (float)10.0;
    public float distanceUpLeft = (float)10.0;
    public float distanceDownRight = (float)10.0;
    public float distanceDownLeft = (float)10.0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0) * Time.deltaTime;
        transform.Translate(0, (float)-2.5, -1);
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        Vector2 Diagonal = new Vector2(-1, 1);

        //Dectect hits
        if (hit.collider != null){
            distanceUp = Mathf.Abs(hit.point.y - transform.position.y);
        }else{
            distanceUp = 10;
        }hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null){
            distanceDown = Mathf.Abs(hit.point.y - transform.position.y);
        }else{
            distanceDown = 10;
        }hit = Physics2D.Raycast(transform.position, Vector2.left);
        if (hit.collider != null){
            distanceLeft = Mathf.Abs(hit.point.x - transform.position.x);
        }else{
            distanceLeft = 10;
        }hit = Physics2D.Raycast(transform.position, -Vector2.left);
        if (hit.collider != null){
            distanceRight = Mathf.Abs(hit.point.x - transform.position.x);
        }else{
            distanceRight = 10;
        }hit = Physics2D.Raycast(transform.position, Vector2.one);
        if (hit.collider != null){
            distanceUpRight = Pythagorian(hit.point, transform.position);
        }else{
            distanceUpRight = 10;
        }hit = Physics2D.Raycast(transform.position, Diagonal);
        if (hit.collider != null){
            distanceUpLeft = Pythagorian(hit.point, transform.position);
        }else{
            distanceUpLeft = 10;
        }hit = Physics2D.Raycast(transform.position, -Diagonal);
        if (hit.collider != null){
            distanceDownRight = Pythagorian(hit.point, transform.position);
        }else{
            distanceDownRight = 10;
        }hit = Physics2D.Raycast(transform.position, -Vector2.one);
        if (hit.collider != null){
            distanceDownLeft = Pythagorian(hit.point, transform.position);
        }else{
            distanceDownLeft = 10;
        }
        float[] distances = new float[8] { distanceUp, distanceUpRight, distanceRight, distanceDownRight, distanceDown, distanceDownLeft, distanceLeft, distanceUpLeft };
        int smallest = getSmallest(distances);
        //What to do
        switch (smallest){
            case 0:
               transform.Translate(0, -.07f, 0);
               break;
            case 1:
               transform.Translate(-.06f, -.06f, 0);
               break;
            case 2:
               transform.Translate(-.07f, 0, 0);
               break;
            case 3:
               transform.Translate(-.06f, .06f, 0);
               break;
            case 4:
                transform.Translate(0, .07f, 0);
                break;
            case 5:
                transform.Translate(.06f, .06f, 0);
                break;
            case 6:
                transform.Translate(.07f, 0, 0);
                break;
            case 7:
                transform.Translate(.06f, -.06f, 0);
                break;
            case 8:
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
        for (int i = 0; i < 8; i++)
        {
            if (array[i] < smallestVal)
            {
                smallestVal = array[i];
                position = i;
            }
        }
        if (smallestVal > 2) { 
            position = 8; 
        } return position;
    }
}
