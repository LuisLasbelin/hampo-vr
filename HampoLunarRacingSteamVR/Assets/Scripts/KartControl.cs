using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class KartControl : MonoBehaviour
{
    public SteamVR_Action_Boolean runAction;

    public PathFollower character;

    private SteamVR_Input_Sources hand;
    private Interactable interactable;

    // Start is called before the first frame update
    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;

            if (runAction.state) character.Accelerate();
        }
    }
}
