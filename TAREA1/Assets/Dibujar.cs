using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibujar : MonoBehaviour
{
    public int x;
    public GameObject punto;
    public Material colorAzul;
    public Material colorVerde;
    public TextMesh ejesText;

    void imprimir(int[] arrayImprimir)
    {
        string lista ="";
        for (int i = 0; i < arrayImprimir.Length; i++)
        {
            lista+= arrayImprimir[i] + " ";
        }
        print(lista);
    }

    int[] swap(int[] arrayTemp, int iTemp, int jTemp)
    {
        int numCambio = arrayTemp[iTemp];
        int paraImprimir = arrayTemp[jTemp];
        arrayTemp[iTemp] = arrayTemp[jTemp];
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

    public void crearPuntos (double[] tiempos, double[] tiempos2)
    {
        for (int i = 0; i<10; i++)
        {
            var bolita = Instantiate(punto, new Vector3(i, System.Convert.ToSingle(tiempos[i]), 0), Quaternion.identity);
            bolita.GetComponent<MeshRenderer>().material = colorAzul;
            var ejeCantidadesText = Instantiate(ejesText, new Vector3(System.Convert.ToSingle(i - 0.2), -1, 0), Quaternion.identity);
            ejeCantidadesText.text = "  ^  " + "\n" + ((int)Mathf.Pow((i + 3), 4)).ToString();
            ejeCantidadesText.characterSize = System.Convert.ToSingle(0.2);
            var bolita2 = Instantiate(punto, new Vector3(i, System.Convert.ToSingle(tiempos2[i]), 0), Quaternion.identity);
            bolita2.GetComponent<MeshRenderer>().material = colorVerde;
            
        }
        for (int i = 0; i < 16; i++) {
            var ejeTiempoText = Instantiate(ejesText, new Vector3(-2, i, 0), Quaternion.identity);
            ejeTiempoText.text = i.ToString();

        }
    }

    //Creacion de las listas, se asignan los valores dentro de ellas.
    int[][] cantidadesAOrdenar()
    {
        int[][] cantidadesAOrdenar = new int[10][];
        for (int i = 0; i < 10; i++)
        {
            int largo = (int)Mathf.Pow((i + 3), 4);
            int[] nuevoArray = new int[largo];
            for (int j = 0; j < nuevoArray.Length; j++)
            {
                int num = Random.Range(-2000, 10000);
                nuevoArray.SetValue(num, j);
                //print("Nuevo numero:"+ num);
            }
            //print("Nuevo arreglo creado, largo:" + largo+" guardado en posicion: "+i);
            cantidadesAOrdenar.SetValue(nuevoArray, i);
        }
        return cantidadesAOrdenar;
    }

    //Calcula los tiempos que duran los algoritmos
    double[] sacaTiempos(int[][] arrayAOrdenar, int opcion)
    {
        double[] tiempos = new double[10]; 
        if (opcion == 1)
        {
            for (int i = 0; i<10; i++) 
            {
                print("Lista numero: " + i);
                var tiempoInicial = Time.realtimeSinceStartup;
                BubbleSort(arrayAOrdenar[i]);
                double tiempoTemp = Time.realtimeSinceStartup - tiempoInicial;
                print("Lista numero: " + i +" Dura: "+tiempoTemp);
                tiempos[i] = tiempoTemp;
            }
        }
        else 
        {
            for (int i = 0; i < 10; i++)
            {
                print("Lista numero: " + i);
                var tiempoInicial = Time.realtimeSinceStartup;
                insertSort(arrayAOrdenar[i]);
                double tiempoTemp = Time.realtimeSinceStartup - tiempoInicial;
                print("Lista numero: " + i + " Dura: " + tiempoTemp);
                tiempos[i] = tiempoTemp;
            }
        }

        return tiempos;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[][] arrayAOrdenar = cantidadesAOrdenar();
        int[][] arrayAOrdenar2 = (int[][])arrayAOrdenar.Clone();
        double[] tiemposAGraficar1 = sacaTiempos(arrayAOrdenar, 1);
        double[] tiemposAGraficar2 = sacaTiempos(arrayAOrdenar2, 2);
        crearPuntos(tiemposAGraficar1, tiemposAGraficar2);
        //cambiar funcion de tiempo?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
