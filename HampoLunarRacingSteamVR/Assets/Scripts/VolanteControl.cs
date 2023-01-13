using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VolanteControl : MonoBehaviour
{
    public bool agarrao;

    private Interactable interactable;
    private Transform transform;

    [SerializeField] private Transform volante;
    [SerializeField] private CocheBase coche;
    [SerializeField] private float MaxAnnguloVolante = 60;
    private float prevAnguloRectificado;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agarrao)
        {

            Transform posicionMano = interactable.attachedToHand.transform;
            Vector3 posicionRelativa = transform.InverseTransformPoint(posicionMano.position);
            float angulo = Mathf.Atan2(posicionRelativa.x, posicionRelativa.z);
            angulo += Mathf.PI;
            float anguloRectificado = angulo / (2 * Mathf.PI);
            float anguloEnGrados = anguloRectificado * 360;


            float anguloVolante = 0;

            if (anguloEnGrados < 300 && anguloEnGrados > 180)
            {
                anguloVolante = -MaxAnnguloVolante;
            }
            else if (anguloEnGrados > MaxAnnguloVolante && anguloEnGrados < 180)
            {
                anguloVolante = MaxAnnguloVolante;
            }
            else if (anguloEnGrados > 300 && anguloEnGrados < 360)
            {
                anguloVolante = anguloEnGrados - 360;
            }else
            {
                anguloVolante = anguloEnGrados;

            }

            volante.localEulerAngles = new Vector3(0, anguloVolante, 0);


            coche.Steer(anguloVolante / MaxAnnguloVolante * coche.maxSteerAngle);
            prevAnguloRectificado = anguloRectificado;
        }
        else
        {
            if (volante.localEulerAngles.y > 180)
            {
                if (volante.localEulerAngles.y + Time.deltaTime > 360)
                {
                    volante.localEulerAngles = new Vector3(0, volante.localEulerAngles.y + Time.deltaTime, 0);
                }
                else
                {
                    volante.localEulerAngles = new Vector3(0, 0, 0);
                    coche.Steer(0);
                }
            }
            else
            {
                if (volante.localEulerAngles.y - Time.deltaTime < 0)
                {
                    volante.localEulerAngles = new Vector3(0, volante.localEulerAngles.y - Time.deltaTime, 0);
                }
                else
                {
                    volante.localEulerAngles = new Vector3(0, 0, 0);
                    coche.Steer(0);
                }
            }
        }
    }

    public void toogleAgarrar(bool ag)
    {
        agarrao = ag;
    }
}