using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    public void StartApp()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
