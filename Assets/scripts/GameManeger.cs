using UnityEngine;
using System.Collections;

public class GameManeger : MonoBehaviour
{

	public static GameManeger instance;

	private bool Paused;
	private bool UIShowing;

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

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log("Updating");
			if (UIShowing)
			{
				UIManeger.instance.showUI();
				UIShowing = !UIShowing;
			}
			else if (!UIShowing)
			{
				UIManeger.instance.hideUI();
				UIShowing = !UIShowing;
			}
		}

		//the reason why it is mapped to Q instead of escape is because escape doesnt work in
		//the editor wont work with escape.
		if (Input.GetKeyDown(KeyCode.Q))
		{
			PauseGame();
			Paused = !Paused;
		}
	}

	public void start()
	{
			Debug.Log("hallo");
	}

	void PauseGame()
	{
		if (Paused)
		{
			Time.timeScale = 0;
		}
		else if (!Paused)
		{
			Time.timeScale = 1;
		}
	}

	public void quitGame()
	{
		Application.Quit();
	}

}
