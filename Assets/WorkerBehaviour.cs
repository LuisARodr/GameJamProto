using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;
using GameTime;
using UnityEngine.UI;
using CoreGame.Combos;

public class WorkerBehaviour : MonoBehaviour {

    private int typeWanted = 0;
    private ToolControl toolControl;
    private TimeManager timeManager;
    public float phaseTime = 4;
    private bool askingState = false;
    public float activityMoney = 50f;
    //private SpriteRenderer sr;

    [SerializeField]
    private Image fillBubble;
    [SerializeField]
    private Canvas textBubble;
    [SerializeField]
    private Image toolImage;

    
    

    private float fillAmount = 0;
	// Use this for initialization
	void Start () {
        timeManager = new TimeManager(phaseTime / 4);
        //sr = GetComponent<SpriteRenderer>();
        textBubble.GetComponent<CanvasGroup>().alpha = 0;
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
                        toolImage.GetComponent<Image>().color = Color.blue;
                        break;
                    case 1:
                        toolImage.GetComponent<Image>().color = Color.yellow;
                        break;
                    case 2:
                        toolImage.GetComponent<Image>().color = Color.green;
                        break;
                    default:
                        toolImage.GetComponent<Image>().color = Color.black;
                        break;
                }
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


    private void UpdateBubble()
    {
        fillAmount += Time.deltaTime / phaseTime;
        fillBubble.GetComponent<Image>().fillAmount = fillAmount;
    }



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

    private void RightTool()
    {
        
        MoneyManager.AddActivityMoney(activityMoney * comboMultiplier());
        ComboManager.addCombo();
        
    }

    private void WrongTool()
    {
        ComboManager.resetCombo();
        MoneyManager.AddActivityMoney(-activityMoney/2);
        //algo que represente que esta enojado
    }

    private void MissedTool()
    {
        ComboManager.resetCombo();
        MoneyManager.AddActivityMoney(-activityMoney / 5);
        //algo que represente que esta enojado
    }

    private float comboMultiplier()
    {
        return ComboManager.comboCounter <= 10 ? ComboManager.comboCounter / 10 + 1 : ComboManager.comboCounter > 10 ? 2 : 1;
    }
    
}
