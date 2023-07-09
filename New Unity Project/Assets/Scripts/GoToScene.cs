using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void moveToGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void moveToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void moveToTutorial(){
        SceneManager.LoadScene("Tutorial");
    }
}
