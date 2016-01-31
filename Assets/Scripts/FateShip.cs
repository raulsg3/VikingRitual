using UnityEngine;
using System.Collections;

public class FateShip : MonoBehaviour {

    // Shoot point
    public Transform shootPoint;

    // Shooting parameters
    public float timeBetweenShots = 0.5f;
    public float projectileSpeed = 30f;

    private float timeSinceLastShot = 0;
    private bool shooting = false;

    // Rotating
    public float turnSpeed = 10.0f;

    private bool rotating = false;
    private Vector3 hitPoint;
    private Quaternion lookRotation;
    
    // Projectile
    public Rigidbody projectile;

    //
    private FateManager fMngr;
    // Use this for initialization
    void Start () {
        fMngr = GameObject.FindGameObjectWithTag("FateManager").GetComponent<FateManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                //if (hit.transform.tag == "Ground") {
                hitPoint = hit.point;
                rotating = true;
                shooting = true;
                //}
            }

        }

        //calculate the displacement since last frame:
        //find the vector pointing from our position to the target
        if (hitPoint != null)
        {
            Vector3 _direction = Vector3.Normalize(hitPoint - transform.position);

            if (rotating)
            {
                //rotate us over time according to speed until we are in the required rotation
                lookRotation = Quaternion.LookRotation(_direction);
                //create the rotation we need to be in to look at the target
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
            }

            if (Quaternion.Angle(Quaternion.LookRotation(transform.forward), lookRotation) < 10)
            {
                rotating = false;

                if (shooting && canShoot())
                {
                    shoot();
                    timeSinceLastShot = 0.0f;
                    shooting = false;
                }
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FateEnemy") {
            Debug.Log("Tocado");
            fMngr.playerDestroyed();
            AudioManager.audioManagerInstance.PlaySound(fMngr.audioDerrota);
            GameManager.instance.SetAttributeValue(-1.0f, GameManager.Scenes.FateScene);
        }
    }

    private bool canShoot() {
        return timeBetweenShots < timeSinceLastShot;
    }

    private void shoot() {
        Rigidbody newProjectile = Instantiate<Rigidbody>(projectile);
        newProjectile.transform.position = shootPoint.position;
        newProjectile.transform.forward = shootPoint.forward;

        newProjectile.velocity = newProjectile.transform.forward * projectileSpeed;

        Collider shipCollider = transform.root.GetComponent<Collider>();
        Collider newProjectileCollider = newProjectile.gameObject.GetComponent<Collider>();

        Physics.IgnoreCollision(shipCollider, newProjectileCollider);
    }

}
