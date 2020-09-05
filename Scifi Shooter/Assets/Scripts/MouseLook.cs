using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Sensibilidad del ratón
    public float mouseSensitivity = 65f;

    //Variable transform del player
    public Transform playerTransform;

    //RotacionX de la cámara
    private float rotationX = 0f;

    void Start()
    {
        //Cursor bloqueado
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //Variables Y e X del movimiento ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
