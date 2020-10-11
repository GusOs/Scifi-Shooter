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

    private Collider enemyCollision;

    UnityEngine.AI.NavMeshAgent enemy;

    public Sound explode;

    public GameObject destroyEffect;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyCollision = GetComponent<Collider>();
    }

    // Update is called once per frame
    /*Si la posición del jugador respecto al enemigo es menor que la distancia
     * Siempre busca al jugador
     * si la dirección es mayor de 8, cambia de animación
    */
    void Update()
    {
        MovePosition();
        DestroyStars();
    }

    private void MovePosition()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude < 12)
            {
                enemy = GetComponent<NavMeshAgent>();
                enemy.SetDestination(player.position);
                anim.SetBool("run", true);
            }
        }
    }

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

    public void DestroyHearts()
    {
        float itemLife = 2f;
        GameObject[] killHearts;
        killHearts = GameObject.FindGameObjectsWithTag("Hearts");
        {
            for (int i = 0; i < killHearts.Length; i++)
            {
                Destroy(killHearts[i].gameObject, itemLife);
            }
        }
    }
}
