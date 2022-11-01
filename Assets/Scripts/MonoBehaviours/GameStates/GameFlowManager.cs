using UnityEngine;
using Feto;
using UnityEngine.SceneManagement;

public class GameFlowManager : Singleton<GameFlowManager>
{
    private void Start() {
        Application.targetFrameRate = 60;
    }

    public void MainMenu() {
        SceneManager.LoadScene((int)Scene.MAIN_MENU);
    }

    public void GamePlay() {
        SceneManager.LoadScene((int)Scene.GAMEPLAY);
    }

    public void EndGame() {
        SceneManager.LoadScene((int)Scene.END_GAME);
    }
}
