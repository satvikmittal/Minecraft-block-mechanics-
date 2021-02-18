using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    private BlockPlacing blockPlacing;
    public int i;

    [HideInInspector]
    public int NOI;

    public Text NOIGO;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
        blockPlacing = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockPlacing>();
        NOIGO.gameObject.SetActive(false);
    }

    void Update()
    {
        NOIGO.text = NOI.ToString();  

        if (transform.childCount <= 0) 
        {
            inventory.isFull[i] = false;
        }

        if (NOI > 1)
        {
            NOIGO.gameObject.SetActive(true);
        }
        else
        {
            NOIGO.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q) && blockPlacing.selectedSlot == gameObject)
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
