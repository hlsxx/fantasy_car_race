using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float sidePadding = 1f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 30f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();    
        StartCoroutine(TestCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
       Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(FireContinously());
        } else if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }

    private void Move() {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        //var newXPos = transform.position.x + deltaX;

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        //var newYPos = transform.position.y + deltaY;

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
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
