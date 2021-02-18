using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject grassBlock;
    public GameObject stoneBlock;

    public int size = 10;
    public int ySize = 50;

    void Start()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (float y = 0.5f; y < ySize; y++)
                {
                    if (y > 20)
                    {
                        Instantiate(grassBlock, new Vector3(j, y, i), Quaternion.identity);
                        Blocks.instance.normalModefunc(grassBlock);
                    }
                    else
                    {
                        Instantiate(stoneBlock, new Vector3(j, y, i), Quaternion.identity);
                        Blocks.instance.normalModefunc(stoneBlock);
                    }
                }
            }
        }
    }
}
