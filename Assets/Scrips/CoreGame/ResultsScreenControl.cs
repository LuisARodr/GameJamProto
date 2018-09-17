using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;
using UnityEngine.UI;


public class ResultsScreenControl : MonoBehaviour {

    [SerializeField]
    private Text activityList;
    [SerializeField]
    private Text earningsList;
    [SerializeField]
    private Text subtotalEarnings;
    [SerializeField]
    private Text bonus;
    [SerializeField]
    private Text expendingsList;
    [SerializeField]
    private Text expendingsListMoney;
    [SerializeField]
    private Text subtotalExpendings;
    [SerializeField]
    private Text total;

    private ArrayList expendingsListList = new ArrayList();
    private ArrayList expendingsListMoneyList = new ArrayList();

    public static bool[] isSick = {false, false, false, false, false};
    private float[] sickChances = {.1f, .2f, .2f, .3f, .05f };
    private float[] medicineCost = {500f, 400f, 400f, 300f, 600f };
    private static int foodMultiplier = 1;
    public static bool[] familyMembersAlive = { true, true, true, true, true };
    public static int numberOfFammilyAlive = 5;
    /*
     0 = esposa
     1 = hijo
     2 = hija
     3 = bebé 
     4 = perro
     */

    // Use this for initialization
    void Start () {

        addBasicExpendings();

        activityList.text = "Periodicos\nPodar\nContruccion\nCosecha";
        earningsList.text = "$ " + MoneyManager.moneyByDay[0].ToString("000.00") + "\n$ " +
            MoneyManager.moneyByDay[1].ToString("000.00") + "\n$ " + MoneyManager.moneyByDay[2].ToString("000.00") + "\n$ " +
            MoneyManager.moneyByDay[3].ToString("000.00");
        subtotalEarnings.text = "$ " +(MoneyManager.moneyByDay[0] + MoneyManager.moneyByDay[1] +
            MoneyManager.moneyByDay[2] + MoneyManager.moneyByDay[3]);
        bonus.text = "x" + MoneyManager.bonusMultiplier ;
        string aux = "";
        foreach (string expend in expendingsListList)
        {
            aux += expend + "\n";
        }
        expendingsList.text = aux;
        aux = "";
        foreach (float expend in expendingsListMoneyList)
        {
            aux += "$ " + expend.ToString("000.00") + "\n";
        }
        expendingsListMoney.text = aux;
        subtotalExpendings.text = "???";

    }
	
	// Update is called once per frame
	void Update () {
        
        total.text = "TOTAL = " + MoneyManager.TotalMoney;
    }
    
    void addBasicExpendings()
    {
        expendingsListList.Add("Renta:");
        expendingsListList.Add("Comida:");
        expendingsListList.Add("Caguama:");
        expendingsListMoneyList.Add(400f);
        expendingsListMoneyList.Add(100f);
        expendingsListMoneyList.Add(400f);
    }

    void addFamilyExpenses ()
    {
        expendingsListList.Add("Comida:");
        expendingsListMoneyList.Add(400f);


        int i = 0;
        foreach (bool familyMember in isSick)
        {
            if (familyMember)
            {
                expendingsListList.Add("Medicina: ");
                expendingsListMoneyList.Add(medicineCost[i]);
            }
            i++;
        }
    }


    void sickRoll()
    {
        
        for (int i = 0; i < isSick.Length; i++)
        {
            isSick[i] = Random.Range(0, 200) < (sickChances[i] * foodMultiplier);
        }
    }
}
