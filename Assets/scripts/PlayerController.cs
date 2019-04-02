﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(1, 6)] private float _range = 2f;

    private void Update()
    {
        EventHandler();
    }

    private void EventHandler()
    {
        //inventory visibility
        if (Input.GetKeyDown(KeyCode.E))
        {
          //TODO make a UI visibilty switcher
        }
        //interact
        else if(Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    private void Interact()
    {
        //ray
        //ray hit check
        //get interactable
        //if != null Action;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,_range))
        {
            IInteractable i = hit.transform.gameObject.GetComponent<IInteractable>();
            if (i != null)
            {
                i.Action();
            }
            else
            {
                escapeRaft e = hit.transform.gameObject.GetComponent<escapeRaft>();

                e.UpdateRaftStatus();
            }

        }

    }
}
