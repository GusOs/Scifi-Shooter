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

    //Vida del enemigo
    public float enemyLife = 100f;

    UnityEngine.AI.NavMeshAgent nav;

    NavMeshAgent ourenemy;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    /*Si la posición del jugador respecto al enemigo es menor que la distancia
     * Siempre busca al jugador
     * si la dirección es mayor de 8, cambia de animación
    */
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetTrigger("Run_guard_AR");
            nav.speed = 2.5f;
            if (direction.magnitude < 10)
            {
                nav = GetComponent<NavMeshAgent>();
                nav.SetDestination(player.position);
                nav.speed = 0;
                anim.SetTrigger("Shoot_Autoshot_AR");
                GunEnemy.Instance.Shoot();
            }
            else
            {
                anim.SetTrigger("Run_guard_AR");
                nav.speed = 2.5f;
            }
            if(enemyLife == 0)
            {
                anim.SetTrigger("Die");
                nav.speed = 0;
            }
        }
        else
        {
            anim.SetTrigger("Run_guard_AR");
            nav.speed = 2.5f;
        }  
    }
}
