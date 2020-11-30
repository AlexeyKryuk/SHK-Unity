using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private int _speedMultiplier = 2;
    private float _speedChangeInterval = 1.5f;

    public event UnityAction Died;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Damaged?.Invoke(_speedMultiplier, _speedChangeInterval);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
