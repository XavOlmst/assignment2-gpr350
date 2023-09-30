using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Weapon1 : MonoBehaviour
{
    [SerializeField] private Particle2D _particle;          // i suggest using easier to understand names
    [SerializeField] private GameObject _particlePrefab;    // for example _particleComponent and _particleToSpawnPrefab
    [SerializeField] private int _numSpawnedParticles = 3;

    void Start()
    {
        if (_particle == null)
            _particle = GetComponent<Particle2D>();
    }

    private void Update()
    {
        if (_particle.elapsedTime >= _particle.lifeSpan - 0.1f)
        {
            float angleSeparation = 360.0f / _numSpawnedParticles;

            float startAngle = Random.Range(0, angleSeparation);

            for (int i = 0; i < _numSpawnedParticles; i++)
            {
                // all good here
                Particle2D spawnedParticle = Instantiate(_particlePrefab, transform.position, Quaternion.identity)
                    .GetComponent<Particle2D>();
                spawnedParticle.velocity *= new Vector2(Mathf.Cos((angleSeparation * i + startAngle) * Mathf.Deg2Rad),
                    Mathf.Sin((angleSeparation * i + angleSeparation) * Mathf.Deg2Rad)).normalized;
            }

            Destroy(gameObject);
        }
    }
}
