using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OpenImageScene()
    {
        SceneManager.LoadScene("ImageScene");
    }

    public void OpenSubTopicScene()
    {
        SceneManager.LoadScene("SubTopicScene");
    }

    public void OpenVideoScene()
    {
        SceneManager.LoadScene("VideoScene");
    }

    public void OpenTextScene()
    {
        SceneManager.LoadScene("TextScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
