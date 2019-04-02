using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class escapeRaft : MonoBehaviour
{
	public static escapeRaft instance;
	private int neededPieces = 3;
	public int curPieces;
	[SerializeField] private GameObject Raftobject;
	private bool isReady;

	public void Awake()
	{
		instance = this;
	}

	public void UpdateRaftStatus()
	{
		if (isReady)
		{
			Raftobject.SetActive(true);
		}
	}

	public void IsComplete()
	{
		if (curPieces == neededPieces)
		{
			isReady = true;
			UpdateRaftStatus();
		}
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player" && isReady)
		{
			SceneManager.LoadScene(2);
	    }
	}
}
