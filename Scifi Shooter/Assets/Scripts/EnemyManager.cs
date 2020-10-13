using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    //Transform del enemigo
    public Transform player;

    //Distancia de detección
    public float distance = 15f;

    //Animator del enemigo
    public Animator anim;

    //Colision
    private Collider enemyCollision;

    UnityEngine.AI.NavMeshAgent enemy;

    //Audio de la explosión al morir
    public Sound explode;

    //Efecto al morir
    public GameObject destroyEffect;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyCollision = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePosition();
        DestroyStars();
    }

    /*Si la posición entre jugador y enemigo es menor a 15
     * el enemigo se dirige a él con la animación run
     */
    private void MovePosition()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude < 15)
            {
                enemy = GetComponent<NavMeshAgent>();
                enemy.SetDestination(player.position);
                anim.SetBool("run", true);
            }
        }
    }

    /* Cuando el enemigo colisione con el jugador
     * reproduce sonido de explosion
     * Instancia el efecto
     * Le quita 25 de vida al jugador
     * Desactiva el enemigo
     * Spawnea un nuevo enemigo
     * Comprueba si el juego ha acabado
     * Comprueba si el jugador tiene 50 o menos de vida
     */
    private void OnTriggerEnter(Collider enemyCollision)
    {
        if (enemyCollision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(explode);
            Instantiate(destroyEffect, enemy.transform.position, Quaternion.LookRotation(enemy.transform.position));
            (enemyCollision.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= 25;
            //Debug.Log((enemyCollision.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer);
            this.gameObject.SetActive(false);
            GameManager.Instance.CheckGameState();
            GameManager.Instance.GameOver();
            GameManager.Instance.LowLife();
        }
    }

    //Destruye el efecto de la explosion
    public void DestroyStars()
    {
        GameObject[] killStars;
        float itemLife = 2f;

        killStars = GameObject.FindGameObjectsWithTag("Stars");
        for (int i = 0; i < killStars.Length; i++)
        {
            Destroy(killStars[i].gameObject, itemLife);
        }
    }
}
