using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void GoShop()
    {
        DazenKillManager.Instance.Daze++;
        SceneManager.LoadScene(1);
    }

    public void GoGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
