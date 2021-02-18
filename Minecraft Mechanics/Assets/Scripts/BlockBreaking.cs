using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreaking : MonoBehaviour
{
    public GameObject Camera;

    public int blockReach = 4;

    public float breakingRate = 15f;

    public float damage = 1f;

    private float nextTimeToBreak = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToBreak)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, blockReach))
            {
                nextTimeToBreak = Time.time + 1 / breakingRate;

                Target target = hit.transform.gameObject.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
