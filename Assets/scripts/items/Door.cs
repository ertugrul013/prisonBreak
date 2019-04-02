using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;
    public bool isOpen;
    public string messageDoor;
	public AudioSource openingDoorSound;

	private BoxCollider _collider;

    [SerializeField] private Animator doorAnim;

    private void Start()
    {
		_collider = this.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (isOpen)
		{
			doorAnim.SetBool("Open",true);
			//openingDoorSound.Play();
			_collider.enabled = false;
            UIManeger.instance.statustext.text = "Find parts to build your raft";
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
          if (APIReqeust.instance.GetGender(PlayerPrefs.GetString("name")))
          {
            isOpen = !isOpen;
            return;
          }
          Debug.LogError("You have a female name so no fun for you");
        }
    }

    public void Action()
    {
        open();
    }
}
