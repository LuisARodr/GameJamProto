using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class GardenGrid : MonoBehaviour {
    [SerializeField]
    GameObject Cesped;
    [SerializeField]
    GameObject Cortado, Cortado2;
    [SerializeField]
    GameObject FlorAzul, FlorBlanca, FlorRosa, Roca1, Roca2, Perro, Fuente;
    [SerializeField]
    int No_Flor = 10, No_roca = 5, No_perro = 2, No_fuente = 1;

    SpriteRenderer spriteren;
    //Cambiar objetos-sprites por lo que debe de pasar
    //Hacer un metodo que diga que sucede cuando se cambia de sprite. EJE: Entero a cortado = 500 puntos. Perro a cortadoRojo = -500 puntos, etc.
    //Debe recibir el nombre del objeto y reaccionar conforme a ello

    //Para la posicion random de los obstaculos conseguir la posicion de la grid

    [SerializeField]
    int gridSizeX = 30, gridSizeY = 30;
    [SerializeField]
    float distanciaX = 1, distanciaY = 1;
    public GameObject[,] grid;


    private void Start()
    {
        grid = new GameObject[gridSizeX, gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                grid[i, j] = Instantiate(Cesped);
                grid[i, j].transform.position = transform.position + new Vector3(i * distanciaX, -j * distanciaY, 0);
                grid[i, j].name = "Cesped " + i + ":" + j;
         
            }
        }
        ObstaculoSet();
    }

    /// <summary>
    /// Este metodo es un "get" para los diferentes obstaculos u objetos. Cesped, Cortado1, Cortado2, Obstaculo1,Obstaculo2, Obstaculo3, Obstaculo4,Obstacul5.
    /// </summary>
    /// <param name="nombre"></param>     
    public GameObject getGameObjectGardenGardin(string nombre)
    {
        //Debug.Log("Objeto gardin a buscar: " + nombre);
        switch (nombre)
        {
            case "Cesped":
                return Cesped;
            case "Cortado":
                return Cortado;
            case "Cortado2":
                return Cortado2;
        }

        return new GameObject();
    }

    /// <summary>
    /// Este metodo sirve como complemento para agregar obstaculos a la grid/escenario del juego, ABC es numero de obstaculos en A, EN B y en C. Ej, 123. A(1), B(2), B(3)
    /// </summary>

    public void ObstaculoSet()
    {
        
        while (No_Flor > 0)
        {
            int r1 = Random.Range(3, gridSizeX - 3);
            int r2 = Random.Range(3, gridSizeY - 3);
            Destroy(grid[r1, r2]);
            grid[r1, r2] = Random.Range(1, 3) > 1 ? Random.Range(1, 3) > 1 ? Instantiate(FlorAzul) : Instantiate(FlorRosa) : Instantiate(FlorBlanca);
            grid[r1, r2].GetComponent<SpriteRenderer>().flipX = Random.Range(1, 3) > 1 ? true : false; 
            grid[r1, r2].transform.position =  new Vector3(r1 * distanciaX, -r2 * distanciaY, 0);
            grid[r1, r2].name = "Flores " + r1 + ":" + r2;
            No_Flor--;
        }
        while (No_roca > 0)
        {
            int r1 = Random.Range(0, gridSizeX);
            int r2 = Random.Range(0, gridSizeY);
            Destroy(grid[r1, r2]);

            grid[r1, r2] = Random.Range(1,3) > 1 ? Instantiate(Roca1) : Instantiate(Roca2);
            grid[r1, r2].GetComponent<SpriteRenderer>().flipX = Random.Range(1, 3) > 1 ? true : false;
            grid[r1, r2].transform.position =  new Vector3(r1 * distanciaX, -r2 * distanciaY, 0);
            grid[r1, r2].name = "Rocas " + r1 + ":" + r2;
            No_roca--;
        }
        while (No_perro > 0)
        {
            int r1 = Random.Range(3, gridSizeX - 3);
            int r2 = Random.Range(3, gridSizeY - 3);
            Destroy(grid[r1, r2]);
            grid[r1, r2] = Instantiate(Perro);
            grid[r1, r2].GetComponent<SpriteRenderer>().flipX = Random.Range(1, 3) > 1 ? true : false;
            grid[r1, r2].transform.position =
            new Vector3(r1 * distanciaX, -r2 * distanciaY, 0);

            grid[r1, r2].name = "Perro " + r1 + ":" + r2;
            No_perro--;
        }
        while (No_fuente > 0)
        {
                 
            int r1 = Random.Range(3, gridSizeX - 3);
            int r2 = Random.Range(3, gridSizeY - 3);

            
            for (int Rr1 = r1 - 1; Rr1 != r1 + 2; Rr1++)
            {
                for (int Rr2 = r2 - 1; Rr2 != r2 + 2; Rr2++)
                {  
                        Destroy(grid[Rr1, Rr2]);
                        grid[Rr1, Rr2] = Instantiate(Cesped);
                        grid[Rr1, Rr2].transform.position =
                        new Vector3(Rr1 * distanciaX, -Rr2 * distanciaY, 0);
                        grid[Rr1, Rr2].name = "Cesped " + Rr1 + ":" + Rr2;
                }
            }
            Destroy(grid[r1, r2]);
            grid[r1, r2] = Instantiate(Fuente);
            grid[r1, r2].GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2) > 1 ? true : false;
            grid[r1, r2].transform.position = new Vector3(r1 * distanciaX, -r2 * distanciaY, 0);
            grid[r1, r2].name = "Fuente " + r1 + ":" + r2;

            No_fuente--;

        }
    }

        

    
    
}

