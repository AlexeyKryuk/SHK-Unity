using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _wanderRange;

    private Vector3 _target;

    private Vector3 _randomTarget { get => Random.insideUnitCircle * _wanderRange; }

    private void Start()
    {
        _target = _randomTarget;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, _target) <= 0.01f)
            _target = _randomTarget;
    }
}
