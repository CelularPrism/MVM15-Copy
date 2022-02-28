using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRed : DoorGreen
{
    private void Start()
    {
        this.key = new RedKey().GetType().Name;
    }
}
