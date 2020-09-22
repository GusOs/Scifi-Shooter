using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    public static GunEnemy Instance;

    //Distancia de disparo
    public float shootDistance = 30f;

    //Variable Raycast
    private RaycastHit shootRaycastHit;

    //Máscara para poder limitar a que disparar
    public LayerMask shootMask;

    //Particulas del disparo
    public ParticleSystem shootParticles;

    //Efecto de colisión de disparo
    public GameObject hitEffect;

    //Daño del arma
    public float weaponDamage = 5f;

    //Audio disparo
    public Sound shoot;

    //Transform de la arma
    public Transform weaponEnemy;


    public void Shoot()
    {
        shootParticles.Play();
        AudioManager.Instance.PlaySound(shoot);
        
        if (Physics.Raycast(weaponEnemy.position, weaponEnemy.forward, out shootRaycastHit, shootDistance, shootMask))
        {
            Instantiate(hitEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal));
        }
    }
}
