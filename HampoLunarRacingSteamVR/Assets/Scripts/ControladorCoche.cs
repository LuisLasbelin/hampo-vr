using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControladorCoche : MonoBehaviour
{
    public void GetInput()
    {
        inputHorizintal = Input.GetAxis("Horizontal");
        
        inputVertical = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        anguloVolante = circularDriveVolante.outAngle;
        frontDriverW.steerAngle = anguloVolante;
        frontPassengerW.steerAngle = anguloVolante;
    }

    private void Accelerate()
    {
        if (acelerado.state)
        {
            rearDriverW.motorTorque = motorForce;
            rearPassengerW.motorTorque = motorForce;
            return;
        }
        rearDriverW.motorTorque = inputVertical * motorForce;
        rearPassengerW.motorTorque = inputVertical * motorForce;
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
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    public void Derrapar()
    {
        anguloBarraDerrape = circularDriveFrenoDeMano.outAngle;
        if (derrapar.state)
        {
            rearDriverW.brakeTorque = 20000000;
            rearPassengerW.brakeTorque = 20000000;
        }
        else
        {
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
        
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        Derrapar();
        
        //Debug.Log(circularDrive.outAngle);
    }

    private float inputHorizintal;
    private float inputVertical;
    private float anguloVolante;
    private float anguloBarraDerrape;

    public SteamVR_Action_Boolean acelerado;
    public SteamVR_Action_Boolean derrapar;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;
    public CircularDrive circularDriveVolante;
    public CircularDrive circularDriveFrenoDeMano;

}
