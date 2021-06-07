using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringTracker : MonoBehaviour
{
    public static ScoringTracker current;

    [Header("Values")]
    public int lives;
    public int money;
    public int score;

    [Header("UI Elements")]
    [SerializeField]
    private Text _livesText;
    [SerializeField]
    private Text _moneyText;
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private void Update()
    {
        _livesText.text = "Lives: " + lives.ToString();
        _moneyText.text = "Money: " + money.ToString();
        _scoreText.text = "Score: " + score.ToString();

        if(lives <= 0)
        {
            SceneSwitch.current.SwitchScene(2);
        }
    }

    private void Start()
    {
        if (current != null)
            return;

        current = this;
    }
}
