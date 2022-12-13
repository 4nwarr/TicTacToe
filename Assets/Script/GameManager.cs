using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Turn
    {
        cross,
        circle
    }

    public static GameManager Instance;
    public Turn currentTurn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SwapTurn()
    {
        if (currentTurn == Turn.cross)
            currentTurn = Turn.circle;
        else
            currentTurn = Turn.cross;
    }
}
