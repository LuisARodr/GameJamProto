using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoreGame.Combos;

/// <summary>
/// Toma los valores de ComboManager y lo pinta en la UI
/// </summary>
public class ComboController: MonoBehaviour
{
    /// <summary>
    /// Canvas en el que se encuentra el Texto que representa el combo
    /// </summary>
    [SerializeField]
    public Canvas comboCanvas;
    /// <summary>
    /// Texto en donde se va a representar el contador del combo
    /// </summary>
    [SerializeField]
    public Text comboText;

    private void Update()
    {
        if(ComboManager.comboCounter > 0)
        {
            ShowComboCounter();
        }
        else
        {
            HideComboCounter();
        }
    }

    /// <summary>
    /// Muestra el canvas del combo y actualiza el texto del combo para mostrar el valor de combo del comboManager
    /// </summary>
    public void ShowComboCounter()
    {
        comboCanvas.GetComponent<CanvasGroup>().alpha = 1;
        comboText.GetComponent<Text>().text = ComboManager.comboCounter.ToString() + " COMBO!!!";
    }

    /// <summary>
    /// Ocualta el canvas del combo y reinicia el valor del comboManger
    /// </summary>
    public void HideComboCounter()
    {
        ComboManager.resetCombo();
        comboCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }
    
}
  

