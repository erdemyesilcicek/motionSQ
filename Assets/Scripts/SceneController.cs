using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static int LastGameScene { get; set; }
    public void NextScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene + 1);
    }
    public void BackScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene - 1);
    }
    public void LastScene()
    {
        SceneManager.LoadScene(LastGameScene);
    }
    public void PresentScene()
    {
        int presentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(presentScene);
    }
    public void toScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        squareMotion.IsDead = false;
        CircleController.LiveCircles = 0;
    }
    public void toGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void toMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}