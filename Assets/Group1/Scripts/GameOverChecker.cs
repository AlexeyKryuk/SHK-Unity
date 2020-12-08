using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _windowOfLosing;
    [SerializeField] private Enemy[] _enemies;

    private int _killedEnemies;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDied;
        }
    }

    private void OnEnemyDied()
    {
        _killedEnemies++;

        if (_killedEnemies == _enemies.Length)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        _windowOfLosing.enabled = true;
    }
}
