using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibujar : MonoBehaviour
{
    public int x;
    public GameObject punto;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(punto, new Vector3(5, 5, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
