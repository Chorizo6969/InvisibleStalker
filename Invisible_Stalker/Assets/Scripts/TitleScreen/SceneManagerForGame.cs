using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerForGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
