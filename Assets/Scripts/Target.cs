using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log("2");
        if (health <= 0f)
        {
            Debug.Log("2.1");
            Die();
        }
    }

    void Die()
    {
        Debug.Log("3");
        Destroy(gameObject);
    }
}
