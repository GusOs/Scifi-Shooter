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
        enemy = GetComponent<NavMeshAgent>();
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
    }

    private void MovePosition()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude < 10)
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
            //Destroy effect
            Instantiate(destroyEffect, enemy.transform.position, Quaternion.LookRotation(enemy.transform.position));
            this.gameObject.SetActive(false);
            //Destroy(destroyEffect.gameObject);
        }
    }
}
