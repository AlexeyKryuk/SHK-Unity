using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;

    private int _boostMultiplier = 2;
    private float _boostDuration = 2f;

    private void OnEnable()
    {
        _player.EnemyKilled += () => StartCoroutine(SpeedBoost());
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

    private IEnumerator SpeedBoost()
    {
        _speed *= _boostMultiplier;
        yield return new WaitForSeconds(_boostDuration);
        _speed /= _boostMultiplier;
    }
}
