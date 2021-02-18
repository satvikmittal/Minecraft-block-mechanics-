using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public bool[] slotISFull;

    public bool[] isFull;
    public GameObject[] slots;
}
