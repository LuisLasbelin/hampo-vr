using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ControlFrenoMano : MonoBehaviour
{
    public bool agarrao;

    private Interactable interactable;
    private Transform transform;

    [SerializeField] private Transform freno;
    [SerializeField] private CocheBase coche;
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
            // Debug.Log(interactable.hoveringHands.Count);
            // Debug.Log(interactable.attachedToHand.name);

            Transform posicionMano = interactable.attachedToHand.transform;
            Vector3 posicionRelativa = transform.InverseTransformPoint(posicionMano.position);
            //Debug.Log(posicionRelativa);
            float angulo = Mathf.Atan2(posicionRelativa.y, posicionRelativa.z);
            angulo += Mathf.PI;
            float anguloRectificado = -angulo / (2 * Mathf.PI);
            //Debug.Log((anguloRectificado - prevAnguloRectificado) * 360);
            float anguloEnGrados = -anguloRectificado * 360;
            //float anguloEnGrados = freno.localEulerAngles.x + (anguloRectificado - prevAnguloRectificado) * 360;

            float anguloFreno = 0;


            if (anguloEnGrados > 210)
            {
                //Debug.Log("mu arriba");
                anguloFreno = -30;
                coche.Derrapar(true);
            }
            else if (anguloEnGrados < 180)
            {
                //Debug.Log("mu abajo");
                coche.Derrapar(false);
            }
            else
            {
                anguloFreno = -(anguloEnGrados - 180);
                //Debug.Log(anguloEnGrados);
                //Debug.Log(anguloFreno);
                coche.Derrapar(false);
            }

            freno.localEulerAngles = new Vector3(anguloFreno, 0, 0);
            prevAnguloRectificado = anguloRectificado;
        }
    }

    public void toogleAgarrar(bool ag)
    {
        agarrao = ag;
    }
}