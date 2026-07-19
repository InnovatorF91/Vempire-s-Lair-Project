using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBroken : MonoBehaviour
{
    [SerializeField] GameObject ElectricalSparks;

    public void Sparks()
    {
        Instantiate(ElectricalSparks, this.transform.position, this.transform.rotation);
    }
}
