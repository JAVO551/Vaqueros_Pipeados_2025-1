using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public int velocidad;
    private float hor;
    private float ver;

    Vector3 mov_x;
    Vector3 mov_y;
    Vector3 movimiento;

    //float VMouse; //Movimiento vertical del mouse en rotacion
    float HMouse; //Movimiento horizonatl del mouse en rotacion
    //float Yrotacion = 0.0f; //Variabke para guardar los cambios de rotacion
    //float Xrotacion = 0.0f; //Variabke para guardar los cambios de rotacion
    public float VelocidadHorizontal; //Sensibiliad del mouse en movimiento
    //public float VelocidadVertical; //Sensibiliad del mouse en movimiento
    Vector3 velocidad_angular;
    private Transform cameraTransform;

    public Animator animator;
    private Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        RB = GetComponent <Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookMouse();
        Movimiento_Personaje ();
    }

    void Movimiento_Personaje () {
        hor = Input.GetAxisRaw("Horizontal"); 
        ver = Input.GetAxisRaw("Vertical");

        mov_x = transform.right * hor;
        mov_y = transform.forward * ver;

        movimiento = (mov_x + mov_y).normalized * velocidad;

        //Para mover el objeto usando el rigid body:

        RB.MovePosition (RB.position + movimiento * Time.deltaTime); 
        if (hor != 0 || ver != 0) {
        animator.SetTrigger("Correr");
        }
        else {
        animator.SetTrigger("Idle");
        }
    }

    void LookMouse () {
        //VMouse = Input.GetAxis("Mouse Y") * VelocidadVertical * Time.deltaTime;
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y , 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, VelocidadHorizontal * Time.deltaTime);
        /*
        HMouse = Input.GetAxis("Mouse X") * VelocidadHorizontal;

        
        velocidad_angular = new Vector3(0, HMouse, 0);
        Quaternion deltaRotation = Quaternion.Euler(velocidad_angular * Time.deltaTime);
        RB.MoveRotation(RB.rotation * deltaRotation);
        */

        //Yrotacion -= VMouse;
        //Xrotacion += HMouse;

         //transform.Rotate (0f, HMouse, 0f); //Hace la transformacion de la nueva rotacion en el eje de las x
         
         //Tenemos que acomodar esta funcion para que se acomoden a los propios ejes de la camara (aqui usamos los propios ejes del mundos)

        //Yrotacion = Mathf.Clamp(Yrotacion, -55f, 12f); //Hace la transformacion de rotacion, pero este nos permite poner un limite a lo que podemos rotar
        
         //Tenemos que acomodar esta funcion para que se acomoden a los propios ejes de la camara (aqui usamos los propios ejes del mundos)
        
       
       
    }
}

/* Esta es una versión del movimiento que yo mismo programe, pero me dio flojera hacer todo el desmerequetengue
faltante y decidi ratearmelo todo del New Input System. Tiemp es lo que falta *-*)
    private Rigidbody RB;

using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]


[SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private InputAction moveAction;
    private InputAction jumpAction;

//Aaaa
    
    public Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Movimiento"];
        jumpAction = playerInput.actions["Salto"];
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        /* Codigo de rotación:
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetTrigger("Correr");
        } else {
            animator.SetTrigger("Idle");
        }
       
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


*/