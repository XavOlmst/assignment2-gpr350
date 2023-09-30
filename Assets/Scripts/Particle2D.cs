using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Particle2D : MonoBehaviour
{
    public Vector2 velocity;
    public float damping = 0.99f;
    public float inverseMass;
    public Vector2 acceleration;
    public float speed; // good to expose it to the user
    
    public float lifeSpan = 5;
    [HideInInspector] public float elapsedTime = 0;
    void FixedUpdate()
    {
        Integrator.Integrate(this, Time.deltaTime);
        
        if(elapsedTime > lifeSpan)  // i suggest the use of {} all the times, they enforced it at Eidos,
            Destroy(gameObject);    // but enforced this form at GIRO so you might be right

        elapsedTime += Time.deltaTime;
    }
}
