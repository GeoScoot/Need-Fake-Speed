using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] itemsPrefabs;
    public GameObject[] carPrefabs;



    public GameObject GetRandomPrefab()
    {
        var prefab = itemsPrefabs[Random.Range(0, itemsPrefabs.Length)];
        if (prefab.tag != "Car") return prefab;
        return carPrefabs[Random.Range(0, carPrefabs.Length)];
    }
}
