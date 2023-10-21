using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
	[SerializeField] float shotCounter;
	[SerializeField] float minTimeBetweenShot = 0.2f;
	[SerializeField] float maxTimeBetweenShot = 3f;

	void Start() {
		shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
	}

    private void OnTriggerEnter2D(Collider2D other) {
	    DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
		ProcessHit(damageDealer);
    }

	private void ProcessHit(DamageDealer damageDealer) {
		health -= damageDealer.GetDamage();

		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	private void CountDownAndShoot() {
		shotCounter -= Time.deltaTime;

		if (shotCounter <= 0) {
			Fire();
		}
	}

	private void Fire() {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
	}
}
