using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Application.targetFrameRate = 200;
        // Application.targetFrameRate = 30;
    }
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.forward * 10);
        }
    }
}