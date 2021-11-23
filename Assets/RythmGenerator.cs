using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RythmGenerator : MonoBehaviour {

    public int sub_base = 4;
    public int sub_cant;
    public int seed;
    public int[] opciones_clave = new int[] {1,2,4}; //4 negras, corcheas o semicorcheas
    public int subdivision_clave;
    public List<int> clave = new List<int>();

    public ScaleCalculator sc = new ScaleCalculator();
    public List<string> escala = new List<string>();

    // Generar metrica, puede ser 3/4 o 4/4 
    public void GenerarRitmo(int seed){
        Random.InitState(seed);
        sub_cant = Random.Range(3,5);
    }

    // Calcula cuantas notas caben en un compás
    public void CrearClave(int sub_cant, int sub_base){
        // Determinar random si serán negras corcheas o semicorcheas
        //                   sub_cant sub_cant*2 sub_cant*3
        int index = Random.Range(0,3);
        subdivision_clave = sub_cant*opciones_clave[index]; // 3 x 2 = 6
        Debug.Log(opciones_clave[index]);
        
        while(clave.Sum() < subdivision_clave){  // [2,2,2]
            int randItem = Random.Range(2,4); // escoger 2 o 3 para el arreglo
            clave.Add(randItem);
        }
        
        // Validar que el arreglo cumpla con los requisitos
        if(clave.Sum() > subdivision_clave){
            clave.Clear();
            CrearClave(sub_cant,sub_base);
        }

    }

    // Calcular relleno
    
    //public void CrearClave(List<int> clave, int subdivision_clave){

    //}

    private void Start() {
        seed = System.DateTime.Now.Second;
        GenerarRitmo(seed);
        CrearClave(sub_cant,sub_base);
        escala = sc.CalculateScale("mi");
        Debug.Log("escala: "+escala);
        sc.CalculateQuality(escala);

    }

}
