using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _range;

    private Vector2 _target;

    private void Start()
    {
        _target = GetRandomTarget();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, _target) <= 0.01f)
            _target = GetRandomTarget();
    }

    private Vector2 GetRandomTarget()
    {
        return Random.insideUnitCircle * _range;
    }
}
