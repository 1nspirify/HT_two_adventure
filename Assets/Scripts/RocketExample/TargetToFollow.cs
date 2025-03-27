using UnityEngine;

public class TargetToFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}