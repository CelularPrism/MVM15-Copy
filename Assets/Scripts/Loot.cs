using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    [SerializeField] private DataLoot dataLoot;
    private int count;

    private void Start()
    {
        //transform.GetComponent<SpriteRenderer>().sprite = dataLoot.sprite;
        count = 1;
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.2f, player); // We check the Player Collider
        if (collider != null)
        {
            collider.GetComponent<PlayerController>().SetLoot(dataLoot, count); // Set Loot for PlayerController
            Destroy(transform.gameObject);
        }
    }

    public DataLoot GetDataLoot()
    {
        return dataLoot;
    }
}
