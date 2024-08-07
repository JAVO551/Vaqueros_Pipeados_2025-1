using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cinemática : MonoBehaviour
{
    //Crea 4 variables públicas de tipo CinemachineVirtualCamera
    public GameObject Camara1;
    public GameObject Camara2;
    public GameObject Camara3;
    public GameObject Camara4;
    public GameObject CamaraPrincipal;
    //Haz una variable del tipo GameObject llamado "Jugador"
    public GameObject Jugador;
    // Start is called before the first frame update
    void Start()
    {
        //Llama a la corrutina "Inicio_Cinemática"
        StartCoroutine(Inicio_Cinemática());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Crea una corrutina llamada "Inicio Cinemática"    
    IEnumerator Inicio_Cinemática()
    {
        Jugador.GetComponent<Movimiento>().enabled = false;
        CamaraPrincipal.SetActive(false);
        //Llama a la corrutina Desactivar_Camara4
        StartCoroutine(Desactivar_Camara4());
        //Espera 5 segundos
        //Desactiva cada camara en orden
        yield return new WaitForSeconds(5);
        //Desactiva la cinemática
        Jugador.GetComponent<Movimiento>().enabled = true;
        CamaraPrincipal.SetActive(true);
    }
    IEnumerator Desactivar_Camara4()
    {
//LLama a la corrutina "Activar_Camara3"
        StartCoroutine(Desactivar_Camara3());    
        yield return new WaitForSeconds(2);
        Camara4.SetActive(false);
    }

    IEnumerator Desactivar_Camara3()
    {
        StartCoroutine(Desactivar_Camara2());    
        yield return new WaitForSeconds(2);
        Camara3.SetActive(false);
    }

    IEnumerator Desactivar_Camara2()
    {
        StartCoroutine(Desactivar_Camara1());    
        yield return new WaitForSeconds(2);
        Camara2.SetActive(false);
    }

    //Crea una corrutina para desactivar cada camara
    IEnumerator Desactivar_Camara1()
    {
        yield return new WaitForSeconds(2);
        //Usa SetActive para desactivar la camara
        Camara1.SetActive(false);
    }
    
    

    

    

    
}
