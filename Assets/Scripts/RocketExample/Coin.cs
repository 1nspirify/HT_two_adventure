using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    [SerializeField] int _minValue;
    [SerializeField] int _maxValue;

    private void OnTriggerEnter(Collider other)
    {
        Rocket rocket = other.GetComponent<Rocket>();
        
        if (rocket != null)
        {
            int value = Random.Range(_minValue, _maxValue+1);
            
            rocket.AddCoins(value);
            gameObject.SetActive(false);
        }
    }
}