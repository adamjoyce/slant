using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject terrainPrefab;            // The terrain gameobject that is spawned.

    private List<GameObject> terrainPool;       // The pool of existing terrain pieces.

    /* Use this for initialization. */
    void Start()
    {
        terrainPool = new List<GameObject>();

        // Add the starting terrain piece to the pool.
        GameObject startingTerrain = GameObject.Find("TerrainBasic");
        terrainPool.Add(startingTerrain);
    }

    /* Update is called once per frame. */
    void Update()
    {

    }
}