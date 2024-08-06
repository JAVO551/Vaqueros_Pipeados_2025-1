using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Behaviour : MonoBehaviour
{
    private Rigidbody Proyectil;
    private GameObject Objeto;
    public float timer = 0, tempo_destructor;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        Objeto = this.gameObject;
        Proyectil = GetComponent <Rigidbody>();
        //Llama a la rutina que hara todo el show
        StartCoroutine(Desactivar_BalaCoroutine());

    }

    /* Antiguo codigo usando el Update:
    void Update()
    {
        Proyectil.velocity = transform.TransformDirection (Vector3.forward*velocidad);
        timer += Time.deltaTime;
        
        if (timer > tempo_destructor) {
            Desactivar_Bala();
        }
    } */
    //Crea una corrutina llamada "Desactivar_Bala" que desactiva el objeto y reinicia el timer
    IEnumerator Desactivar_BalaCoroutine()
    {
        while (true) { //Este while actuara como el update permitiendo que todo funcione en tiempo real
        Proyectil.velocity = transform.TransformDirection (Vector3.forward*velocidad); //Mueve la bala
        yield return new WaitForSeconds(tempo_destructor); //Espera el tiempo de desaparición de la bala
        Desactivar_Bala(); //Desactiva la bala
        }
    }
    void Desactivar_Bala () {
        Objeto.SetActive(false);
        timer = 0;
    }
}
