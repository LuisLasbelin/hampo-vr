using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorIA : MonoBehaviour
{
    CocheBase controlCoche;
    private Coche coche;

    private ControladorCarrera controladorCarrera;
    [SerializeField] private LayerMask layer;
    private float girar = 0;
    private bool acelerar = true;

    [SerializeField] private GameObject volante;

    // Start is called before the first frame update
    void Start()
    {
        controladorCarrera = FindObjectOfType<ControladorCarrera>();
        controlCoche = gameObject.GetComponent<CocheBase>();
        coche = controlCoche.coche;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controladorCarrera.CarreraEmpezada)
        {
            controlCoche.Accelerate(acelerar, coche.factorAceleracion);
            controlCoche.Steer(girar);
            volante.transform.localEulerAngles = new Vector3(0, girar, 0);
        }
    }

    private void Update()
    {
        acelerar = true;


        Physics.Raycast(transform.position, Quaternion.Euler(0, -1.0f, 0) * transform.forward, out RaycastHit hitFI, 20,
            layer);

        Physics.Raycast(transform.position, Quaternion.Euler(0, 1.0f, 0) * transform.forward, out RaycastHit hitFD, 20,
            layer);

        Physics.Raycast(transform.position + new Vector3(0, 1, 0), -transform.right, out RaycastHit hitI, 2,
            layer);

        Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.right, out RaycastHit hitD, 2,
            layer);

        float distanciaIzq = (hitFI.distance != 0) ? hitFI.distance : 20;
        float distanciaDer = (hitFD.distance != 0) ? hitFD.distance : 20;
        float distanciaLatIzq = (hitI.distance != 0) ? hitI.distance : 2;
        float distanciaLatDer = (hitD.distance != 0) ? hitD.distance : 2;

        Debug.DrawLine(transform.position, hitFD.point, Color.blue);
        Debug.DrawLine(transform.position, hitFI.point, Color.red);

        float distanciaRelativa = distanciaDer - distanciaIzq;
        float distanciaRelativaLat = distanciaLatDer - distanciaLatIzq;

        float distanciaPared = distanciaDer > distanciaIzq ? distanciaDer : distanciaIzq;
        float distanciaLatPared = distanciaLatDer > distanciaLatIzq ? distanciaLatDer : distanciaLatIzq;

        if (distanciaRelativa > 0)
        {
            girar += Time.deltaTime * (20 - distanciaPared) * 5;
            if (girar > 30)
            {
                girar = 30;
            }
        }
        else if (distanciaRelativa < 0)
        {
            girar -= Time.deltaTime * (20 - distanciaPared) * 5;
            if (girar < -30)
            {
                girar = -30;
            }
        }
        else
        {
            if (distanciaRelativaLat > 0)
            {
                transform.Translate(new Vector3(0.1f, 0, 0));
            }
            else if (distanciaRelativaLat < 0)
            {
                transform.Translate(new Vector3(-0.1f, 0, 0));
            }
            else
            {
                girar = 0;
            }
        }
    }
}