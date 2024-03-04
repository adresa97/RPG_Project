using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionDirection { UP = 0, DOWN = 1, FRONT = 2, BACK = 3 };

public abstract class Unit : MonoBehaviour
{
    private int maxHealth;
    private int health;

    private const int directionBufferLength = 4;
    protected List<ActionDirection> directionBuffer = new List<ActionDirection>(directionBufferLength);

    // Health functions

    protected void SetHealth(int health)
    {
        maxHealth = health;
        this.health = health;
    }

    protected void IncreaseHealth(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    protected void DecreaseHealth(int amount)
    {
        health -= amount;
        if (health <= 0) Die();
    }

    protected void Die()
    {
        ClearDirectionBuffer();
    }

    // Commands actions

    protected void ActionUp()
    {
        AddDirection(ActionDirection.UP);
    }

    protected void ActionDown()
    {
        AddDirection(ActionDirection.DOWN);
    }

    protected void ActionFront()
    {
        AddDirection(ActionDirection.FRONT);
    }

    protected void ActionBack()
    {
        AddDirection(ActionDirection.BACK);
    }

    private void AddDirection(ActionDirection nextDirection)
    {
        if(directionBuffer.Count == directionBufferLength)
        {
            directionBuffer.RemoveAt(0);
        }
        directionBuffer.Add(nextDirection);
    }

    protected void ClearDirectionBuffer()
    {
        directionBuffer.Clear();
    }
}
