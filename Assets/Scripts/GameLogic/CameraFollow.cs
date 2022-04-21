using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    private Vector3 _offset;

    internal void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        transform.position = _target.position + _offset;
    }
}
