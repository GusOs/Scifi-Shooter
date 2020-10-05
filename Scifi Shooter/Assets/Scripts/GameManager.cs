using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Instancia de la propia clase
    public static GameManager Instance;

    //Vida jugador
    public int lifePlayer;

    public bool isGameActive;

    public Sound gameOverSound;

    public EnemySpawn enemySpawner;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    public void SetDeads()
    {
        if (isGameActive)
        {
            AddDead();
            UpdateDead();
            CheckGameState();
        }
    }

    public void GameOver()
    {
        if(lifePlayer == 0 && isGameActive)
        {
            AudioManager.Instance.PlaySound(gameOverSound);
            isGameActive = false;
        }
    }

    public void CheckDeads()
    {

    }

    public void AddDead()
    {

    }

    private void UpdateDead()
    {

    }

    public void CheckGameState()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    //spawn de cajas
    private IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        enemySpawner.SpawnEnemy();
    }
}
