using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Instancia de la propia clase
    public static GameManager Instance;

    public GameObject lifeplayer;

    private PlayerMovement playerScript;

    public bool isGameActive;

    public Sound gameOverSound;

    public EnemySpawn enemySpawner;

    public GameObject panelGameOver;

    public TMP_Text textDeaths;

    private int score;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    private void Start()
    {
        playerScript = lifeplayer.GetComponent<PlayerMovement>();
        Time.timeScale = 1;
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
        if(playerScript.lifePlayer == 0)
        {
            AudioManager.Instance.PlaySound(gameOverSound);
            isGameActive = false;
            panelGameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
    }

    public void AddDead()
    {
        score++;
    }

    private void UpdateDead()
    {
        textDeaths.text = score.ToString();
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
