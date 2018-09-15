using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoreGame;

public class FillPowerBar : MonoBehaviour {

    [SerializeField]
    public Slider powerBar;
    [Range(0f,50f)]
    [SerializeField]
    float step;
    float powerBarValue = 0;
    private bool increasing = true;
    [HideInInspector]
    public float finalPowerBarValue = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("B_Button"))
        {
            SetPowerBarToZero();
        }
        else if (Input.GetButton("B_Button"))
        {
            ChangePowerBarFill();
        }
        else if (Input.GetButtonUp("B_Button"))
        {
            Debug.Log("Poder Final = " + FinalPower());
        }

    }

    /// <summary>
    /// Regresa un float con el valor de la barra de poder al momento de soltar el boton y regresa el valor de la barra de poder a 0.
    /// </summary>
    /// <returns></returns>
    public float FinalPower()
    {
        finalPowerBarValue = powerBarValue;
        SetPowerBarToZero();
        return finalPowerBarValue;
    }

    /// <summary>
    /// Aumenta o decrementa el powerBarValue en base al valor del step, coloca el resultado en la barra de poder.
    /// </summary>
    private void ChangePowerBarFill()
    {
        powerBarValue += increasing && powerBarValue + step <= 100f ? step : 
            increasing && powerBarValue + step > 100f ? 100f - powerBarValue:
            !increasing && powerBarValue - step >= 0f ? -step :
            -powerBarValue;
        increasing = powerBarValue == 100 ? false :
            powerBarValue == 0? true : 
            increasing;
        powerBar.value = powerBarValue / 100f;

    }
    /// <summary>
    /// Hace el fillAmount y powerBarValue de la barra de poder cero
    /// </summary>
    private void SetPowerBarToZero()
    {
        powerBarValue = 0;
        powerBar.value = powerBarValue;
    }
}
