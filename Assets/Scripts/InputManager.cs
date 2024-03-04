using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameEvents inputEvents;

    private string actionMap;

    private PlayerInput playerIn;

    public void Start()
    {
        playerIn = gameObject.GetComponent<PlayerInput>();
        actionMap = playerIn.defaultActionMap;
    }

    // World inputs
    private Vector2 lastMove = Vector2.zero;

    public void OnMovement(InputAction.CallbackContext context)
    {

    }

    // Combat inputs
    [SerializeField]
    private float delaySeconds;

    private Coroutine delayTime;

    public void OnDirection(InputAction.CallbackContext context)
    {
        Vector2 inputDirection = context.ReadValue<Vector2>();

        if (delayTime == null)
        {
            inputEvents.Emit(new InputDirectionEvent(inputDirection));
            delayTime = StartCoroutine(DelayedInput());
        }
    }

    public void OnLeftMenu(InputAction.CallbackContext context)
    {
        if (delayTime == null)
        {
            inputEvents.Emit(new InputLeftBumperEvent());
            delayTime = StartCoroutine(DelayedInput());
        }
    }

    public void OnRightMenu(InputAction.CallbackContext context)
    {
        if(delayTime == null)
        {
            inputEvents.Emit(new InputRightBumperEvent());
            delayTime = StartCoroutine(DelayedInput());
        }
    }

    private IEnumerator DelayedInput()
    {
        yield return new WaitForSecondsRealtime(delaySeconds);

        StopCoroutine(delayTime);
    }
}
