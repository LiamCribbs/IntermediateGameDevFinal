using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    public Harpoon AttachedHarpoon { get; set; }

    public float windMultiplier = 1f;

    void FixedUpdate()
    {
        rigidbody.AddForce(Weather.Wind * (windMultiplier * Time.fixedDeltaTime));
    }
}