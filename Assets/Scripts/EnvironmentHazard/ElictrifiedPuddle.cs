using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElictrifiedPuddle : MonoBehaviour
{
    private float timeNextStun = 0f;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f, Physics2D.AllLayers);

        foreach (var collider in colliders)
            if (collider.GetComponent<HealthSystem>() != null && Time.time > timeNextStun)
            {
                HealthSystem health = collider.GetComponent<HealthSystem>();
                health.Damage(10);

                PlayerController player = collider.GetComponent<PlayerController>();
                timeNextStun = Mathf.Round(Time.time) + 5f;
                float time = Mathf.Round(Time.time) + 2f;
                player.Stun(time);
            }
    }
}
