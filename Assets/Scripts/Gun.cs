using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Time = Codice.Client.Common.Time;

public class Gun : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private List<GameObject> _weaponPrefabs;
    private int _curWeaponIndex = 0;
    /// <summary>
    /// The direction of the initial velocity of the fired projectile. That is,
    /// this is the direction the gun is aiming in.
    /// </summary>
    public Vector3 FireDirection
    {
        get
        {
            return transform.up;
        }
    }

    /// <summary>
    /// The position in world space where a projectile will be spawned when
    /// Fire() is called.
    /// </summary>
    public Vector3 SpawnPosition
    {
        get
        {
            return transform.position;
        }
    }

    /// <summary>
    /// The currently selected weapon object, an instance of which will be
    /// created when Fire() is called.
    /// </summary>
    public GameObject CurrentWeapon
    {
        get
        {
            return _weaponPrefabs[_curWeaponIndex];
        }
    }

    /// <summary>
    /// Spawns the currently active projectile, firing it in the direction of
    /// FireDirection.
    /// </summary>
    /// <returns>The newly created GameObject.</returns>
    public GameObject Fire()
    {
        GameObject spawnedWeapon = Instantiate(CurrentWeapon, SpawnPosition, Quaternion.identity);
        Particle2D weaponParticle = spawnedWeapon.GetComponent<Particle2D>();
        weaponParticle.velocity = FireDirection.normalized * weaponParticle.speed;
        
        
        return spawnedWeapon;
    }

    /// <summary>
    /// Moves to the next weapon. If the last weapon is selected, calling this
    /// again will roll over to the first weapon again. For example, if there
    /// are 4 weapons, calling this 4 times will end up with the same weapon
    /// selected as if it was called 0 times.
    /// </summary>
    public void CycleNextWeapon()
    {
        // TODO: YOUR CODE HERE // cleaner to remove these
        if (_curWeaponIndex == _weaponPrefabs.Count - 1)
            _curWeaponIndex = 0;
        else
            _curWeaponIndex++;
    }

    void Update()
    {
        // cleaner to remove these comments
        // TODO: YOUR CODE HERE (handle all input in Update, not FixedUpdate!)
        
        if (Keyboard.current.enterKey.wasPressedThisFrame)
            Fire();

        if(Keyboard.current.wKey.wasPressedThisFrame)
            CycleNextWeapon();
        
        if (Keyboard.current.digit1Key.isPressed)
            transform.Rotate(0, 0, rotateSpeed * UnityEngine.Time.fixedDeltaTime); // clean to use .Rotate
        
        if (Keyboard.current.digit2Key.isPressed)
            transform.Rotate(0, 0, -rotateSpeed * UnityEngine.Time.fixedDeltaTime);
    }
}
