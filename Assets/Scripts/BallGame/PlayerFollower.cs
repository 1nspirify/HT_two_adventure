using UnityEngine;

public class SceneNavigation : MonoBehaviour
{
    [SerializeField] private float _yPosition;
    [SerializeField] private int _limit;
    [SerializeField] private float _speed;
    
    private string _horizontalAxis = "Horizontal";

    private void LateUpdate()
    {
        AxisRotationY();
    }

    private void AxisRotationY()
    {
        float _axisInput = Input.GetAxisRaw(_horizontalAxis);
        float _desirableRotation = _yPosition + (_axisInput * _speed * Time.deltaTime);

        _yPosition = Mathf.Clamp(_desirableRotation, -_limit, _limit);
        transform.rotation = Quaternion.Euler(0f, _yPosition, 0f);
    }
}