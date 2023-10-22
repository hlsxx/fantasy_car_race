using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
	[SerializeField] float shotCounter;
	[SerializeField] float minTimeBetweenShot = 0.2f;
	[SerializeField] float maxTimeBetweenShot = 3f;
	[SerializeField] float projectileSpeed = 10f;
	[SerializeField] GameObject projectile;

	void Start() {
		shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
	}

	void Update() {
		CountDownAndShoot();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if (!damageDealer) { return; }
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer) {
		health -= damageDealer.GetDamage();
		damageDealer.Hit();

		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	private void CountDownAndShoot()
	{
		shotCounter -= Time.deltaTime;

		if (shotCounter <= 0) {
			Fire();
			shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
		}
	}

	private void Fire() {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
	}
}
