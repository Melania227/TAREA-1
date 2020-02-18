using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibujar : MonoBehaviour
{
    public int x;
    public GameObject punto;

    void imprimir(int[] arrayImprimir)
    {
        for (int i = 0; i < arrayImprimir.Length; i++)
        {
            print(arrayImprimir[i] + " ");
        }
    }

    int[] swap(int[] arrayTemp, int iTemp, int jTemp)
    {
        int numCambio = arrayTemp[jTemp - 1];
        arrayTemp[jTemp - 1] = arrayTemp[jTemp];
        arrayTemp[jTemp] = numCambio;
        return arrayTemp;
    }

    public void BubbleSort(int[] arrayList)
    {
        if (arrayList.Length > 0)
        {
            for (int a = 0; a < arrayList.Length; a++)
            {
                for (int i = 1; i < arrayList.Length; i++)
                {
                    int aux = arrayList[i];
                    for (int j = i - 1; j >= 0 && arrayList[j] > aux; j--)
                    {
                        swap(arrayList, j + 1, j);
                    }
                }
            }
        }
        imprimir(arrayList);
    }

    public void insertSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j > 0 && array[j - 1] > array[j]; j--)
            {
                array = swap(array, i, j);
            }
        }
        imprimir(array);
    }

    public void crearPuntos (double[] tiempos)
    {
        for (int i = 0; i<10; i++)
        {
            Instantiate(punto, new Vector3(i, System.Convert.ToSingle(tiempos[i]), 0), Quaternion.identity);
        }
    }

    //Creacion de las listas, se asignan los valores dentro de ellas.
    int[][] cantidadesAOrdenar()
    {
        int[][] cantidadesAOrdenar = new int[10][];
        for (int i = 0; i < 10; i++)
        {
            int[] nuevoArray = new int[(i + 1) ^ 4];
            for (int j = 0; j < nuevoArray.Length; j++)
            {
                nuevoArray.SetValue(Random.Range(-200, 500), j);
            }
            cantidadesAOrdenar.SetValue(nuevoArray, i);
        }
        return cantidadesAOrdenar;
    }

    double[] sacaTiempos(int[][] arrayAOrdenar, int opcion)
    {
        double[] tiempos = new double[10]; 
        if (opcion == 1)
        {
            for (int i = 0; i<10; i++) 
            {
                var tiempoInicial = Time.realtimeSinceStartup;
                BubbleSort(arrayAOrdenar[i]);
                double tiempoTemp = Time.realtimeSinceStartup - tiempoInicial;
                tiempos[i] = tiempoTemp;
            }
        }
        else 
        {
            print("Hola gato");
        }
        return tiempos;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[][] arrayAOrdenar = cantidadesAOrdenar();
        double[] tiemposAGraficar = sacaTiempos(arrayAOrdenar, 1);
        crearPuntos(tiemposAGraficar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
