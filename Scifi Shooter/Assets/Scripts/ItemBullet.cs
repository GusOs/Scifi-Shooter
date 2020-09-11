using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBullet : MonoBehaviour
{
    private Collider keyCollision;

    void Start()
    {
        keyCollision = GetComponent<Collider>();
    }

    //Comprobar si ha colisionado
    private void OnTriggerEnter(Collider keyCollision)
    {
        if (keyCollision.CompareTag("Player"))
        {
            //sound effect
            //GameManager.Instance.SetScoreKey(); //Add munition
            this.gameObject.SetActive(false);
        }
    }
}
