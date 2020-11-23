using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Enemy[] _enemies;

    private int _counterKilledEnemies;

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
        _counterKilledEnemies++;

        if (_counterKilledEnemies == _enemies.Length)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        _spriteRenderer.enabled = true;
    }
}
