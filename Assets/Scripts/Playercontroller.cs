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
	public AudioClip audioVictoria;
	public AudioClip audioDerrota;
	AudioManager audioManager;
    #endregion

	private RainManager rMngr;

    // Use this for initialization
    void Start()
    {
        _Motion = new Vector3(0, 0, 0);
        rBody = gameObject.GetComponent<Rigidbody>();

        vVectorGround = new Vector3(0.001f, 0.001f, 0.001f);

		audioManager = AudioManager.audioManagerInstance;
        rMngr = GameObject.FindGameObjectWithTag("RainManager").GetComponent<RainManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento


    }
    /// <summary>
    /// gestor del salto del personaje
    /// </summary>
    /// <returns></returns>
    public IEnumerator iJump(float force)
    {
        //Debug.Log("invocando el salto con: " + rBody.velocity.y + " - " + bFalling);
        if (!bFalling)
        {
            bFalling = true;
            _Motion.y = (force) * _gravity;
            rBody.velocity = _Motion;
            //Debug.Log("Saltando!?  " + rBody.velocity.y);
            yield return 0;
        }
    }

    /// <summary>
    /// Gestionamos el fin del minijuego.
    /// </summary>
    private void OnDeath(bool bDead)
    {
        float value = 0.0f;
        //evaluamos si derrota o victoria
        if (bDead)
        {
            //Habilitamos los botones de reinicio nivel o exit scene
            value = -1.0f;
            rMngr.onDefeat();
            audioManager.PlaySound (audioDerrota);
        }
        else
        {
            //Habilitamos el boton de exit
            value = 2.0f;
            rMngr.onVictory();
            audioManager.PlaySound (audioVictoria);
        }
        rMngr.setRainSliderValue(value);
        rMngr.setEndGame(true);
        //Detenemos la cinta de Moebius
        GameObject.FindGameObjectWithTag("MoebiusStrip").GetComponent<Animator>().SetTrigger("StopTrigger");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="colision"></param>
    void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.tag == "obstacle")
        {
            //condicion de derrota
            Debug.Log("DERROTADO");
            OnDeath(true);
        }

        if (colision.gameObject.tag == "Meta")
        {
            Debug.Log("Victoria");
            OnDeath(false);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="colision"></param>
    void OnCollisionEnter(Collision colision)
    {

        if (colision.gameObject.tag == "Ground")
        {
            bFalling = false;
        }

    }
}
