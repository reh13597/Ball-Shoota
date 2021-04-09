using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CustomBullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    //public GameObject player;

    //public GameObject winMenuUI;
    //public Camera playerCamera;
    //public TextMeshProUGUI scoreText;

    //int score;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
       // score = 0;
       // SetScoreText();
       // winMenuUI.SetActive(false);
    }

    private void Update()
    {
        if (collisions > maxCollisions)
        {
            Explode();
        }

        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }

    /**
     * This function creates a bullet explosion when it collides with something else.
     * At the end, it invokes a function with 0.05f delay that destroys the BULLET game object.
     */

    private void Explode()
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity); // Checks if there is a collision. By using XXXX
        }

        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
           enemies[i].GetComponent<ShootingAi>().TakeDamage(explosionDamage);

           if (enemies[i].GetComponent<Rigidbody>())
              enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        Invoke("Delay", 0.05f);
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
      Destroy(col.gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Bullet")) return;

        collisions++;

        if (col.collider.CompareTag("Enemy") && explodeOnTouch)
        {
            Destroy(col.collider.gameObject);
            Explode();
           // this.score = this.score + 1;
           // SetScoreText();
        }
        
    }

    private void Setup()
    {
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

    //void SetScoreText()
   // {
     //   scoreText.text = "Enemies killed: " + score.ToString();
    //    Debug.Log("Score: " + this.score);
    //    if (score >= 15)
    //    {
    //        YouWin();
    //    }
   // }

  //  void YouWin()
    //{
     //   winMenuUI.SetActive(true);
    //    Time.timeScale = 0f;
     //   playerCamera.GetComponent<MouseLook>().enabled = false;
     //   Cursor.lockState = CursorLockMode.None;
     //   Cursor.visible = true;
   // }
}
