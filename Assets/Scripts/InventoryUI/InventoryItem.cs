using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private DataLoot dataLoot;
    public void SetDataLoot(DataLoot dataLoot)
    {
        this.dataLoot = dataLoot;
    }

    public DataLoot GetDataLoot()
    {
        return dataLoot;
    }
}
