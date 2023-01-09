using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CocheBase : MonoBehaviour
{
    Rigidbody rb;

    // Objeto con los datos del coche
    public Coche coche;

    // Velocidad actual del coche
    public float velocity;

    // Angulo que está girando actualmente en grados
    public float anguloGiro;

    // Ruedas para el efecto visual del giro
    public Rigidbody[] ruedasGiro;

    // Vectores para usar en las formulas
    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Movimiento hacia delante/detras
        transform.Translate(forward * velocity * Time.deltaTime);

        // Rotar angulo de fuerzas
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, anguloGiro * Time.deltaTime * coche.factorGiro, 0));
    }

    /**
     * Añade velocidad al coche
     * 
     */
    virtual public void acelerar()
    {
        if (velocity + coche.factorAceleracion > coche.maximaVelocidad)
        {
            velocity = coche.maximaVelocidad;
            return;
        }

        velocity += coche.factorAceleracion;
    }

    /**
     * Quita velocidad al coche
     * 
     */
    virtual public void frenar()
    {
        Debug.Log("frenar");

        if (velocity - coche.factorFreno < 0)
        {
            velocity = 0;
            return;
        }

        velocity -= coche.factorFreno;


        //rb.AddForce(v * -coche.factorFreno * Time.deltaTime);
    }

    /**
     * Inicia un derrape
     * 
     */
    virtual public void derrapar()
    {
        Debug.Log("derrapar");
    }

    /**
     * Se llama cuando el volante gira para añadir nuevo angulo
     */
    virtual public void girar(float angle)
    {
        // Limitacion del giro
        anguloGiro = Mathf.Clamp(angle, -45, 45);
    }
}