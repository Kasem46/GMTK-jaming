using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//i hate
public class GameManager : MonoBehaviour
{
    //health variables
    public GameObject healthBar;
    public int health = 100;

    //timer variables
    public float time = 150f;
    public Text timer;
    
    public StraightProjectile ProjSpawner;
    public GameObject BombSpawn;

    //ball Display
    public Text BallCount;
    public Image BallBall;

    //bomb Display
    public Text BombCount;
    public Image BombBomb;

    // Start is called before the first frame update
    void Start()
    {
        BombSpawn.GetComponent<ExplosionProjectiles>().setGameManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        UpdateHealth();
        updateBallCount();
        updateBombCount();
    }

    //make healthbar good
    void UpdateHealth()
    {
        healthBar.transform.localScale = new Vector3((float)health / 20f, 0.25f, 1);
        if (health <= 0) {
            SceneManager.LoadScene("WIN");
        }
    }

    public void takeDamage(int amount) { 
        health -= amount;
    }

    void updateTime()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            DisplayTime(time);
        }
        else
        {
            //YOU LOSE 
            SceneManager.LoadScene("LOSE");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void updateBallCount() {
        BallCount.text = "X " + ProjSpawner.ballcount;
        BallBall.color = new Color(255, 255, 255,ProjSpawner.ballInterval * 85);
    }

    void updateBombCount() {
        BombCount.text = "X " + ProjSpawner.bombCount;
        BombBomb.color = new Color(255, 255, 255, ProjSpawner.bombInterval * 31);
    }
}
