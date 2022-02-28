using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot", menuName = "Scriptable objects/Loot")]
public class DataLoot : ScriptableObject
{
    public string Name;
    public string Info;

    public Sprite sprite;
    public InterfaceItems interfaceItem;
}
