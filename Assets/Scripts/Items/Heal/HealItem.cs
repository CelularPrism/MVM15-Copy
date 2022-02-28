using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour, InterfaceItems
{
    private int healPoints = 10;

    private void Start()
    {
        DataLoot loot = transform.GetComponent<Loot>().GetDataLoot(); // We get DataLoot from Loot and assign this script
        loot.interfaceItem = this;
    }

    public void UseItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HealthSystem>().Heal(healPoints);
    }
}
