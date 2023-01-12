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
            float angulo = Mathf.Atan2(posicionRelativa.x, posicionRelativa.z);
            angulo += Mathf.PI;
            float anguloRectificado = angulo / (2 * Mathf.PI);
            //Debug.Log((anguloRectificado - prevAnguloRectificado) * 360);
            float anguloEnGrados = volante.localEulerAngles.y + (anguloRectificado - prevAnguloRectificado) * 360;
          
            volante.localEulerAngles = new Vector3(0,anguloEnGrados,0);
            coche.Steer(anguloEnGrados);
            prevAnguloRectificado = anguloRectificado;
        }
    }

    public void toogleAgarrar(bool ag)
    {
        agarrao = ag;

        Transform posicionMano = interactable.attachedToHand.transform;
        Vector3 posicionRelativa = transform.InverseTransformPoint(posicionMano.position);
        //Debug.Log(posicionRelativa);
        float angulo = Mathf.Atan2(posicionRelativa.x, posicionRelativa.z);
        angulo += Mathf.PI;
        prevAnguloRectificado = angulo / (2 * Mathf.PI);
    }
}