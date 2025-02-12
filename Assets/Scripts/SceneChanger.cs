using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public static void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene()
    {
        ChangeScene(_sceneName);
    }
}
