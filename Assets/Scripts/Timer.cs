using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTime;
    private TMP_Text timerTXT;

    private void Start()
    {
        timerTXT = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventSystem.LevelRestartedEvent += OnLevelRestarted;
    }

    private void OnDisable()
    {
        EventSystem.LevelRestartedEvent += OnLevelRestarted;
    }

    private void OnLevelRestarted()
    {
        startTime = 0f;
    }

    private void Update()
    {
        startTime += Time.deltaTime;
        int seconds = (int)(startTime % 60);
        int minutes = (int)(startTime / 60) % 60;
        int hours = (int)(startTime / 3600) % 24;

        string timerSTR = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
        timerTXT.text = timerSTR;
    }
}

