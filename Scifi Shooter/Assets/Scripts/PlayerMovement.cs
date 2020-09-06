using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Velocidad del player
    public float playerSpeed = 3f;

    //Gravedad del player
    public float gravity = 9.81f;

    //Tranform del groundCheck
    public Transform groundCheck;

    //Variables input del player
    private float horizontalInput;
    private float verticalInput;

    //Variable del controlador del player
    private CharacterController characterController;

    //Velocidad para controlar la gravedad
    private Vector3 velocity;

    //Variable suelo del player
    private bool isGrounded;

    //Salto
    public float jumpHeight = 1f;

    //Variable para comprobar la distancia del suelo
    private float groundDistance = 0.35f;

    //Comprovación del suelo
    public LayerMask groundMask;

    //Si salta
    private bool isAbleToJump;

    //Vida del jugador
    public float lifePlayer = 100f;

    void Start()
    {
        //Referencia del characterController
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        ReadInputs();
        CheckGround();
        Movement();
    }

    //Leer inputs
    private void ReadInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            isAbleToJump = true;
        }else
        {
            isAbleToJump = false;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    //Movimiento del player
    private void Movement()
    {
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = 0;
        }

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        Vector3 movementDirection = Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f);

        characterController.Move(movementDirection * playerSpeed * Time.deltaTime);

        if(isAbleToJump && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
        }

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
