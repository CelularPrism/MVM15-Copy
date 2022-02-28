using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicGroundPlate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0f, Physics2D.AllLayers);

        foreach (var collider in colliders) 
            if (collider.GetComponent<HealthSystem>() != null)
            {
                HealthSystem health = collider.GetComponent<HealthSystem>();
                health.Damage(10);
                Destroy(transform.gameObject);
            }
    }
}
