using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float lifeTime = 1f;
    public GameObject whatToDie;

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(whatToDie);
    }
}
