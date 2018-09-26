using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoreGame;

/// <summary>
///  Controla el llenado de la powerBar
/// </summary>
public class FillPowerBar : MonoBehaviour {
    /// <summary>
    /// Un slider que represente la PowerBar
    /// </summary>
    [SerializeField]
    public Slider powerBar;
    /// <summary>
    /// Representa la velocidad a la que se va a mover la barra de poder
    /// </summary>
    [Range(0f,150f)]
    [SerializeField]
    private float step;
    /// <summary>
    /// Representa el valor de la barra de poder, donde el 0 es el minimo y 100 es el maximo
    /// </summary>
    float powerBarValue = 0;
    /// <summary>
    /// Representa cuando el powerBarValue incrementa (True) o decrementa (False).
    /// </summary>
    private bool increasing = true;
    /// <summary>
    /// Representa el valor powerBarValue al momento de soltar el boton.
    /// </summary>
    [HideInInspector]
    public float finalPowerBarValue = 0;
    
    [SerializeField]
    GameObject mobileInputsObject;
    MobileInputsPressedB mobileInputs;

    // Use this for initialization
    void Start () {
        mobileInputs = mobileInputsObject.GetComponent<MobileInputsPressedB>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("B_Button") || mobileInputs.BButtonBegan)
        {
            SetPowerBarToZero();
        }
        else if (Input.GetButton("B_Button") || mobileInputs.BButtonDown)
        {
            ChangePowerBarFill();
        }
        else if (Input.GetButtonUp("B_Button") || mobileInputs.BButtonUp)
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
        //debug
        ///finalPowerBarValue = 40f;
        //debug
        finalPowerBarValue = powerBarValue;
        SetPowerBarToZero();
        return finalPowerBarValue;
    }

    /// <summary>
    /// Aumenta o decrementa el powerBarValue en base al valor del step, coloca el resultado en la barra de poder.
    /// </summary>
    private void ChangePowerBarFill()
    {
        float step = this.step * Time.deltaTime;
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
