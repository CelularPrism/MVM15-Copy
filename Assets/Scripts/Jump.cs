using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Collision collision;

    private void Start()
    {
        collision = GetComponent<Collision>();
    }

    public void doJump(Rigidbody2D rigidbody2D, float jumpForce)
    {
        if (collision.bottomOffset.y > 0) jumpForce *= -1;
        rigidbody2D.velocity = Vector3.up * jumpForce;
    }
}
