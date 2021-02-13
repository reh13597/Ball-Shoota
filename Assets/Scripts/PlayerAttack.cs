using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Sounds.PlaySound("fire");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            Debug.Log(target);
            if (target != null)
            {
                Debug.Log("1");
                target.TakeDamage(damage);
            }
        }
    }
}
