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
            GameManager.nextScene();
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
        }
        return dia;
    }
}
