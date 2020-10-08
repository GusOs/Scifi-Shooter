using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    //Array de prefabs de corazones 
    public GameObject[] itemPrefab;

    void Start()
    {
        SpawnItem();
    }

    //Método para spawnear los corazones aleatoriamente
    public void SpawnItem()
    {
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
    }
}
