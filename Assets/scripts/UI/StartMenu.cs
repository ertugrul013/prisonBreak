using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public InputField name;

    public void LoadLevel()
    {
        Debug.Log(name.text);
        if (name.text == "")
        {
            return;
        }
        else
        {
        PlayerPrefs.SetString("name", name.text);
        SceneManager.LoadScene(1);
        }
    }
}
