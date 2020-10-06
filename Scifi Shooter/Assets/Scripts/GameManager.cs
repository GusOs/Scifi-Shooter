using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Instancia de la propia clase
    public static GameManager Instance;

    //Vida jugador
    public int lifePlayer;

    public bool isGameActive;

    public Sound gameOverSound;

    public EnemySpawn enemySpawner;

    public TMP_Text textLife;

    private int score;

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
            CheckDeads();
        }
    }

    public void CheckDeads()
    {
        PlayerPrefs.SetInt("All deads", score);
    }

    public void AddDead()
    {
        score++;
    }

    private void UpdateDead()
    {
        textLife.text = score.ToString();
    }

    private void CheckGameState()
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
