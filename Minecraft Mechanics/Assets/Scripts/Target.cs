using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health;
    public GameObject pickUp;

    public bool pickupForm;

    private void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject pickupGO = Instantiate(pickUp, transform.position, Quaternion.identity);
        Blocks.instance.pickUpfunc(pickupGO);
        pickupGO.GetComponent<ItemPicking>().enabled = true;
    }
}
