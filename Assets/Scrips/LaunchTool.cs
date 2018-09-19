using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTime;
using Money;

/// <summary>
/// Controla el lanzamiento de las herramientas desde el personaje.
/// </summary>
public class LaunchTool : MonoBehaviour {
    /// <summary>
    /// Prefab de la herramienta a lanzar
    /// </summary>
    [SerializeField]
    GameObject Tool;
    /// <summary>
    /// de este gameObject se toma la posicion desde la que se va a lanzar la herramienta
    /// </summary>
    [SerializeField]
    GameObject Hand;

    /// <summary>
    /// Script para tomar el angulo de lanzamiento
    /// </summary>
    public ShouderRotation shouderRotation;
    /// <summary>
    /// Script para tomar la fuerza del lanzamiento
    /// </summary>
    public FillPowerBar fillPowerBar;
    /// <summary>
    /// Script para modificar las propiedades de la herramienta que va a ser lanzada
    /// </summary>
    private ToolControl toolControl;
    /// <summary>
    /// Sprite de la primera herramienta para la seleccion de herramietas
    /// </summary>
    public SpriteRenderer toolSelect0;
    /// <summary>
    /// Sprite de la segunda herramienta para la seleccion de herramietas
    /// </summary>
    public SpriteRenderer toolSelect1;
    /// <summary>
    /// Sprite de la tercera herramienta para la seleccion de herramietas
    /// </summary>
    public SpriteRenderer toolSelect2;


    /// <summary>
    /// Instancia de la herramienta activa
    /// </summary>
    private GameObject activeTool;


    /// <summary>
    /// Representa si hay una herramienta activa en la mano del personaje
    /// </summary>
    private bool isInHand ;
    /// <summary>
    /// Representa la fuerza del lanzamiento.
    /// un valor de 20 resulto ser un buen valor para el tamanio del nivel
    /// </summary>
    public float throwStrength = 20;
    /// <summary>
    /// Representa el tipo de herramienta que se va a lanzar
    /// </summary>
    private int toolType = 0;

    /// <summary>
    /// Colores para los selectores de herramientas.
    /// Creo que esto es por mientras, remplazar luego por sprites?
    /// </summary>
    private Color yellow = new Color(1,1,1);
    private Color blue = new Color(1, 1, 1);
    private Color green = new Color(1, 1, 1);
    private Color alphaYellow = new Color(1, 1, 1, .3f);
    private Color alphaBlue = new Color(1, 1, 1, .3f);
    private Color alphaGreen = new Color(1, 1, 1, .3f);

    /// <summary>
    /// Tiempo de juego en segundos
    /// </summary>
    public float gameTime = 60f;
    /// <summary>
    /// Controlador de tiempo
    /// </summary>
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
            DestroyActiveTool();
            CreateTool();
            isInHand = false;

            //Por alguna razon x y y van alrevez,
            float y = fillPowerBar.finalPowerBarValue * Mathf.Sin(shouderRotation.angle * Mathf.Deg2Rad);
            float x = fillPowerBar.finalPowerBarValue * Mathf.Cos(shouderRotation.angle * Mathf.Deg2Rad);
            print("Shoulder Angle = " + (shouderRotation.angle) + " PowerBarValue = " 
                + fillPowerBar.finalPowerBarValue + "\n X : " + x + " Y : " + y + 
                "\n ThrowStrength : " + throwStrength);
            activeTool.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y) * throwStrength);
        }

        //hace algo si se acaba el tiempo
        if (timeManager.IsTimeOverUpdate())
        {
            //print("Time is OVER");
            MoneyManager.EndActivity();
            print(MoneyManager.TotalMoney);
            GameManager.goToScene(5);//5 es el numero actual de la escena de transicion.
        }
    }

    /// <summary>
    /// Crea una herramienta y la pone el la mano, cambia las propiedades de la herramienta
    /// dependiendo del toolType actual
    /// </summary>
    void CreateTool()
    {
        isInHand = true;
        activeTool = Instantiate(Tool, Hand.transform.position, Quaternion.identity);
        toolControl = activeTool.GetComponent<ToolControl>();
        toolControl.type = toolType;
    }

    /// <summary>
    /// Destruye la herramienta actual
    /// </summary>
    void DestroyActiveTool()
    {
        Destroy(activeTool);
    }

    /// <summary>
    /// Cambia los colores del selector de herramientas dependiendo del toolType
    /// </summary>
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