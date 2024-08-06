using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Apuntado : MonoBehaviour
{
    private CinemachineVirtualCamera camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        CambioCamara();
    }

    void CambioCamara()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            camara.Priority = 11;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            camara.Priority = 9;
        }
    }
}
