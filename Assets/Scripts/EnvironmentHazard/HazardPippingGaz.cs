using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPippingGaz : MonoBehaviour
{
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f, Physics2D.AllLayers);

        foreach (var collider in colliders)
            if (collider.GetComponent<HealthSystem>() != null)
            {
                HealthSystem health = collider.GetComponent<HealthSystem>();
                float timePoison = Mathf.Floor(Time.time) + 4f;
                health.Poisoning(timePoison, 1);
                Destroy(transform.gameObject);
            }
    }
}
