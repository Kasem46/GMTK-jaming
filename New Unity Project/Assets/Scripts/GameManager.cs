using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject healthBar;
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    //make healthbar good
    void UpdateHealth() {
        healthBar.transform.localScale = new Vector3((float)health / 20f,0.25f,1);
    }
}
