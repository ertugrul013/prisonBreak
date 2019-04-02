using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;
    public bool isOpen;
    private float initRotation;
    public string messageDoor;
		public AudioSource openingDoorSound;

		private BoxCollider _collider;

		[SerializeField] private Animator doorAnim;

    private void Start()
    {
        initRotation = transform.rotation.eulerAngles.y;
				_collider = this.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (isOpen)
				{
					doorAnim.SetBool("Open",true);
					//openingDoorSound.Play();
					_collider.enabled = false;
        }
				else if (!isOpen)
				{
					doorAnim.SetBool("Open",false);
					//openingDoorSound.Play();
					_collider.enabled = true;
				}
    }

    public void open()
    {
        if (doorId == -1 || Inventory.instance.checkKey(doorId))
        {
          if (APIReqeust.instance.GetGender(UIManeger.instance.input))
          {
            isOpen = !isOpen;
            return;
          }
        }
    }

    public void Action()
    {
        open();
    }
}
