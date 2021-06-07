using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static SceneSwitch current;

    private void Start()
    {
        if(current == null)
            current = this;
    }

    public void SwitchScene(int targetScene)
    {
        SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Single);
    }
}
