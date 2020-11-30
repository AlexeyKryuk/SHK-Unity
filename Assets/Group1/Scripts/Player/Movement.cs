using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Damaged.AddListener((multiplier, delay) =>
            StartCoroutine(DecreaseSpeed(multiplier, delay)));
    }

    private void OnDisable()
    {
        _player.Damaged.RemoveListener((multiplier, delay) => 
            StartCoroutine(DecreaseSpeed(multiplier, delay)));
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement.normalized * _speed * Time.deltaTime);
    }

    private IEnumerator DecreaseSpeed(int multiplier, float delay)
    {
        float targetSpeed = _speed / multiplier;

        while (_speed - targetSpeed > float.Epsilon)
        {
            _speed = Mathf.Lerp(_speed, targetSpeed, delay * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
