using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Array de prefabs de box 
    public GameObject[] enemyPrefab;

    void Start()
    {
        SpawnEnemy();
    }

    //Método para spawnear las cajas aleatoriamente
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position, Quaternion.identity);
    }
}
