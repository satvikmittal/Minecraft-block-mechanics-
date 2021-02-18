using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public static Blocks instance;

    private void Awake()
    {
        instance = this;
    }
    public void pickUpfunc(GameObject targetObject)
    {
        targetObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        targetObject.GetComponent<BoxCollider>().enabled = false;
        targetObject.layer = 9;
        targetObject.GetComponent<Target>().pickupForm = true;
    }

    public void normalModefunc(GameObject targetObject)
    {
        targetObject.transform.localScale = new Vector3(1f, 1f, 1f);
        targetObject.GetComponent<BoxCollider>().enabled = true;
        targetObject.layer = 8;
        targetObject.GetComponent<Target>().pickupForm = false;
    }
}
