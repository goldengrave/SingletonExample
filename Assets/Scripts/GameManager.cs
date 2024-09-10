using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int time;
    public int nextLevelId;


    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GameManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        //respond to goalReached Event
        Goal.goalReached += changeLevel;
    }

    public void changeLevel()
    {
        SceneManager.LoadScene(nextLevelId);
        nextLevelId++;
    }
}
