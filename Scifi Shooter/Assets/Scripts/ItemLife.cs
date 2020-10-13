using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    //Colision
    private Collider itemCollision;

    //Efecto al colisionar
    public GameObject lifeEffect;

    //Audio al colisionar
    public Sound life;

    //Referencia a la vida del jugador
    public GameObject lifeplayer;

    //Referencia al script del jugador
    private PlayerMovement playerScript;

    void Start()
    {
        itemCollision = GetComponent<Collider>();
    }

    /*Comprobar si ha colisionado con el jugador
     * Reproducir audio de vida
     * añadir 25 de vida al jugador
     * Instanciar el efecto de vida
     * Spawner más items
     * desactivar el item
    */
    private void OnTriggerEnter(Collider itemCollision)
    {
        if (itemCollision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(life);
            (itemCollision.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer += 25;
            //Debug.Log((itemCollision.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer);
            Instantiate(lifeEffect, this.transform.position, Quaternion.LookRotation(this.transform.position));
            GameManager.Instance.CheckGameStateItem();
            this.gameObject.SetActive(false);
        }
    }
}
