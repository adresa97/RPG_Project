using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameEvents inputEvents;

    private enum GameMode { WORLD, COMBAT };
    private GameMode gameMode;

    private bool isRight;

    private void OnEnable()
    {
        inputEvents.AddListener(InputEventsCallback);
    }

    private void OnDisable()
    {
        inputEvents.RemoveListener(InputEventsCallback);
    }

    private void Start()
    {
        gameMode = GameMode.COMBAT;
        isRight = false;
    }

    private void InputEventsCallback(object data)
    {

    }
}
