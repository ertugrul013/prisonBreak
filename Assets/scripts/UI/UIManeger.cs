using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{

  public static UIManeger instance;

  public Text statustext;

  public RectTransform parentUITranbsfrom;

  public Image[] UIImages = new Image[3];
  public Text[] UIText = new Text[3];

  void Awake()
  {
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        statustext.text = "Find the key to escape the prison";
    }
    else
    {
      Destroy(this);
    }
  }

  public void updateUI(Item item, int cur)
  {
      if (escapeRaft.instance.curPieces < 1)
      {
          UIText[cur - 1].text = item.objName;
          UIImages[cur - 1].sprite = item.objImage;
          UIImages[cur - 1].color = new Color32(255,255,255,255);
      }

      if (item is RaftPartItem)
      {
          escapeRaft.instance.curPieces++;
          escapeRaft.instance.IsComplete();
      }

      if (item is AccesItem)
      {
          statustext.text = "Find the escape door";
      }

      if (escapeRaft.instance.curPieces >= 3 )
      {
          statustext.text = "Find the escape raft";
      }

  }

	public void showUI()
	{
		LeanTween.moveY(parentUITranbsfrom,205f,0.5f);
	}

	public void hideUI()
	{
		LeanTween.moveY(parentUITranbsfrom,400f,0.5f);
	}

}
