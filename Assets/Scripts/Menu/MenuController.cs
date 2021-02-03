using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string playGame = null;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGame);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
