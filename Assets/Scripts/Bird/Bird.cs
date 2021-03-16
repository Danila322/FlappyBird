using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> Died;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void Restart()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.enabled = true;
        _mover.ResetBird();
    }

    public void IncrementScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        _mover.enabled = false;
        Died?.Invoke(_score);
    }
}
