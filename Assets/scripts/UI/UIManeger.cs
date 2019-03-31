using UnityEngine;
using UnityEngine.UI;


///<summary>
///
///</summary>
public class UIManeger : MonoBehaviour
{
  public static UIManeger instance;

	public RectTransform parentUITranbsfrom;

  //playerInput
  public InputField nameInput;
	public string input = "Anne";

  public Text Doortext;

  public string[] inventoryText = new string[3];
  public Sprite[] inventoryImages = new Sprite[3];


  void Awake()
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

  public void updateUI()
  {
		if (Inventory.instance._items.Count == null)
		{
				return;
		}
		else
		{
    		for (int i = 0; i < Inventory.instance._items.Count; i++)
    		{
        		inventoryText[i] = Inventory.instance._items[i].objName;
						inventoryImages[i] = Inventory.instance._items[i].objImage;
    		}
			}
  }

	public void showUI()
	{
		LeanTween.moveY(parentUITranbsfrom,300f,0.5f);
	}

	public void hideUI()
	{
		LeanTween.moveY(parentUITranbsfrom,370f,0.5f);
	}

	public void startGame()
	{
		input = nameInput.text;
		GameManeger.instance.start();
	}

	public void quitGame()
	{
		Application.Quit();
	}

}
