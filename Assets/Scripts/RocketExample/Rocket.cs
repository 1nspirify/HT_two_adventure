using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _force;
    [SerializeField] private float _rotationForce;

    private KeyCode _KeyEngine = KeyCode.Space;
    private bool _islaunched;
    private float _xInput;
    private string _horizontalAxis = "Horizontal";

    private float _deadZone = 0.05f;
    private int _coins;

    [SerializeField] float _maxHealth = 2;
    
    private float _currentHealth;
    
    public float CurrentHealth => _currentHealth;
    
    private void Awake()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(_horizontalAxis);
        _islaunched = Input.GetKey(_KeyEngine);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
        {
            _rigidbody.AddRelativeTorque(Vector3.back * _rotationForce * _xInput);
        }

        if (_islaunched)
        {
            _rigidbody.AddForce(transform.up * _force);
        }
    }

    public void AddCoins(int value)
    {
        _coins += value;
        Debug.Log(_coins);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"передалось дамага+{damage}");
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            gameObject.SetActive(false);
        }

        Debug.Log(_currentHealth);
    }
}