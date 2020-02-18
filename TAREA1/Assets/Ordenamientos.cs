using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ordenamientos : MonoBehaviour
{

    void imprimir(int[] arrayImprimir)
    {
        for (int i = 0; i < arrayImprimir.Length; i++)
        {
            print(arrayImprimir[i] + " ");
        }
    }

    int[] swap(int[] arrayTemp, int iTemp, int jTemp)
    {
        int numCambio = arrayTemp[jTemp-1];
        arrayTemp[jTemp-1] = arrayTemp[jTemp];
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
        for (int i = 0; i < array.Length-1; i++)
        {
            for (int j = i+1; j > 0 && array[j-1] > array[j]; j--)
            {
                array = swap(array, i, j);
            }
        }
        imprimir(array);
    }

    // Start is called before the first frame update
    void Start()
    {

        /*var tiempoInicial = Time.realtimeSinceStartup;
        "Time for MyExpensiveFunction: " + (Time.realtimeSinceStartup - tiempoInicial)";
        BubbleSort(arrayImpr);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
