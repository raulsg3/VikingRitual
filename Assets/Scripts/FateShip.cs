using UnityEngine;
using System.Collections;

public class FateShip : MonoBehaviour {

    // Shoot point
    public Transform shootPoint;

    // Shooting parameters
    public float timeBetweenShots = 0.5f;
    public float initialVelocity = 50f;

    private float timeSinceLastShot = 0;

    // Projectile
    public Rigidbody projectile;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastShot += Time.deltaTime;

        if (canShoot()) {
            shoot();
            timeSinceLastShot = 0.0f;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FateEnemy") {
            Debug.Log("Tocado");
        }
    }

    private bool canShoot() {
        return timeBetweenShots < timeSinceLastShot;
    }

    private void shoot() {
        Rigidbody newProjectile = Instantiate<Rigidbody>(projectile);
        newProjectile.transform.position = shootPoint.position;
        newProjectile.transform.forward = shootPoint.forward;

        newProjectile.velocity = newProjectile.transform.forward * initialVelocity;

        Collider shipCollider = transform.root.GetComponent<Collider>();
        Collider newProjectileCollider = newProjectile.gameObject.GetComponent<Collider>();

        Physics.IgnoreCollision(shipCollider, newProjectileCollider);
    }

}
