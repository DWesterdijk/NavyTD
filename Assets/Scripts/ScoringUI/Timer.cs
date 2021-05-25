using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Set Time")]
    public int minutes;
    public float seconds;

    [Header("Text objects")]
    [SerializeField]
    private Text _minutesText;
    [SerializeField]
    private Text _secondsText;

    public void Update()
    {
        if (minutes > 0 && seconds > 0)
        {
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
            }
            if (seconds <= 0)
            {
                minutes--;
                seconds = 60;
            }
        }
        else if (minutes <= 0 && seconds <= 0)
        {
            SceneManager.LoadSceneAsync(2/*You lose screen*/, LoadSceneMode.Single);
        }

        _minutesText.text = minutes.ToString();
        _secondsText.text = RoundSeconds(seconds).ToString();
    }

    public static float RoundSeconds(float s)
    {
        return s - (s % 1f);
    }
}
