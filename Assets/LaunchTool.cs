using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTime;


public class LaunchTool : MonoBehaviour {

    [SerializeField]
    GameObject Tool;
    [SerializeField]
    GameObject Hand;

    public ShouderRotation shouderRotation;
    public FillPowerBar fillPowerBar;
    private ToolControl toolControl;
    public SpriteRenderer toolSelect0;
    public SpriteRenderer toolSelect1;
    public SpriteRenderer toolSelect2;



    private GameObject activeTool;



    private bool isInHand ;

    public float throwStrength = 100;

    private int toolType = 0;

    private Color yellow = new Color(1,1,0);
    private Color blue = new Color(0, 0, 1);
    private Color green = new Color(0, 1, 0);
    private Color alphaYellow = new Color(1, 1, 0, .3f);
    private Color alphaBlue = new Color(0, 0, 1, .3f);
    private Color alphaGreen = new Color(0, 1, 0, .3f);

    public float gameTime = 30;
    private TimeManager timeManager;

    // Use this for initialization
    void Start () {
        CreateTool();
        ChangeToolSelectColor();
        timeManager = new TimeManager(gameTime);
    }
	
	// Update is called once per frame
	void Update () {


        if (isInHand)
        {
            activeTool.transform.position = Hand.transform.position;
            //print("hullo?");
        }

        if (Input.GetButtonDown("Y_Button"))
        {
            toolType = 1;
            ChangeToolSelectColor();
        }

        else if (Input.GetButtonDown("X_Button"))
        {
            toolType = 0;
            ChangeToolSelectColor();
        }

        else if (Input.GetButtonDown("A_Button"))
        {
            toolType = 2;
            ChangeToolSelectColor();
        }

        else if (Input.GetButtonDown("B_Button"))
        {
            DestroyActiveTool();
            CreateTool();
        }


        else if (Input.GetButtonUp("B_Button"))
        {
            isInHand = false;
            //Por alguna razon x y y van alrevez,
            float y = fillPowerBar.finalPowerBarValue * Mathf.Sin(shouderRotation.angle * Mathf.Deg2Rad);
            float x = fillPowerBar.finalPowerBarValue * Mathf.Cos(shouderRotation.angle * Mathf.Deg2Rad);
            print("Shoulder Angle = " + (shouderRotation.angle) + " PowerBarValue = " 
                + fillPowerBar.finalPowerBarValue + "\n X : " + x + " Y : " + y);
            activeTool.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y) * throwStrength);
        }

        //hace algo si se acaba el tiempo
        if (timeManager.IsTimeOverUpdate())
        {
            //print("Time is OVER");
        }
    }

    void CreateTool()
    {
        isInHand = true;
        activeTool = Instantiate(Tool, Hand.transform.position, Quaternion.identity);
        toolControl = activeTool.GetComponent<ToolControl>();
        toolControl.type = toolType;
    }

    void DestroyActiveTool()
    {
        Destroy(activeTool);
    }

    private void ChangeToolSelectColor()
    {
        switch (toolType){
            case 0:
                toolSelect0.color = alphaYellow;
                toolSelect1.color = blue;
                toolSelect2.color = alphaGreen;
                break;
            case 1:
                toolSelect0.color = yellow;
                toolSelect1.color = alphaBlue;
                toolSelect2.color = alphaGreen;
                break;
            case 2:
                toolSelect0.color = alphaYellow;
                toolSelect1.color = alphaBlue;
                toolSelect2.color = green;
                break;
        }
    }

}
