using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;
using GameTime;
using UnityEngine.UI;
using CoreGame.Combos;

/// <summary>
/// Controla el comportamiento del trabajador
/// </summary>
public class WorkerBehaviour : MonoBehaviour {

    /// <summary>
    /// Tipo de la herramienta que quiere el trabajador
    /// </summary>
    private int typeWanted = 0;
    /// <summary>
    /// script conocer el tipo de la herramienta que toca al trabajadors
    /// </summary>
    private ToolControl toolControl;
    /// <summary>
    /// Controla el tiempo de espera entre ciclos del trabajador,
    /// </summary>
    private TimeManager timeManager;
    /// <summary>
    /// Tiempo que dura la fase en la que resive herramientas
    /// </summary>
    public float phaseTime = 6;
    /// <summary>
    /// True = se encuentra en la face que resive herramientas, False = no se encuentra en la sase en la que resive herramietas
    /// </summary>
    private bool askingState = false;
    /// <summary>
    /// Representa la cantidad de dinero de la actividad
    /// </summary>
    public float activityMoney = 60f;
    //private SpriteRenderer sr;

    /// <summary>
    /// imagen de la burbuja que se rellena
    /// </summary>
    [SerializeField]
    private Image fillBubble;
    /// <summary>
    /// Canvas que contiene la burbuja de texto
    /// </summary>
    [SerializeField]
    private Canvas textBubble;
    /// <summary>
    /// Imagen de la herramienta que quiere el trabajador
    /// </summary>
    [SerializeField]
    private Image toolImage;

    private Sprite normalWorker;
    [SerializeField]
    private Sprite angryWorker;
    [SerializeField]
    private Sprite[] toolsSprites;


    /// <summary>
    /// representa lo lleno que esta la burbuja
    /// </summary>
    private float fillAmount = 0;
	// Use this for initialization
	void Start () {
        timeManager = new TimeManager(phaseTime / 4);
        //sr = GetComponent<SpriteRenderer>();
        textBubble.GetComponent<CanvasGroup>().alpha = 0;
        MoneyManager.IniciateMoney();
        normalWorker = GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeManager.IsTimeOver())
        {
            //si se acaba el timepo del contador y no se encuentra actualmente en askingState
            if (!askingState)
            {
                //print("Entra aqui primero");
                timeManager.StartTime(phaseTime);
                askingState = true;
                textBubble.GetComponent<CanvasGroup>().alpha = 1;
                typeWanted = Random.Range(0, 3);
                switch (typeWanted)
                {
                    case 0:
                       // toolImage.color = Color.blue;
                        toolImage.sprite = toolsSprites[0];
                        break;
                    case 1:
                       // toolImage.color = Color.yellow;
                        toolImage.sprite = toolsSprites[1];
                        break;
                    case 2:
                        //toolImage.color = Color.green;
                        toolImage.sprite = toolsSprites[2];
                        break;
                    default:
                        toolImage.color = Color.black;
                        break;
                }
                GetComponent<SpriteRenderer>().sprite = normalWorker;
            }
            //si se acaba el tiempo del contador y se encuentra en el askingState
            else
            {
                MissedTool();
                //print("Entra aqui despues");
                timeManager.StartTime(phaseTime / 2);
                askingState = false;
                fillAmount = 0;
                fillBubble.GetComponent<Image>().fillAmount = fillAmount;
                textBubble.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
        if (askingState)
        {
            UpdateBubble();
        }
       
	}

    /// <summary>
    /// Actualiza el fillAmount del fill bubble y aumenta el fillAmount en deltaTime
    /// </summary>
    private void UpdateBubble()
    {
        fillAmount += Time.deltaTime / phaseTime;
        fillBubble.GetComponent<Image>().fillAmount = fillAmount;
    }


    /// <summary>
    /// Cuando entra una herramienta al trabjador dependiendo en que estado se encuentra el trabajador y el tipo de herramienta
    /// aumenta o disminuye el ActivityMoney y maneja el sistema de combos
    /// </summary>
    /// <param name="collision">Herramienta que entro al trigger</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (askingState)
        {
            if (collision.GetComponent<ToolControl>().type == typeWanted)
            {
                RightTool();
                askingState = false;
                fillBubble.GetComponent<Image>().fillAmount = fillAmount;
                textBubble.GetComponent<CanvasGroup>().alpha = 0; ;
                fillAmount = 0;
                timeManager.StartTime(phaseTime / 2);
            }   
            else
                WrongTool();
        }
        else
        {
            WrongTool();
        }
        

        Destroy(collision.gameObject);
    }

    /// <summary>
    /// Cuando el trabajador resive una herramienta correcta aumenta el dinero y el combo
    /// </summary>
    private void RightTool()
    {
        
        MoneyManager.AddActivityMoney(activityMoney * comboMultiplier());
        ComboManager.addCombo();
        
    }
    /// <summary>
    /// Cuando el trabajador resive una herramienta incorrecta disminuye el dinero y reinicia el combo.
    /// </summary>
    private void WrongTool()
    {
        ComboManager.resetCombo();
        MoneyManager.AddActivityMoney(-activityMoney/2);
        //algo que represente que esta enojado
        GetComponent<SpriteRenderer>().sprite = angryWorker;
    }
    /// <summary>
    /// Cuando el trabajador no resive una una herramienta a tiempo disminuye el dinero y reinicia el combo.
    /// </summary>
    private void MissedTool()
    {
        ComboManager.resetCombo();
        MoneyManager.AddActivityMoney(-activityMoney / 6);
        //algo que represente que esta enojado
        GetComponent<SpriteRenderer>().sprite = angryWorker;
    }

    /// <summary>
    /// Regresa la cantidad de dinero multiplicado por el combo actual
    /// </summary>
    /// <returns>dinero multiplicado por el combo</returns>
    private float comboMultiplier()
    {
        return ComboManager.comboCounter <= 10 ? ComboManager.comboCounter / 10 + 1 : ComboManager.comboCounter > 10 ? 2 : 1;
    }
    
}
