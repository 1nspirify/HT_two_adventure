using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forces : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _yForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _text.text = "Mode: Force";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _text.text = "Mode: Impulse";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _text.text = "Mode: Acceleration";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.Acceleration);
        }    
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _text.text = "Mode: Acceleration";
            _rigidbody.AddForce(Vector3.up * _yForce, ForceMode.VelocityChange);
        }
    }
}