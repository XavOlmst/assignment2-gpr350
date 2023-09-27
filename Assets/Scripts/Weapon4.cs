using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4 : MonoBehaviour
{
    [SerializeField] private Particle2D _particle;
    [SerializeField] private float teleportDelay;
    [SerializeField] private float timeInTeleport;
    void Update()
    {
        if (_particle.elapsedTime > teleportDelay)
        {
            Integrator.Integrate(_particle, timeInTeleport);
            teleportDelay = _particle.lifeSpan + 3;
        }
    }
}
