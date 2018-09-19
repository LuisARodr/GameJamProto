using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;

public class FinalScreenControl : MonoBehaviour {

    public SpriteRenderer[] family = new SpriteRenderer[6];
    /*
    public SpriteRenderer player;   //0
    public SpriteRenderer son;      //1
    public SpriteRenderer daugther; //2
    public SpriteRenderer wife;     //3
    public SpriteRenderer baby;     //4
    public SpriteRenderer dog;      //5
    */
    public Sprite tombstone;

    public SpriteRenderer background;

    public Sprite[] backgroundSprites = new Sprite[4];

    // Use this for initialization
    void Start () {
        setFamily();
        setBackGround();

    }

    private void setFamily()
    {
        //player siempre va a ser el mismo por el momemto.
        int count = 1;
        foreach(bool familyMember in ResultsScreenControl.familyMembersAlive)
        {
            if(!familyMember)
                family[count].sprite = tombstone;
            count++;
        }
    }

    private void setBackGround()
    {
        background.sprite = MoneyManager.TotalMoney <= 3000 ? backgroundSprites[0] :
            MoneyManager.TotalMoney > 3000 && MoneyManager.TotalMoney <= 5000 ? backgroundSprites[1] :
            MoneyManager.TotalMoney > 5000 && MoneyManager.TotalMoney <= 9000 ? backgroundSprites[2] :
            backgroundSprites[3];
    }
}
