using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTime;
using UnityEngine.UI;
using Money;

public class TransitionControl : MonoBehaviour {

    private TimeManager timeManager;
    [SerializeField]
    private float transitionTime = 4;
    public Text text;



	// Use this for initialization
	void Start () {
        timeManager = new TimeManager(transitionTime);
        text.GetComponent<Text>().text = DayOfTheWeek() + " " + Random.Range(5, 9) + ":00 A.M.";
    }
	
	// Update is called once per frame
	void Update () {
        if (timeManager.IsTimeOver())
        {
            /*
            if (MoneyManager.day == 1 && ResultsScreenControl.week == 2)
            {
                GameManager.goToScene(6);
            }
            else if (MoneyManager.day == 1 && ResultsScreenControl.week == 3)
            {
                GameManager.goToScene(9);
            }
            else if (MoneyManager.day == 1 && ResultsScreenControl.week == 4)
            {
                GameManager.goToScene(12);
            }
            */
            if (MoneyManager.day < 4)
                GameManager.nextScene();
            else 
                GameManager.goToScene(19);//result screen
        }
	}

    private string DayOfTheWeek()
    {
        string dia = "";
        switch (MoneyManager.day)
        {
            case 0:
                dia = "Lunes";
                break;
            case 1:
                dia = "Martes";
                break;
            case 2:
                dia = "Jueves";
                break;
            case 3:
                dia = "Viernes";
                break;
            default:
                dia = "Sabado";
                break;
        }
        return dia;
    }
}
