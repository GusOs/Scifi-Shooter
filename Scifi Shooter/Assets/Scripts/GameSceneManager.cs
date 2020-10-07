using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{

    public static GameSceneManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Cambio de escena
    public void ChangeScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
