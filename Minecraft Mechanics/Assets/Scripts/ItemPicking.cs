using System.Collections;
using UnityEngine;

public class ItemPicking : MonoBehaviour
{
    Transform player;
    public float distance = 1f;
    private Inventory inventory;
    public GameObject itemPickup;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= distance && gameObject.GetComponent<Target>().pickupForm == true)
        {
            StartCoroutine(PickUP());
        }
    }

    IEnumerator PickUP()
    {
        yield return new WaitForSeconds(1f);
        if (Vector3.Distance(player.position, transform.position) <= distance && gameObject.GetComponent<Target>().pickupForm == true)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    if (inventory.slots[i].transform.childCount == 64)
                    {
                        inventory.isFull[i] = true;
                    }

                    if (inventory.slots[i].transform.childCount > 0 && gameObject.CompareTag(inventory.slots[i].gameObject.tag))
                    {
                        inventory.slots[i].GetComponent<Slot>().NOI++;
                        Destroy(gameObject);
                        break;
                    }

                    else if (inventory.slots[i].transform.childCount == 0)
                    {
                        inventory.slots[i].GetComponent<Slot>().NOI++;
                        GameObject hotbarGO = Instantiate(itemPickup, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }     
    }
}