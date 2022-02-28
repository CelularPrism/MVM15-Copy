using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool _facingRight = true;
    public void FlipChange(float _horizontal)
    {
        if (_facingRight == true && _horizontal < 0)
        {
            _facingRight = !_facingRight;
            transform.Rotate(0, 180, 0);
        }
        else if (_facingRight == false && _horizontal > 0 )
        {
            _facingRight = !_facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}
