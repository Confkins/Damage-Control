using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystems : SystemSuper
{
    public ShipSystems()
    { 

    }

    public void OnTriggerEnter(Collider other)
    {
        Dismantle();
    }
}
