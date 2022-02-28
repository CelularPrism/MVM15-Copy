using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;

    public void Damage(int points)
    {
        health -= points;
        if (health <= 0)
            Destroy(transform.gameObject);
    }
}
