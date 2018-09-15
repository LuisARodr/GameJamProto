using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoreGame.Combos;

public class ComboController: MonoBehaviour
{
    [SerializeField]
    public Canvas comboCanvas;
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


    public void ShowComboCounter()
    {
        comboCanvas.GetComponent<CanvasGroup>().alpha = 1;
        comboText.GetComponent<Text>().text = ComboManager.comboCounter.ToString() + " COMBO!!!";
    }

    public void HideComboCounter()
    {
        ComboManager.resetCombo();
        comboCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }
    
}
  

