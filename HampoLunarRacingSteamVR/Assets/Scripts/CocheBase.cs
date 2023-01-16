using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CocheBase : MonoBehaviour
{
    Rigidbody rb;

    // Objeto con los datos del coche
    public Coche coche;

    // Ruedas
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;

    public int posicion = 1;

    private ControladorCarrera controladorCarrera;

    // Start is called before the first frame update
    void Start()
    {
        controladorCarrera = FindObjectOfType<ControladorCarrera>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        UpdateWheelPoses();
    }

    private void Update()
    {
        if (controladorCarrera.CarreraEmpezada)
        {
            tiempoVuelta += Time.deltaTime;
        }
    }

    public void Steer(float angulo)
    {
        frontDriverW.steerAngle = angulo;
        frontPassengerW.steerAngle = angulo;
    }

    public void Accelerate(bool state, float inputForce)
    {
        if (state)
        {
            if (rb.velocity.magnitude < coche.maximaVelocidad)
            {
                rearDriverW.motorTorque = inputForce;
                rearPassengerW.motorTorque = inputForce;
                return;
            }
        }
    }

    public void Rear(bool state, float inputForce)
    {
        if (state)
        {
            if (rb.velocity.magnitude < coche.maximaVelocidad)
            {
                rearDriverW.motorTorque = -inputForce;
                rearPassengerW.motorTorque = -inputForce;
                return;
            }
        }
    }

    /**
     * Reinicia el valor de aceleracion de las ruedas cuando no están activas
     */
    public void ResetAccel(bool accelState, bool rearState)
    {
        if(!accelState && !rearState)
        {
            rearDriverW.motorTorque = 0;
            rearPassengerW.motorTorque = 0;
        }
    }

    public void Derrapar(bool state)
    {
        if (state)
        {
            frontDriverW.brakeTorque = 20000000;
            frontPassengerW.brakeTorque = 20000000;
            rearDriverW.brakeTorque = 20000000;
            rearPassengerW.brakeTorque = 20000000;
        }
        else
        {
            frontDriverW.brakeTorque = 0;
            frontPassengerW.brakeTorque = 0;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        float angulo = Time.deltaTime * (_collider.rpm / 60 * 360);
        _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x, _collider.steerAngle, 0);
    }

    public float GetSpeed()
    {
        return rb.velocity.magnitude;
    }

    public int CheckpointActual = 0;
    public int VueltaActual = 0;

    public float tiempoVuelta;
    public List<float> tiemposVueltas = new List<float>();

    public void cruzarCheckpoint(int check)
    {
        if (check != (CheckpointActual + 1)) return;
        CheckpointActual = check;

        if (CheckpointActual < controladorCarrera.Checkpoints.Count) return;
        ActualizarVuelta();
        CheckpointActual = 0;
    }

    public void ActualizarVuelta()
    {
        VueltaActual++;
        tiemposVueltas.Add(tiempoVuelta);
        tiempoVuelta = 0;
        if (VueltaActual == controladorCarrera.VueltasTotales)
        {
            controladorCarrera.CarreraEmpezada = false;
            controladorCarrera.CarreraFinalizada = true;
            Debug.Log("Se fini");
        }
    }
}