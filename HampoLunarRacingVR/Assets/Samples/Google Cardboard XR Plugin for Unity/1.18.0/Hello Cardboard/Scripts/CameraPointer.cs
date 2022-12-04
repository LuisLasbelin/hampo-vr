//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    public static CameraPointer instance;


    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    public Animator pointerAnim;
    public GameObject pointer;
    public GameObject Player;
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;

        pointer.gameObject.transform.position = transform.position + transform.forward * _maxDistance;

        // layerMask Interactiva 
        int layerMask;
        layerMask = 1 << LayerMask.NameToLayer("Interactive");

        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance,layerMask)) // hit.point   donde esta tocando el rayo 
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
                Debug.Log(_gazedAtObject);
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        //if (Google.XR.Cardboard.Api.IsTriggerPressed)
        if (Input.GetButton("A"))
        {
            //_gazedAtObject?.SendMessage("OnPointerClick",hit.transform.position);
            Player.transform.position = hit.transform.position;
        }
    }

    public void Pointing(bool state)
    {
        pointerAnim?.SetBool("Active", state);
    }
}
