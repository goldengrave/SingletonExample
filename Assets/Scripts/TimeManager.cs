using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public int startTime;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    private void Start()
    {
        startTime = GameManager.instance.time;
        timeText.text = startTime.ToString();
        InvokeRepeating("Timer", 1, 1);
    }

    void Timer()
    {
        startTime--;
        timeText.text = startTime.ToString();
        GameManager.instance.time = startTime;
    }
}
