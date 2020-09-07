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


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*Si la posición del jugador respecto al enemigo es menor que la distancia
     * Siempre busca al jugador
     * si la dirección es mayor de 5, cambia de animación
    */
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("Idle_guard_AR", false);
            if (direction.magnitude > 8)
            {
                nav = GetComponent<NavMeshAgent>();
                nav.SetDestination(player.position);
                anim.SetBool("Shoot_Autoshot_AR", true);
            }
            else
            {
                anim.SetBool("Run_guard_AR", true);
                anim.SetBool("Shoot_Autoshot_AR", false);
            }
        }
        else
        {
            anim.SetBool("Idle_guard_AR", true);
            anim.SetBool("Run_guard_AR", false);
            anim.SetBool("Shoot_Autoshot_AR", false);
        }  
    }
}
