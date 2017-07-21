using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject terrainBasicPrefab;       // The basic terrain gameobject piece.
    public Transform spawnLocation;             // The starting location for all terrain pieces.

    [SerializeField]
    private List<GameObject> terrainActive;     // The terrain pieces which are currently active in the scene.    
    [SerializeField]
    private List<GameObject> terrainBasic;      // The pool of reusable terrain pieces.

    /* Use this for initialization. */
    private void Start()
    {
        terrainActive = new List<GameObject>();
        terrainBasic = new List<GameObject>();

        // Add the starting terrain piece to the pool.
        GameObject startingTerrain = GameObject.Find("TerrainBasic");
        terrainActive.Add(startingTerrain);
    }

    /* Update is called once per frame. */
    private void Update()
    {
        for (int i = 0; i < terrainActive.Count; ++i)
        {
            // Only for the last active terrain piece.
            if (i == (terrainActive.Count - 1))
            {
                // Check if we need to grab a new terrain piece.
                if (terrainActive[i].transform.position.x < 0)
                {
                    SpawnTerrain(GetTerrainType());
                }
            }

            // Recycle any terrain that has gone past the camera frustrum.
            if (terrainActive[i].transform.position.x < -spawnLocation.position.x)
            {
                // TODO: Add terrain types to allow us to correctly return to the correct pool.
                terrainBasic.Add(terrainActive[i]);
                terrainActive[i].SetActive(false);
                terrainActive.RemoveAt(i);
            }
        }

    }

    /* Spawns a new terrain piece. */
    private void SpawnTerrain(GameObject terrain)
    {
        GameObject newTerrain;
        if (terrainBasic.Count > 0)
        {
            // Recycle an exitsing terrain piece.
            newTerrain = terrainBasic[terrainBasic.Count - 1];
            terrainBasic.RemoveAt(terrainBasic.Count - 1);
            newTerrain.transform.position = spawnLocation.position;
            newTerrain.SetActive(true);
        }
        else
        {
            // Create a new terrain piece.
            newTerrain = Instantiate(terrain, spawnLocation.position, spawnLocation.rotation);
        }
        terrainActive.Add(newTerrain);
    }

    /* Get a random terrain type. */
    private GameObject GetTerrainType()
    {
        // TODO: Change this to encorpate multiple terrain piece types.
        return terrainBasicPrefab;
    }
}