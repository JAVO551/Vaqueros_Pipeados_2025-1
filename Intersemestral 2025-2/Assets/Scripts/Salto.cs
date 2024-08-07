using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    
    public float fuerza_salto;
    public bool tocar_piso;
//Crea una variable de tipo GameObject llamada "jugador"
    public GameObject jugador;


    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       tocar_piso = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && tocar_piso) {  //tocar_piso para saber cuando esta tocando el piso
        //Input.GetKeyDown significa la deteccion de una tecla apretada y entre parentesis ponemos que tecla queremos

        //Llama la corrutina "Salto"
        StartCoroutine(Saltar_ya());
        //Comando para activar animaciones, esta es de tipo Trigger y yo le puse el no,bre del parametro/condicion "Saltar".
        tocar_piso = false;
        }
    }

    //Crea una corrutina llamada "Salto"

    IEnumerator Saltar_ya()
    {
        
        Debug.Log("El jugador salto");
         animator.SetTrigger("Salto");
        jugador.GetComponent<Rigidbody>().AddForce (Vector3.up * fuerza_salto, ForceMode.Impulse);
        tocar_piso = false;
        yield return new WaitForSeconds(3); //Espera el tiempo de desaparición de la bala
        tocar_piso = true; //Desactiva la bala
        
    }

    
   

}
