using UnityEngine.SceneManagement;

public class GameOver : NewGame
{
    public void GameIsAnd()
    {
        SceneManager.LoadScene(Scene.MainMenu);
        DeleteData();     
    }
}
