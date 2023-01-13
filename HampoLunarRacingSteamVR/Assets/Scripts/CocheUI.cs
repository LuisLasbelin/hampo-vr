using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheUI : MonoBehaviour
{
    // angulo y velocidad
    public float minAngle, maxAngle;
    public float minVelocity, maxVelocity;
    // factor de transformacion de velocidad a angulo
    [SerializeField]
    float factor;
    // UI
    public Transform manecilla;
    // Coche con rigidbody
    CocheBase coche;

    // Start is called before the first frame update
    void Start()
    {
        coche = gameObject.GetComponent<CocheBase>();
        // Calcula el factor
        // el angulo es negativo
        factor = (minAngle - maxAngle) / (maxVelocity - minVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        float angulo = coche.GetSpeed() * factor;

        manecilla.rotation = Quaternion.Euler(manecilla.rotation.x, manecilla.rotation.y, angulo);
    }
}
