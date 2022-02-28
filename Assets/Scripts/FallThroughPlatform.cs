using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatfor;
    [SerializeField] private Collider2D playerCollider;


    void Update()
    {
        if (currentOneWayPlatfor != null)
        {
            // While Gravity is normal pressing DOWN will allow you to pass through 1-way platforms
            if (Input.GetAxisRaw("Vertical") < 0 && currentOneWayPlatfor.GetComponent<PlatformEffector2D>().rotationalOffset == 0)
            {
                StartCoroutine(DisableCollision());
            }
            // While Gravity is reversed pressing UP will allow you to pass through 1-way platforms
            else if (Input.GetAxisRaw("Vertical") > 0 && currentOneWayPlatfor.GetComponent<PlatformEffector2D>().rotationalOffset == 180)
            {
                StartCoroutine(DisableCollision());
            }
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("1-Way"))
        {
            currentOneWayPlatfor = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("1-Way"))
        {
            currentOneWayPlatfor = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatfor.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);

        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);

    }

}
