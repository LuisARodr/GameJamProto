using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Money;
using UnityEngine.UI;
using CoreGame;
using UnityEngine.EventSystems;

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
    [SerializeField]
    private Text radio;

    private ArrayList expendingsListList = new ArrayList();
    private ArrayList expendingsListMoneyList = new ArrayList();

    public static bool[] isSick = {false, false, false, false, false};
    private static readonly int[] sickChances = {20, 40, 40, 60, 10 };
    private readonly float[] medicineCost = {500f, 400f, 400f, 300f, 600f };
    public static int foodMultiplier = 1; 
    public static bool[] familyMembersAlive = { true, true, true, true, true };
    public static int numberOfFamilyAlive = 5;
    public static int week = 0;
    /*
     0 = esposa
     1 = hijo
     2 = hija
     3 = bebé 
     4 = perro
     */
    public RectTransform menuSelect;
    private int menuIndex = 0;
    private int menuSize = 0;
    private bool returnedCenter;
    private bool[] selectedMenu;
    private string[] selectedMenuMark;
    /// <summary>
    /// 0 = comida
    /// 1 = caguama
    /// 2 = medicamentos(el que sea)
    /// </summary>
    public static bool[] itemBought = { false, false, false };
    public static bool[] deadFlag = {false,false, false, false, false };


    // Use this for initialization
    void Start () {
        returnedCenter = false;
        week++;

        //sickRoll();

        if(week < 4)
        {
            addBasicExpendings();
            addFamilyExpenses();
        }
        else
        {
            addFinalWeekExpenses();
            addSickExpenses();
        }

        activityList.text = "Periodicos\nPodar\nContruccion\nCosecha";
        earningsList.text = "$ " + MoneyManager.moneyByDay[0].ToString("000.00") + "\n$ " +
            MoneyManager.moneyByDay[1].ToString("000.00") + "\n$ " + MoneyManager.moneyByDay[2].ToString("000.00") + "\n$ " +
            MoneyManager.moneyByDay[3].ToString("000.00");
        subtotalEarnings.text = "$ " + (MoneyManager.moneyByDay[0] + MoneyManager.moneyByDay[1] +
            MoneyManager.moneyByDay[2] + MoneyManager.moneyByDay[3]);
        bonus.text = "x" + MoneyManager.bonusMultiplier;
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





        selectedMenu = new bool[menuSize];
        selectedMenuMark = new string[menuSize];
        for (int i = 1; i < selectedMenu.Length; i++)
        {
            selectedMenu[i] = false;
            selectedMenuMark[i] = "-";
        }
        selectedMenu[0] = true;
        selectedMenuMark[0] = "O";
        MoneyManager.TotalMoney -= (float)expendingsListMoneyList[0];

        aux = "";
        foreach (string mark in selectedMenuMark)
        {
            aux += mark + "\n";
        }

        radio.text = aux;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonUp("Start_Button"))//aqui hace todo lo de cuando se acaba esta pantalla.
        {
            buyItems();
            GameManager.goToScene(2);//actualmente la escena de la casa
        }

        if (Input.GetButtonUp("A_Button"))
        {
            SelectExpend();
        }

        else if (Input.GetButtonUp("B_Button"))
        {
            //menuSelect.position.y += 50f;
            moveMenu(0);
        }


        else if (Input.GetButtonUp("Y_Button"))
        {
            //menuSelect.position.y += 50f;
            moveMenu(1);
        }

        if (returnedCenter)
        {
            if (Controls.LeftJoystick().y < 0)
            {
                moveMenu(0);
            }
            else if (Controls.LeftJoystick().y < 0)
            {
                moveMenu(1);
            }
        }


        subtotalExpendings.text = "$ " + subtotalExpend().ToString("000.00");
        total.text = "TOTAL = " + MoneyManager.TotalMoney;


    }

    private void moveMenu(int direction)
    {
        //direction = 0 down derection = 1 up
        if(direction == 0)
        {
            if(menuIndex + 1 < menuSize)
            {
                menuSelect.localPosition = new Vector3(menuSelect.localPosition.x, menuSelect.localPosition.y - 20f, 0);
                menuIndex++;
            }
            else
            {
                menuSelect.localPosition = new Vector3(menuSelect.localPosition.x, menuSelect.localPosition.y + (20f * menuIndex), 0);
                menuIndex = 0;
            }
            
            
        }
        else
        {
            if ((menuIndex) > 0)
            {
                menuSelect.localPosition = new Vector3(menuSelect.localPosition.x, menuSelect.localPosition.y + 20f, 0);
                menuIndex--;
            }
            else
            {
                menuSelect.localPosition = new Vector3(menuSelect.localPosition.x, menuSelect.localPosition.y - (20f*(menuSize-1)), 0);
                menuIndex = menuSize-1;
            }
               
        }
    }

    private void SelectExpend()
    {
        if(menuIndex != 0)
        {
            if(!(menuIndex == 2 && !selectedMenu[1]))
            {
                if (MoneyManager.TotalMoney - (float)expendingsListMoneyList[menuIndex] >= 0 || selectedMenu[menuIndex])
                {
                    selectedMenu[menuIndex] = !selectedMenu[menuIndex];
                    selectedMenuMark[menuIndex] = selectedMenu[menuIndex] ? "O" : "-";
                    MoneyManager.TotalMoney += selectedMenu[menuIndex] ? -(float)expendingsListMoneyList[menuIndex] :
                        (float)expendingsListMoneyList[menuIndex];
                }
            }
            
        }

        string aux = "";
        foreach (string mark in selectedMenuMark)
        {
            aux += mark + "\n";
        }

        radio.text = aux;
    }
   

    private void buyItems()
    {
        MoneyManager.bonusMultiplier = 1f;
        int i = 0;
        foreach (bool item in selectedMenu)
        {
            switch (i)
            {
                case 1:
                    MoneyManager.bonusMultiplier += item ? 0f : -.2f;
                    itemBought[0] = true;
                    break;
                case 2:
                    MoneyManager.bonusMultiplier += item ? .2f : 0f;
                    itemBought[1] = true;
                    break;
                case 3:
                    foodMultiplier = item ? 1 : 2;
                    break;
                case 4: case 5: case 6: case 7: case 8:
                case 9:
                    if (item)
                    {
                        isSick[familyMemberToNumber((string)expendingsListList[i])] = false;
                        itemBought[2] = true;
                    }
                    break;
                default:break;
            }
        }
    }


    void addBasicExpendings()
    {
        expendingsListList.Add("Renta:");
        expendingsListList.Add("Comida:");
        expendingsListList.Add("Caguama:");
        expendingsListMoneyList.Add(400f);
        expendingsListMoneyList.Add(100f);
        expendingsListMoneyList.Add(400f);
        menuSize += 3;
    }

    void addFamilyExpenses ()
    {

        expendingsListList.Add("Comida:");
        expendingsListMoneyList.Add(400f);
        menuSize++;
        addSickExpenses();
    }

    /*
    0 = esposa
    1 = hijo
    2 = hija
    3 = bebé 
    4 = perro
    */

    void addSickExpenses()
    {
        int i = 0;
        foreach (bool familyMember in isSick)
        {
            if (familyMember)
            {
                expendingsListList.Add("Medicina("+ numberToFamilyMember(i) + "): ");
                expendingsListMoneyList.Add(medicineCost[i]);
                menuSize++;
            }
            i++;
        }
    }

    int familyMemberToNumber(string family)
    {
        int number = 5;
        switch (family)
        {
            case "Medicina(Esposa): ":
                number = 0;
                break;
            case "Medicina(Hijo): ":
                number = 1;
                break;
            case "Medicina(Hija): ":
                number = 2;
                break;
            case "Medicina(Bebé): ":
                number = 3;
                break;
            case "Medicina(Perro): ":
                number = 4;
                break;
        }
        return number;
    }


    public static string numberToFamilyMember(int index)
    {
        string member = "";
        switch (index)
        {
            case 0:
                member = "Esposa";
                break;
            case 1:
                member = "Hijo";
                break;
            case 2:
                member = "Hija";
                break;
            case 3:
                member = "Bebé";
                break;
            case 4:
                member = "Perro";
                break;
        }

        return member;
    }

    void addFinalWeekExpenses()
    {
        expendingsListList.Add("Transporte:");
        expendingsListMoneyList.Add(700f);
        menuSize++;
    }

    public static void sickRoll()
    {
        for (int i = 0; i < isSick.Length; i++)
        {
            if(familyMembersAlive[i])
                isSick[i] = Random.Range(0, 200) < (sickChances[i] * foodMultiplier);
            
        }
    }

    public static void killFamilyMember()
    {
        for (int i = 0;i < familyMembersAlive.Length; i++)
        {
            if (isSick[i] && familyMembersAlive[i])
            {
                deadFlag[i] = true;
                familyMembersAlive[i] = false;
                numberOfFamilyAlive--;
            }
        }
    }

    float subtotalExpend()
    {
        float sum = 0;
        /*
        foreach(float expending in expendingsListMoneyList)
        {
            sum += expending;
        }
        */
        for (int i = 0;i < selectedMenu.Length; i++)
        {
            
            if (selectedMenu[i])
            {
                sum += (float)expendingsListMoneyList[i];
                
            }
        }
        return sum;
    }
}
