using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame;
using UnityEngine.UI;
using Money;

#pragma warning disable 0649

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Car2D : MonoBehaviour
{
    public GardenGrid fgrid;
    protected Animator anim;
    protected Rigidbody2D rb2D;
    protected SpriteRenderer sr;
   
    //Maxima velocidad del carrita
    [SerializeField]
    float maxVel = 5f;

    //clockwise y counterclockwise para saber a donde rotar el carrito
    [SerializeField]
    float clockwise=300;
    [SerializeField]
    float counterClockwise=-300;
    //Variables de score para lo que se puede podar
    [SerializeField]
    int scrFlor = 0, scrPerro = 0, scrPasto = 0;
    int dinero = 0;
    
    //Tiempo que se le da al juego
    float tiempo = 30f;
    float ResVelActual;
    
    //Texto del tiempo y el dinero
    [SerializeField]
    Text time, money;

    //Velocidad que da cada presionada
    [SerializeField]
    float VelxPress = 1f;
    //Tiempo que se le da para presionar antes de que frene
    [SerializeField]
    float tiempoPress = .5f;
    //Desaceleracion del vehiculo despues de dejar de presionar el boton
    [SerializeField]
    float Desaceleracion = 2f;

    //Velocidad actual del carro y tiempo restante de presionar actual
    float VelActual = 0f, tiempoPressactual= 0f;
    //Contador de desaceleracion
    float TPderrape;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        MoneyManager.IniciateMoney();
    }
    private void Update()
    {

        //Pues aqui esta el tiempo
        if (tiempo > 0) { tiempo -= Time.deltaTime;
        }else if(tiempo <= 0)
        {
            //AQUI INGRESA LAS WEAS DEL GAMEOVER AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
            tiempo = 0;
            VelActual = 0;
            MoneyManager.EndActivity();
            GameManager.goToScene(20);//16 es el numero actual de la escena de transicion.

        }

        //Metodo de desaceleracion, tiempopressactual 
         tiempoPressactual -= Time.deltaTime;
        if (tiempoPressactual <=0){  
            TPderrape -= Time.deltaTime;
            if (TPderrape < 0f)
            {
                VelActual -= Desaceleracion;
                TPderrape = VelxPress;
                if (VelActual < 0)
                {
                    VelActual = 0f;
                }
            } 
        }
        
        time.text = "" + (int) tiempo;
        money.text = "$" + dinero;
        

    }
    void FixedUpdate()
    {

        //Siempre se llama con la velocidad actual para saber si el carro se movera o no.
        Move2D(VelActual);

        //Rota el carrito cuando se presiona el joystick  o presionando Q o E
        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {

            float izq = Controls.LeftHorizontal();
            rb2D.freezeRotation = true;
            //   Debug.Log("Palanca movida a x " + izq);
            if (izq < 0 || Input.GetKey(KeyCode.Q))
            {
                anim.SetTrigger("PressQ");
                transform.Rotate(0, 0, Time.deltaTime * clockwise);
            }
            if (izq > 0 || Input.GetKey(KeyCode.E))
            {
                anim.SetTrigger("PressE");
                transform.Rotate(0, 0, Time.deltaTime * counterClockwise);
            }
        }

        //Aumenta la velocidad Actual cada vez que se presiona el Boton A o la tecla de W. Velocidad actual se le suma velocidad por presionado
        //eL Tiempo para presionar actual se reinicia al tiempo para presionar, al igual que el contador de desaceleracion
        if (Input.GetButtonUp("A_Button") || Input.GetKeyUp(KeyCode.W))
        {
           // Debug.Log("Vel Actual!!!! " + VelActual);
            VelActual += VelxPress;
            if (VelActual > maxVel)
            {
                VelActual = maxVel;
            }
            tiempoPressactual = tiempoPress;
            TPderrape = VelxPress;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int point = collision.name.IndexOf(":");
        int space = collision.name.IndexOf(" ");
        
     //Aqui realiza la accion para cada tipo de objeto podable. 
        if (collision.name.StartsWith("Cesped")) {
            int x = int.Parse(collision.name.Substring(space + 1, point - 1 - space));
            int y = int.Parse(collision.name.Substring(point + 1, collision.name.Length - point - 1));

            Vector3 NuevaPos = fgrid.grid[x, y].transform.position;
            string NuevoNomb = fgrid.grid[x, y].name;
            Destroy(fgrid.grid[x, y]);

            fgrid.grid[x, y] = Instantiate(fgrid.getGameObjectGardenGardin("Cortado"));
            fgrid.grid[x, y].transform.position = NuevaPos;
            fgrid.grid[x, y].name = "Cortado ";
  
           MoneyManager.AddActivityMoney(scrPasto);
        }else if (collision.name.StartsWith("Perro"))
        {
            int x = int.Parse(collision.name.Substring(space + 1, point - 1 - space));
            int y = int.Parse(collision.name.Substring(point + 1, collision.name.Length - point - 1));

            Vector3 NuevaPos = fgrid.grid[x, y].transform.position;
            string NuevoNomb = fgrid.grid[x, y].name;
            Destroy(fgrid.grid[x, y]);

            fgrid.grid[x, y] = Instantiate(fgrid.getGameObjectGardenGardin("Cortado2"));
            fgrid.grid[x, y].transform.position = NuevaPos;
            fgrid.grid[x, y].name = "Cortado2 "; 


          MoneyManager.AddActivityMoney(scrPerro);
        }
        else if (collision.name.StartsWith("Flores"))
        {
            int x = int.Parse(collision.name.Substring(space + 1, point - 1 - space));
            int y = int.Parse(collision.name.Substring(point + 1, collision.name.Length - point - 1));

            Vector3 NuevaPos = fgrid.grid[x, y].transform.position;
            string NuevoNomb = fgrid.grid[x, y].name;
            Destroy(fgrid.grid[x, y]);

            fgrid.grid[x, y] = Instantiate(fgrid.getGameObjectGardenGardin("Cortado"));
            fgrid.grid[x, y].transform.position = NuevaPos;
            fgrid.grid[x, y].name = "Cortado ";
 
            MoneyManager.AddActivityMoney(scrFlor);

        }





    }

    protected virtual void Move2D(float velActul)
    {

        float ComponentX2 = velActul;
        //Vector2 mov = Controls.LeftJoystick();
        rb2D.AddRelativeForce( Vector2.up * ComponentX2, ForceMode2D.Impulse);

        if(velActul > maxVel)
        {
            velActul = maxVel;
        }
        Vector2 clampVelocity = Vector2.ClampMagnitude(rb2D.velocity, velActul);
 

        rb2D.velocity = new Vector2(ComponentX2 != 0f & rb2D.velocity.x != 0f ?
        clampVelocity.x : ComponentX2 != 0f ? clampVelocity.x : 0f,
        ComponentX2 != 0f & rb2D.velocity.y != 0f ?
        clampVelocity.y : ComponentX2 != 0f ? clampVelocity.y : 0f);
        //  Debug.Log(rb2D.velocity);
        rb2D.velocity -= ComponentX2 == 0f ? rb2D.velocity : Vector2.zero;
        // Aqui se le agrega la velocidad por boton press a la velocidad actual
       
        //Aqui se resetea el timer de tiempo tiempopressactual

      
    }
 
    protected float ComponentX
    {
        get
        {
            return Controls.LeftJoystick().x;
        }
    }

    protected float ComponentX2
    {
        get
        {
            return Controls.LeftJoystick().x;
        }
    }

}




