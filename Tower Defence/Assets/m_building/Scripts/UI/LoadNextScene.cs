using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void NextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
