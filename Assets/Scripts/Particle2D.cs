using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Particle2D : MonoBehaviour
{
    public Vector2 velocity;
    public float damping = 0.99f;
    public float inverseMass;
    public Vector2 acceleration;
    public float speed;
    
    public float lifeSpan = 5;
    [HideInInspector] public float elapsedTime = 0;
    void FixedUpdate()
    {
        Integrator.Integrate(this, Time.deltaTime);
        
        if(elapsedTime > lifeSpan)
            Destroy(gameObject);

        elapsedTime += Time.deltaTime;
    }
}
