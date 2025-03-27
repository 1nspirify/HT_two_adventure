using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private int _angle;
    
    private int _positiveAngle = 1;
    private int _negativeAngle = -1;

    private void Awake()
    {
        _angle = DetermineAngle();
    }

    private void Update()
    {
        SelfRotation();
    }

    private int DetermineAngle()
    {
        int _direction = Random.Range(0, 2);
        _direction = (_direction == 0) ? _positiveAngle : _negativeAngle;
        return _direction;
    }

    private void SelfRotation()
    {
        transform.Rotate(Vector3.up, (_angle * _rotationSpeed) * Time.deltaTime);
    }
}