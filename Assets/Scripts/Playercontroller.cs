using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour
{

    #region Variables del player
    public Vector3 _Motion;
    public float _gravity = 0.1f;
    public bool bFalling = false;
    private Rigidbody rBody;

    private Vector3 vVectorGround;
    #endregion

    // Use this for initialization
    void Start()
    {
        _Motion = new Vector3(0, 0, 0);
        rBody = gameObject.GetComponent<Rigidbody>();

        vVectorGround = new Vector3(0.001f, 0.001f, 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimientoç


    }
    /// <summary>
    /// gestor del salto del personaje
    /// </summary>
    /// <returns></returns>
    public IEnumerator iJump(float force)
    {
        Debug.Log("invocando el salto con: " + rBody.velocity.y + " - " + bFalling);
        if (/*rBody.velocity.y <= 0.1f &&*/ !bFalling)
        {
            bFalling = true;
            _Motion.y = (force) * _gravity;
            rBody.velocity = _Motion;
            Debug.Log("Saltando!?  " + rBody.velocity.y);
            yield return 0;
        }
    }

    /// <summary>
    /// Gestionamos el fin del minijuego.
    /// </summary>
    private void OnDeath()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="colision"></param>
    void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.tag == "obstacle")
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="colision"></param>
    void OnCollisionEnter(Collision colision)
    {
        Debug.Log("dentro de ontrgStay :" + colision.gameObject.tag);
        if (colision.gameObject.tag == "Ground")
        {
            bFalling = false;
        }

    }
}
