using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RythmGenerator : MonoBehaviour {

    public int sub_base = 4;
    public int sub_cant;
    public int index;
    public int seed;
    //4 negras, 8 corcheas o 16 semicorcheas
    //3 negras, 6 corcheas o 12 semicorcheas
    public int[] opciones_clave = new int[] {1,2,4};
    public int subdivision_clave;
    public List<int> clave = new List<int>();
    public List<int> relleno = new List<int>();

    
    public void StartRythm() {
        seed = System.DateTime.Now.Second;
        GenerarRitmo(seed);
        CrearClave(sub_cant,sub_base);
    }

    // Generar metrica, puede ser 3/4 o 4/4 
    public void GenerarRitmo(int seed){
        Random.InitState(seed);
        sub_cant = Random.Range(3,5);
    }

    // Calcula cuantas notas caben en un compás
    public void CrearClave(int sub_cant, int sub_base){
        // Determinar random si serán negras corcheas o semicorcheas
        //                   sub_cant sub_cant*2 sub_cant*3
        index = Random.Range(0,3);
        subdivision_clave = sub_cant*opciones_clave[index]; // 3 x 2 = 6
        
        int randItem = Random.Range(2,4); // escoger 2 o 3 para el arreglo
        while(clave.Sum() < subdivision_clave){  // [2,2,2]
            clave.Add(randItem);
        }
        
        // Validar que el arreglo cumpla con los requisitos
        if(clave.Sum() > subdivision_clave){
            clave.Clear();
            CrearClave(sub_cant,sub_base);
        }
        else{

            if(opciones_clave[index] == 1){
                Debug.Log("negras");
            }
            else if(opciones_clave[index] == 2){
                Debug.Log("corcheas");
            }
            else if(opciones_clave[index] == 4){
                Debug.Log("semicorcheas");
            }
        }

    }

    // Calcular relleno
    // No tocar la primera de cada grupo [0, 1, 0, 1, 0, 1]
    public void CalcularRelleno(){
        for(int i=0; i < clave.Count(); i++){
            if(clave[0] ==2){
                relleno.Add(0);
                relleno.Add(1);
            }
            else if(clave[0]==3){
                relleno.Add(0);
                relleno.Add(1);
                relleno.Add(1);
            }
        }
    }

    public void PlayRelleno(){

    }

    public void PlayRythm(){

    }

}
