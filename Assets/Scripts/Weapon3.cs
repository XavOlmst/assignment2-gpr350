using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Weapon3 : MonoBehaviour
{
    [SerializeField] private Particle2D _particle;
    [SerializeField] private float _timePerAccelInvert;
    private float _timeSinceLastInvert = 0;

    private void Awake()
    {
        if (Random.Range(0, 2) == 0)
            _particle.acceleration *= -1;
    }

    private void Update()
    {
        if ( _timeSinceLastInvert > _timePerAccelInvert) // i like that
        {
            _particle.acceleration *= -1;
            _timeSinceLastInvert = 0;
        }
        
        _timeSinceLastInvert += Time.deltaTime;
    }
}
