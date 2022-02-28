using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    private Vector3 oldScale;
    private void Start()
    {
        oldScale = transform.localScale;
    }

    public void SeatDown()
    {
        Vector3 newScale = transform.localScale;
        Vector3 pos = transform.position;

        transform.localScale = new Vector3(newScale.x, newScale.y / 2);
        transform.position = new Vector3(pos.x, pos.y - newScale.y / 2);
    }

    public void StandUp()
    {
        Vector3 newScale = transform.localScale;
        Vector3 pos = transform.position;

        transform.localScale = new Vector3(newScale.x, oldScale.y);
        transform.position = new Vector3(pos.x, pos.y + newScale.y / 2);
    }
}
