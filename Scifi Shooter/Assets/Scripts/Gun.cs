using UnityEngine;

public class Gun : MonoBehaviour
{
    // transform de la cámara
    public Transform playerCamera;

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

    //Audio disparo
    public Sound shoot;

    public float impactForce = 5f;

    public GameObject destroyEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        shootParticles.Play();
        AudioManager.Instance.PlaySound(shoot);

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out shootRaycastHit, shootDistance, shootMask))
        {
            Instantiate(hitEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal), shootRaycastHit.transform);


            if (shootRaycastHit.collider.GetComponent<Rigidbody>() != null)
            {
                shootRaycastHit.collider.GetComponent<Rigidbody>().AddForce(-shootRaycastHit.normal * impactForce);
            }

            if (shootRaycastHit.collider.CompareTag("Enemy"))
            {
                //LevelManager.Instance.levelScore++;
                //Instantiate(destroyEffect, shootRaycastHit.point, Quaternion.LookRotation(shootRaycastHit.normal));
                Destroy(shootRaycastHit.collider.gameObject);
            }
        }
    }
}
