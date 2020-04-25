using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
///
public class PlayerControl : MonoBehaviour
{
    /// Brzina broda
    public Vector2 speed = new Vector2(10, 10);
    // Postavka brzine
    private Vector2 movement;
    private Rigidbody2D rigidBodyComponent;
    public GameObject gameOver;
 
    void Start()
    {
        gameOver.SetActive(false);
    }

    void Update()
    {
        // Axis
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //  Pravac kretanja
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

        // Bez izlaska iz kamere
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        transform.position = new Vector3(
                  Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
                  Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
                  transform.position.z
                  );

        // Pucanje
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(false);
                
            }
        }
    }

    void FixedUpdate()
    {
        // Pomeranje objekta
        if (rigidBodyComponent == null) rigidBodyComponent = GetComponent<Rigidbody2D>();
        rigidBodyComponent.velocity = movement;

    }
    

    void OnDestroy()
    {
        // Provera da li je igrac mrtav
        liveSystem playerHealth = this.GetComponent<liveSystem>();
        if (playerHealth != null && playerHealth.curHealth <= 0)
        {
            // Game Over.
            var gameOver = FindObjectOfType<GameOver>();
            var gamePaused = FindObjectOfType<PauseMenu>();
            gamePaused.pauseMenuUI.SetActive(false);

        };
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Sudar sa protivnikom
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Ubiti protivnika
            liveSystem enemyHealth = enemy.GetComponent<liveSystem>();
            if (enemyHealth != null) enemyHealth.TakeDamage(enemyHealth.curHealth);

            damagePlayer = true;
            scoreScript.scoreValue += 1;
        }

        // Damage the player
        if (damagePlayer)
        {
            liveSystem playerHealth = this.GetComponent<liveSystem>();
            if (playerHealth != null) playerHealth.TakeDamage(1);
            
            if (playerHealth != null && playerHealth.curHealth <= 0)
            {
                
                gameOver.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}

