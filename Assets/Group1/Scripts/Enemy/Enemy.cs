using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction Died;

    public void Kill()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
