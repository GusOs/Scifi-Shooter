using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Array de prefabs de enemigos
    public GameObject[] enemyPrefab;

    void Start()
    {
        SpawnEnemy();
    }

    //Método para spawnear los enemigos aleatoriamente
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], transform.position, Quaternion.identity);
    }
}
