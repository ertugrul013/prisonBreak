using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public int doorId;
    public bool isOpen;
    private float initRotation;

    private void Start()
    {
        initRotation = transform.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (isOpen && transform.rotation.eulerAngles.y < initRotation + 80) 
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,initRotation + 80,0),5 );
        }else if (!isOpen && transform.rotation.eulerAngles.y > initRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0,initRotation,0),5 );
        }
    }

    public void open()
    {
        if (doorId == -1 || Inventory.instance.checkKey(doorId))
        {
            isOpen = !isOpen;
        }
    }

    public void Action()
    {
        open();
    }
}
