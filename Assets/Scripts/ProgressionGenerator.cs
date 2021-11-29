using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProgressionGenerator : MonoBehaviour
{
    public List<Chord> acordes;
    public List<Chord> estructura = new List<Chord>(); // conjunto de acordes en 8 compases
    public bool listaLlena = false;
    public bool isSubdom = false;
    public int indexSub = 0;
    public Chord randChord;
    public string lastRandType;
    public List<Chord> fuertes;
    public List<Chord> debiles;

    public List<int> totalDuration;
    public List<string> types;
    public void WeakOrStrong(List<Chord> acordes){
        foreach (Chord element in acordes){
            if(element.strength == "fuerte"){
                fuertes.Add(element);
            }
            if(element.strength == "debiles"){
                debiles.Add(element);
            }
        } 
    }

    //Clasificar en fuertes y débiles
    // Generar estructura de 8 compases
    //      Escoger un acorde random
    //      Si es igual a (actualStrength) agregar !
    //      Cambiar isStrong
    //      Si no es subdominante y el anterior tampoco, agregar
    //      Asignar duracion de los acordes (1 a 4 compases)
    public List<Chord> FillCompasses() // Llenar 8 compases de acordes de la escala
    {

        while(!listaLlena){
            SetChord(); 
            if(totalDuration.Sum() + randChord.duration <= 8){
                //if(lastRandType == "subdominante" & randChord.type != "subdominante"){
                    totalDuration.Add(randChord.duration);
                    lastRandType = randChord.type;
                    estructura.Add(randChord);
                //}
                //else{
                    Debug.Log(randChord.type + " igual a " + lastRandType);
                //}
            }
            else if(totalDuration.Sum() == 8){
                listaLlena = true;
            }
        }

        foreach (Chord chord in estructura){ 
            Debug.Log(chord.nombre + chord.type + chord.duration + chord.strength);
        }

        return(estructura);
    }

    public void SetChord(){
        randChord = acordes[Random.Range(0,acordes.Count())];
        randChord.duration = Random.Range(1,5);
        lastRandType = randChord.type;
    }

}



/*

            



            if(totalDuration.Sum() == 8){
                break;
            }
            else{
                SetChord(); 
                totalDuration.Add(randChord.duration);
                estructura.Add(randChord);
            }



        Chord randChord = SetChord();
        if(randChord.type == "subdominante" & randChord.type != "subdominante"){
            estructura.Add(randChord);
        }else{

        }

        if(totalDuration < 8){
            Chord randChord = SetChord();
            estructura.Add(randChord); 
        }
        return(estructura);


if(num%2 == 0){
  Console.WriteLine("Number is even")
}else{
  Console.WriteLine("Number is odd")
}

        while(totalDuration < 8){  
            Chord randChord = acordes[Random.Range(0,acordes.Count())];
            estructura.Add(randChord);
            randChord.duration = Random.Range(1,5);
            totalDuration = totalDuration + randChord.duration;
        }
        
        // Validar que el arreglo cumpla con los requisitos
        if(totalDuration > 8){
            estructura.Clear();
            FillCompasses();
        }
        
        return(estructura);
 

        }*/