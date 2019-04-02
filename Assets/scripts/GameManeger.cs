using UnityEngine;
using System.Collections;

public class GameManeger : MonoBehaviour
{

	public static GameManeger instance;

	private void Awake()
	{
		if (instance == null)
		{
				instance = this;
				DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
				UIManeger.instance.showUI();
		}
		else if (Input.GetKeyDown(KeyCode.T))
		{
				UIManeger.instance.hideUI();
		}
	}

	public void start()
	{
			Debug.Log("hallo");
	}
}
