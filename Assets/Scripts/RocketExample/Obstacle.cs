using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _time;
    private float _damagePerSecond = 1;
    private float _timeBetweenDamageTicks = 0.1f;

    private float _damagePerTick;

    [SerializeField] private ParticleSystem _particleSystem;

    private void Awake()
    {
        _damagePerTick = _damagePerSecond * _timeBetweenDamageTicks;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _particleSystem.Play();
            rocket.TakeDamage(_damagePerTick);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time += Time.deltaTime;
            ContactPoint contact = collision.contacts[0];
            _particleSystem.transform.position = contact.point;
            _particleSystem.transform.rotation = Quaternion.LookRotation(-contact.normal);

            if (_time > _timeBetweenDamageTicks)
            {
                _particleSystem.Play();
                rocket.TakeDamage(_damagePerTick);
                _time = 0;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rocket rocket = collision.collider.GetComponent<Rocket>();

        if (rocket != null)
        {
            _time = 0;
        }
    }
}