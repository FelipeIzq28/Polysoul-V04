using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeCordura : MonoBehaviour
{
    // Start is called before the first frame update
    public float corduraActual;
    public float corduraMaxima;

    public Image barra;

    private float duracion = 0;
    private float cadaS = 2;


    void Start()
    {
        //StartCoroutine("Cordura");
    }

    // Update is called once per frame
    void Update()
    {
       
        barra.fillAmount = corduraActual / corduraMaxima;
        if(Time.time >= duracion)
        {
            duracion = Time.time + cadaS;
            corduraActual = corduraActual - 10;
        }
       
    }
    //private IEnumerator Cordura()
    //{
    //    corduraActual = corduraActual - 10;

    //    yield return new WaitForSeconds(1);
        
    //}
}
  
