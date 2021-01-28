using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;
    [SerializeField] private Text _scoreText;
    private int _score = 0;

    private void Start()
    {
        instance = this;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
