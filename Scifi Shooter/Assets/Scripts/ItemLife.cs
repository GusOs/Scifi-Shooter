using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    private Collider itemCollision;

    public GameObject lifeEffect;

    public Sound life;

    public GameObject lifeplayer;

    private PlayerMovement playerScript;

    void Start()
    {
        itemCollision = GetComponent<Collider>();
    }

    //Comprobar si ha colisionado
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
