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
	public string input = "tom";

  public Text Doortext;

  private string[] inventoryText = new string[3];
  private Sprite[] inventoryImages = new Sprite[3];

	public Image[] UIImages = new Image[3];
	public Text[] UIText = new Text[3];


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

  public void updateUI(Item item, int cur)
  {
			UIText[cur - 1].text = item.objName;
			UIImages[cur - 1].sprite = item.objImage;
  }

	public void showUI()
	{
		LeanTween.moveY(parentUITranbsfrom,205f,0.5f);
	}

	public void hideUI()
	{
		LeanTween.moveY(parentUITranbsfrom,400f,0.5f);
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
