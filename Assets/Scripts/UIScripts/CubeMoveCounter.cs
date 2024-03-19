using System;
using TMPro;
using UnityEngine;

public class CubeMoveCounter : MonoBehaviour
{
    private TMP_Text moveCounterTXT;
    private int moveCounter;

    private void Start()
    {
        moveCounterTXT = GetComponent<TMP_Text>();  
    }

    private void OnEnable()
    {
        EventSystem.BlockMoveEvent += onBlockMove;
    }

    private void OnDisable()
    {
        EventSystem.BlockMoveEvent -= onBlockMove;
    }

    private void onBlockMove()
    {
        moveCounter++;
        if (moveCounterTXT!=null)
        {
            SetText();
        }     
    }

    private void SetText()
    {
       moveCounterTXT.text = String.Format("Ходов: {0}",moveCounter);
    }
}
