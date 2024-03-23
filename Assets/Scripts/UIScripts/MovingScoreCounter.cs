using System;
using TMPro;
using UnityEngine;

public class MovingScoreCounter : MonoBehaviour
{
    private TMP_Text moveCounterTXT;
    private int moveCounter;

    private void Start()
    {
        moveCounterTXT = GetComponent<TMP_Text>();  
    }

    private void OnEnable()
    {
        EventSystem.BlockMoveEvent += OnBlockMove;
        EventSystem.LevelRestartedEvent += OnLevelRestarted;
    }

    private void OnDisable()
    {
        EventSystem.BlockMoveEvent -= OnBlockMove;
        EventSystem.LevelRestartedEvent += OnLevelRestarted;
    }

    private void OnBlockMove()
    {
        moveCounter++;
        if (moveCounterTXT!=null)
        {
            SetText();
        }     
    }

    private void OnLevelRestarted()
    {
        moveCounter = 0;
        SetText();
    }

    private void SetText()
    {
       moveCounterTXT.text = String.Format("Ходов: {0}",moveCounter);
    }
}
