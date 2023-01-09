using UnityEngine;

[CreateAssetMenu(fileName = "Coche", menuName = "ScriptableObjects/Coche", order = 1)]
public class Coche : ScriptableObject
{
    public string prefabName;

    public float factorAceleracion;
    public float maximaVelocidad;
    public float factorFreno;
    public float factorGiro;
    public float factorDerrape;
}