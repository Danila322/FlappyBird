using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _generator;
    [SerializeField] private StartScreen _screen;
    [SerializeField] private TMP_Text _bestScoreView;
    [SerializeField] private TMP_Text _score;

    private int _bestScore;

    private void OnEnable()
    {
        _screen.ButtonClicked += OnPlayButtonClick;
        _bird.ScoreChanged += OnScoreChanged;
        _bird.Died += GameOver;
    }

    private void OnDisable()
    {
        _screen.ButtonClicked -= OnPlayButtonClick;
        _bird.ScoreChanged -= OnScoreChanged;
        _bird.Died -= GameOver;
    }

    private void Awake()
    {
        Time.timeScale = 0f;
        if(GameLoader.TryGetScore(out int score))
        {
            SetBestScore(score);
        }
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }

    private void OnPlayButtonClick()
    {
        _screen.Close();
        _generator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        _bird.Restart();
    }

    private void GameOver(int score)
    {
        if(score > _bestScore)
        {
            SetBestScore(score);
            GameSaver.SaveScore(score);
        }
        _screen.Open();
        Time.timeScale = 0f;
    }

    private void SetBestScore(int score)
    {
        _bestScore = score;
        _bestScoreView.text = $"Best: {_bestScore}";
    }
}
