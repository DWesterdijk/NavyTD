using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringTracker : MonoBehaviour
{
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

    public static ScoringTracker current;

    private void Awake()
    {
        if (current == null)
            current = this;
    }

    [SerializeField]
    private void Update()
    {
        _livesText.text = "Lives: " + lives.ToString();
        _moneyText.text = "Money: " + money.ToString();
        _scoreText.text = "Score: " + score.ToString();
    }
}
