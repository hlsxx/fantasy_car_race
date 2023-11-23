using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    [SerializeField] int health;
    [SerializeField] float moveSpeed;
    [SerializeField] AudioClip pickupSFX;

    public int getHealth() {
        return health;
    }

    public float getSpeed() {
        return moveSpeed;
    }

    public void playPickupSound() {
        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position, 1);
    }

    public void Die() {
        Destroy(gameObject);
    }
}
