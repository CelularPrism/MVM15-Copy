using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public void Walking(Rigidbody2D rigidbody2D, float direction, float speed)
    {
        rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);
    }
}
