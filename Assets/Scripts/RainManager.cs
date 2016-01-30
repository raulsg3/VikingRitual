using UnityEngine;
using System.Collections;

public class RainManager : MonoBehaviour
{
    #region variables configurables de la escena
    public float fFloorSpeed = 0.0f;
    public float fJumpHeight = 2.0f;
    public float fTuneSpawnObj = 0.0f;
    public GameObject goPlayer;
    public GameObject goMoebiusStrip;
    #endregion

    private bool bStartAnim;
    private bool bJummping;
    // Use this for initialization
    void Start()
    {
        bStartAnim = false;
        bJummping = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bJummping = goPlayer.GetComponent<Playercontroller>().bFalling;
        if (Input.GetMouseButtonDown(0) && !bJummping)
        {
            //Comprobamos que unicamente se lanze la animación de inicio cuando corresponda
            if (!bStartAnim)
                goMoebiusStrip.GetComponent<Animator>().SetTrigger("StartTrigger");

            bJummping = true;
            StartCoroutine(goPlayer.GetComponent<Playercontroller>().iJump(fJumpHeight));

        }

    }

    /// <summary>
    /// Controlamos la velocidad del suelo y cuando debe parar
    /// </summary>
    private void FloorSpeed()
    {

    }


}
