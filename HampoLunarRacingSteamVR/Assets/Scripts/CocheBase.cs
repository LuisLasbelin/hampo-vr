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

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        UpdateWheelPoses();
        //Debug.Log(circularDrive.outAngle);
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
            rearDriverW.motorTorque = inputForce;
            rearPassengerW.motorTorque = inputForce;
            return;
        }

        rearDriverW.motorTorque = 0;
        rearPassengerW.motorTorque = 0;
        //rearDriverW.motorTorque = 1 * motorForce;
        //rearPassengerW.motorTorque = 1 * motorForce;
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
        Debug.Log(angulo);
        Debug.Log(_transform.rotation.x);
        _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x, _collider.steerAngle, 0);
    }

    public float GetSpeed()
    {
        return rb.velocity.magnitude;
    }
}