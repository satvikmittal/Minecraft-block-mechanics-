using UnityEngine;

public class BlockPlacing : MonoBehaviour
{
    public GameObject Camera;
    public int blockReach = 4;

    public Inventory inv;

    public Transform Hotbar;

    [HideInInspector]
    public GameObject selectedSlot;
    GameObject targetObject;

    public int selectedSlotIndex;

    void Start()
    {
        SelectSlot();    
    }

    void Update()
    {
        #region Slot Selection
        int previousSlotIndex = selectedSlotIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedSlotIndex >= Hotbar.childCount - 1)
            {
                selectedSlotIndex = 0;
            }
            else
            {
                selectedSlotIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedSlotIndex <= 0)
            {
                selectedSlotIndex = Hotbar.childCount - 1;
            }
            else
            {
                selectedSlotIndex--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlotIndex = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlotIndex = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlotIndex = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlotIndex = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlotIndex = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedSlotIndex = 5;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedSlotIndex = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectedSlotIndex = 7;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectedSlotIndex = 8;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedSlotIndex = 9;
        }

        if (previousSlotIndex != selectedSlotIndex)
        {
            SelectSlot();
        }
        #endregion

        if (Input.GetMouseButtonDown(1) && selectedSlot.transform.childCount > 0)
        {
            targetObject = selectedSlot.transform.GetChild(0).GetComponent<hotbarGO>().associatedGO;
            PlaceBlock(targetObject);
        }

        if (selectedSlot.GetComponent<Slot>().NOI == 0)
        {
            DropItem();
        }
    }

    void SelectSlot()
    {
        int i = 0;
        foreach (GameObject slot in inv.slots)
        {
            if (i == selectedSlotIndex)
            {
                selectedSlot = inv.slots[i];
            }
            i++;
        }
    }

    void PlaceBlock(GameObject targetObject)
    {
        GameObject raycastObject;
        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, blockReach))
        {
            raycastObject = hit.transform.gameObject;
            GameObject placedGO = Instantiate(targetObject, new Vector3(raycastObject.transform.position.x, raycastObject.transform.position.y + 1f, raycastObject.transform.position.z), Quaternion.identity);
            Blocks.instance.normalModefunc(placedGO);
            if (selectedSlot.GetComponent<Slot>().NOI >= 1)
            {
                selectedSlot.GetComponent<Slot>().NOI--;
            }
        }
    }

    public void DropItem()
    {
        foreach (Transform child in selectedSlot.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
