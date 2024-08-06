using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling_Balas : MonoBehaviour
{
    public GameObject Molde ,Pivote,ManoDerecha,ManoIzquierda;
    [SerializeField] //Para que el array Disparos aparezca en el inspector
    private GameObject[] Disparos;
    private int c;
    public float velocidad;
    private Rigidbody Proyectil;
    // Start is called before the first frame update
    void Start()
    {
        //Definimos el tamaño del array metiendole GameObjects vacios
        Disparos =new GameObject[20];
        //Ahora le metemos específicamente el GameObject "Molde" a cada elemento de array
        for (c = 0; c < 20; c++)
            {
                //Llena el array de objetos
                //Con esta instrucción si dispara:
                Disparos[c] = Instantiate(Molde, Pivote.transform.position, Pivote.transform.rotation) as GameObject;

                /*
                Por alguna razon cuando lleno el array con dos instrucciones no funciones el SetActive() más abajo ._.)
                Disparos[c] = (Molde) as GameObject;
                Instantiate (Disparos[c],ManoDerecha.transform.position, ManoDerecha.transform.rotation); //Inicializa balas
                */
               
                Disparos[c].SetActive(false);
                
            }
        c=0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Pruebas:
        if (Input.GetButtonDown("Fire1")) {
        Disparos[c].SetActive(true);
        c++;
        }
        */
        
        
        if (c < Disparos.Length) {
        if (Input.GetButtonDown("Fire1")) { 
            
                
                Generacion_Bala(c);
                c+=2;
                
            } 
        } else {
                c=0;
            }
            
    }

    void Generacion_Bala(int i) {
       // Debug.Log(i);
        //Debug.Log(Disparos[i].activeSelf);
          //  Debug.Log(Disparos[i+1].activeSelf);
        if (Disparos[i].activeSelf == false) {
            Debug.Log("Disparo");
            Disparos[i].transform.position = ManoDerecha.transform.position;
            Disparos[i].transform.rotation = ManoDerecha.transform.rotation;
            Disparos[i].SetActive(true);
            
            Disparos[i+1].transform.position = ManoIzquierda.transform.position;
            Disparos[i+1].transform.rotation = ManoDerecha.transform.rotation;
            Disparos[i+1].SetActive(true);
            
            /*
            Proyectil =  Disparos[i].GetComponent<Rigidbody>();
            Proyectil.velocity = transform.TransformDirection (Vector3.forward*velocidad);
            */
        } else {
            return;
        }
    }
}
