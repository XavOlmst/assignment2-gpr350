using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [SerializeField] private Particle2D _particle;
    private Vector2 _initVelocity;

    private void Start()
    {
        _initVelocity = _particle.velocity;
    }

    void Update()
    {
        // clever
        _particle.velocity = new Vector2(Mathf.Cos(_particle.elapsedTime) * _initVelocity.x, Mathf.Sin(_particle.elapsedTime) * _initVelocity.y);
    }
}
