using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Instancia de la propia clase
    public static GameManager Instance;

    //Referencia al objeto de la vida del jugador
    public GameObject lifeplayer;

    //Referencia al script del jugador
    private PlayerMovement playerScript;

    //Variable para comprobar que el juego está activo
    public bool isGameActive;

    //Variable música gameover
    public Sound gameOverSound;

    //Objeto spawn del enemigo
    public EnemySpawn enemySpawner;

    //Segundo objeto spawn del enemigo
    public EnemySpawn enemySpawner2;

    //Objeto spawn del item
    public ItemSpawn itemSpawner;

    //Segundo objecto del spawn del item
    public ItemSpawn itemSpawner2;

    //Objeto del panel gameover
    public GameObject panelGameOver;

    //Texto para indicar el número de muertes
    public TMP_Text textDeaths;

    //Variable para ir sumando muertes
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

    //Comprueba el game over

    /* Si el jugador tiene 0 vidas
    * Se llama al audio del gameover
    * se cambia el juego a inactivo
    * se activa el panel game over
    * se activa el cursor
    * y se congela el juego
     */
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
    //Añade muertes
    public void AddDead()
    {
        score++;
    }
    //Cambia el texto a string
    private void UpdateDead()
    {
        textDeaths.text = score.ToString();
    }
    //Empieza la corrutina del spawn de enemigos
    public void CheckGameState()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }
    //Empieza la corrutina del spawn de items
    public void CheckGameStateItem()
    {
        StartCoroutine(SpawnItemCoroutine());
    }

    //spawn de enemigos
    public IEnumerator SpawnEnemyCoroutine()
    {
        int wait_time = Random.Range(4, 8);
        yield return new WaitForSeconds(wait_time);
        enemySpawner.SpawnEnemy();
        enemySpawner2.SpawnEnemy();
    }

    //spawn de items
    public IEnumerator SpawnItemCoroutine()
    {
        int wait_time = Random.Range(6, 15);
        yield return new WaitForSeconds(wait_time);
        itemSpawner.SpawnItem();
        itemSpawner2.SpawnItem();
    }

    /*Comprueba si el jugador tiene 50 de vida o menos
     * Baja la velocidad y no tiene salto
     * en caso de recuperar la vida
     * se recuperan los estados
     */
    public void LowLife()
    {
        if(playerScript.lifePlayer <= 50)
        {
            playerScript.playerSpeed = 1.5f;
            playerScript.jumpHeight = 0;
        }
        else
        {
            playerScript.playerSpeed = 3.5f;
            playerScript.jumpHeight = 1;
        }
    }
}
