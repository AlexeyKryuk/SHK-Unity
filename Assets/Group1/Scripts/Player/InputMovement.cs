using System.Collections;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private int _speedMultiplier = 2;
    private float _speedChangeInterval = 1.5f;

    private void Start()
    {
        StartCoroutine(DecreaseSpeed(_speedMultiplier));
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        transform.Translate(movement.normalized * _speed * Time.deltaTime);
    }

    private IEnumerator DecreaseSpeed(int multiplier)
    {
        yield return new WaitForSeconds(_speedChangeInterval);

        _speed /= multiplier;
    }
}
