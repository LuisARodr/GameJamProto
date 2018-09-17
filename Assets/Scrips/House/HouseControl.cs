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


    private void Start()
    {
        food.GetComponent<SpriteRenderer>().color = ItemControl.items[0] ? new Color(1, 1, 1, 1) : 
            new Color (1,1,1,0);
        meds.GetComponent<SpriteRenderer>().color = ItemControl.items[1] ? new Color(1, 1, 1, 1) :
            new Color(1, 1, 1, 0);
        beer.GetComponent<SpriteRenderer>().color = ItemControl.items[2] ? new Color(1, 1, 1, 1) :
            new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonUp("Y_Button"))
        {
            int aux = newsPaper.GetComponent<SpriteRenderer>().sortingOrder;
            newsPaper.GetComponent<SpriteRenderer>().sortingOrder = letter.GetComponent<SpriteRenderer>().sortingOrder;
            letter.GetComponent<SpriteRenderer>().sortingOrder = aux;
        }
        else if (Input.GetButtonUp("Start_Button"))
        {
            GameManager.nextScene();
        }
    }
}
