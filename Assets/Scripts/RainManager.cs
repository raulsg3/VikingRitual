using UnityEngine;
using UnityEngine.UI;
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

    public Button buttonExit;
    public Button buttonRetry;

    private bool bStartAnim, bFinGame;
    private bool bJummping;
    private float fRainSliderValue = 0.0f;
    private string strScene = "RainScene";
    // Use this for initialization
    void Start()
    {
        bStartAnim = false;
        bFinGame = false;
        bJummping = false;
        //fRainSliderValue = GameManager.instance.GetRain();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bJummping = goPlayer.GetComponent<Playercontroller>().bFalling;
        if (Input.GetMouseButtonDown(0) && !bJummping)
        {
            //Comprobamos que unicamente se lanze la animación de inicio cuando corresponda
            if (!bStartAnim)
            {
                goMoebiusStrip.GetComponent<Animator>().SetTrigger("StartTrigger");
                bStartAnim = true;
            }

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
    /// <summary>
    /// 
    /// </summary>
    public void OnButtonRetry()
    {
        GameManager.instance.SetAttributeValue(fRainSliderValue, GameManager.Scenes.RainScene);
        GameManager.instance.Loadscene(strScene);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnButtonExit()
    {
        Debug.Log("Por dios saca este demonio de mi: ");
        GameManager.instance.SetAttributeValue(fRainSliderValue, GameManager.Scenes.RainScene);
        GameManager.instance.LoadMainScene();
    }

    /// <summary>
    /// Asignamos el valor obtenido 
    /// en caso de victoria +2 
    /// en caso de derrota -1
    /// </summary>
    /// <param name="value"></param>
    public void setRainSliderValue(float value)
    {
        Debug.Log("Por la puntuacion te quiero andres :" + value);
        fRainSliderValue = fRainSliderValue + value;
    }
    /// <summary>
    /// Set del booleano que recoge que ha terminado la partida
    /// </summary>
    /// <param name="End"></param>
    public void setEndGame(bool End)
    {
        Debug.Log("Al fin delfin :" + End);
        bFinGame = End;
    }

    private void activateEndButtons()
    {
        buttonExit.gameObject.SetActive(true);
        buttonRetry.gameObject.SetActive(true);
    }

    public void onVictory()
    {
        activateEndButtons();
    }

    public void onDefeat()
    {
        activateEndButtons();
    }
}
