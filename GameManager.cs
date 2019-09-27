using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Setting active and disactive screen on game end screen
    public GameObject gameOverCanvas;
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
