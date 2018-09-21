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
            GameManager.goToScene(20);//16 es el numero de escena actual de la escena de transicion
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
                letterText.text = "Guau guau\n\nGuau guau guau!\nGuauuuuuuuuuu...\nGuauuuuuuu...\nGuau guau guau, guau guau, guau.\n\nGuau.";
            }
            //si solo el bebe esta vivo o perro
            else if (ResultsScreenControl.familyMembersAlive[0] && !ResultsScreenControl.familyMembersAlive[1] && !ResultsScreenControl.familyMembersAlive[2]
                && !ResultsScreenControl.familyMembersAlive[3])
            {
                letterText.text = "asldkjf\n\nlkajsjnajs nkj nsdjfsdmujf\nlksdkfjnsdknm sdjhhf\njnfoskfj ouuhjsd iuhj sdoifj\n\nb3b3";
            }
            //si alguien mas esta vivo
            else if(ResultsScreenControl.familyMembersAlive[0] || ResultsScreenControl.familyMembersAlive[1] || ResultsScreenControl.familyMembersAlive[2])
            {
                //agregar saludo al inicio
                if (ResultsScreenControl.familyMembersAlive[0]) 
                {
                    letterText.text += "Hola Jose\n\n";
                }
                else 
                {
                    letterText.text += "Hola papa\n\n";
                }
                //Si es la semana 1 se agrega
                if (ResultsScreenControl.week == 0)
                {
                    letterText.text += "Nos alegra que ayas llegado \nbien a los yunaites.\n";
                }
                //semana 2 o mas
                letterText.text += "Esperemos que juntes mucho \ndinero por el bien del familia.\n";
                //enviaste comida
                if(ResultsScreenControl.foodMultiplier == 1)
                {
                    letterText.text += "Grasias por el dinero de la comida, con \nesto nos bamos a aventar unos buenos \ntacos de frijol, panela y una coquita.\n";
                }
                else
                {
                    letterText.text += "No tenemos nada que comer, \nnos estamos muriendo de \nhambre, no nos sentimos muy bien.\n";
                }
                //enviaste medicina
                if (ResultsScreenControl.itemBought[2]) 
                { 
                    for (int i = 0; i < 5; i++) 
                    {
                        if (ResultsScreenControl.healedFamilyMember[i]) 
                        {
                            letterText.text += "Grasias por enviar dinero para el simi, \n"+ResultsScreenControl.numberToFamilyMember(i)+" se siente mucho mejor.\n";
                            ResultsScreenControl.healedFamilyMember[i] = false;
                        }
                    }
                }
                //alguien muere
                for(int i = 0; i<5; i++)
                {
                    if (ResultsScreenControl.deadFlag[i])
                    {
                        letterText.text += ResultsScreenControl.numberToFamilyMember(i)+
                            " no lo logro, \ntubimos que enterrarlo en el patio, \nesperemos que esto no se repita.\n";
                        ResultsScreenControl.deadFlag[i] = false;
                    }
                }

                //alguien se enferma
                for (int i = 0; i < 5; i++)
                {
                    if (ResultsScreenControl.isSick[i])
                    {
                        letterText.text += ResultsScreenControl.numberToFamilyMember(i) +
                            " se enfermo, no creo que lo logre \nsin unas medicinas del simi, por favor \nenvianos dinero antes que pase a peores.\n";
                        ResultsScreenControl.deadFlag[i] = false;
                    }
                }

                //terminar la carta
                if (ResultsScreenControl.familyMembersAlive[0]) 
                {
                    letterText.text += "\nLupe";
                }
                else if (ResultsScreenControl.familyMembersAlive[2]) 
                {
                    letterText.text += "\nAnita";
                }
                else if (ResultsScreenControl.familyMembersAlive[1]) 
                {
                    letterText.text += "\nToñito";
                }
            }
        }






       

        

        
        
        
        
    }
}
