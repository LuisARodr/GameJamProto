using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Items;

public class HouseControl : MonoBehaviour {

    public GameObject food;
    public GameObject meds;
    public GameObject beer;
    public GameObject newsPaper;
    public GameObject letter;
    public TextMesh letterText;

    private bool letterVisibility = false;


    private void Start()
    {
        food.GetComponent<SpriteRenderer>().color = ResultsScreenControl.itemBought[0] ? new Color(1, 1, 1, 1) : 
            new Color (1,1,1,0);
        meds.GetComponent<SpriteRenderer>().color = ResultsScreenControl.itemBought[2] ? new Color(1, 1, 1, 1) :
            new Color(1, 1, 1, 0);
        beer.GetComponent<SpriteRenderer>().color = ResultsScreenControl.itemBought[1] ? new Color(1, 1, 1, 1) :
            new Color(1, 1, 1, 0);

        ResultsScreenControl.killFamilyMember();
        ResultsScreenControl.sickRoll();
        UpdateLetter();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Y_Button"))
        {
            letterVisibility = !letterVisibility;
            int aux = newsPaper.GetComponent<SpriteRenderer>().sortingOrder;
            newsPaper.GetComponent<SpriteRenderer>().sortingOrder = letter.GetComponent<SpriteRenderer>().sortingOrder;
            letter.GetComponent<SpriteRenderer>().sortingOrder = aux;
            letterText.offsetZ = letterVisibility ? -1 : 0;
        }
        else if (Input.GetButtonUp("Start_Button"))
        {
            GameManager.goToScene(16);//16 es el numero de escena actual de la escena de transicion
        }
    }

    /// <summary>
    /// Cambiar los contenidos de la carta dependiendo del estado de la familia.
    /// </summary>
    void UpdateLetter()
    {
        //si todos estan muertos
        if (ResultsScreenControl.numberOfFamilyAlive > 0)
        {
            //si solo el perro esta vivo
            if(ResultsScreenControl.numberOfFamilyAlive == 1 && ResultsScreenControl.familyMembersAlive[4])
            {
                letterText.text = "Guau guau";
            }
            //si solo el bebe esta vivo o perro
            else if (ResultsScreenControl.familyMembersAlive[0] && !ResultsScreenControl.familyMembersAlive[1] && !ResultsScreenControl.familyMembersAlive[2]
                && !ResultsScreenControl.familyMembersAlive[3])
            {
                letterText.text = "*Garabatos de bebé en español*";
            }
            //si alguien mas esta vivo
            else if(ResultsScreenControl.familyMembersAlive[0]|| ResultsScreenControl.familyMembersAlive[1]|| ResultsScreenControl.familyMembersAlive[2])
            {
                //semana 1
                if(ResultsScreenControl.week == 0)
                {
                    letterText.text = "Que bueno que llegaste, \n esperamos que saques mucha pasta \n por el bien del familia.\n";
                }
                //semana 2 o mas
                else
                {
                    letterText.text = "Esperamos que saques mucha \n pasta por el bien del familia.\n";
                }
                //enviaste comida
                if(ResultsScreenControl.foodMultiplier == 1)
                {
                    letterText.text += "Gracias por el dinero de la comida, con\n esto nos vamos a aventar unos buenos\n tacos de frijol.\n";
                }
                else
                {
                    letterText.text += "Nos estamos muriendo de hambre, no\n nos sentimos muy bien.\n";
                }
                //enviaste medicina
                if (ResultsScreenControl.itemBought[2])
                {
                    letterText.text += "Gracias por enviar dinero para\n el simi, fulanito se siente mucho mejor.\n";
                }
                //alguien muere
                for(int i = 0; i<5; i++)
                {
                    if (ResultsScreenControl.deadFlag[i])
                    {
                        letterText.text += ResultsScreenControl.numberToFamilyMember(i)+
                            " no lo logro, lo enterramos\n en el patio, esperemos que esto no\n se repita.\n";
                        ResultsScreenControl.deadFlag[i] = false;
                    }
                }

                //alguien se enferma
                for (int i = 0; i < 5; i++)
                {
                    if (ResultsScreenControl.isSick[i])
                    {
                        letterText.text += ResultsScreenControl.numberToFamilyMember(i) +
                            " se enfermó, no creo que\n lo logre sin unas medicinas del simi,\n por favor envianos dinero para el simi.\n";
                        ResultsScreenControl.deadFlag[i] = false;
                    }
                }
            }
        }






       

        

        
        
        
        
    }
}
