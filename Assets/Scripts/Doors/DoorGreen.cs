using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGreen : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    public string key { get; set; } = new GreenKey().GetType().Name;

    void Update()
    {
        Vector2 size = new Vector2(transform.localScale.x + 1f, transform.localScale.y);

        Collider2D collider = Physics2D.OverlapBox(transform.position, size, 0f, playerMask);
        if (collider != null)
        {

            if (collider.GetComponent<PlayerController>().GetLoot(key, 1))
            {
                Destroy(transform.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 size = new Vector2(transform.localScale.x + 1f, transform.localScale.y);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, size);
    }
}
