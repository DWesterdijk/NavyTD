using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(int targetScene)
    {
        SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Single);
    }
}
