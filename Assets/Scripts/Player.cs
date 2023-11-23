using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float sidePadding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;

    [Header("Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 30f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.2f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();    
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
       Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinously());
        } 

        if (Input.GetButtonUp("Fire1")) {
           StopCoroutine(firingCoroutine);
        }
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + sidePadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - sidePadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 5f;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 11f;
    }

    IEnumerator TestCoroutine() {
        Debug.Log("First part.");
        yield return new WaitForSeconds(3);
        Debug.Log("Second part.");
    }

    IEnumerator FireContinously() {
        while(true) {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);

            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0) {
            Die();
        } else {
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, deathSFXVolume);
        }     
    }

    private void Die() {
        GameObject explosion = Instantiate(
            deathVFX, 
            transform.position, 
            transform.rotation
        );

        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.layer.Equals(12)) {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer) { return; }
            ProcessHit(damageDealer);
        } else {
            Bonus bonus = other.gameObject.GetComponent<Bonus>();
            if (!bonus) { return; }
            GetBonus(bonus);
        }
    }

    private void GetBonus(Bonus bonus) {
        bonus.playPickupSound();

        switch (bonus.tag) {
            case "BonusHealth":
                health += bonus.getHealth();
            break;
            case "BonusHealth2":
                health += bonus.getHealth();
            break;
            case "BonusMoveSpeed":
                moveSpeed += bonus.getSpeed();
            break;
            case "BonusElixir":
                //moveSpeed += bonus.getSpeed();
            break;
        }

        bonus.Die();
    }

    public int GetHealth() {
        return health;
    }
}
