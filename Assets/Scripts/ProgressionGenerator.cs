using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProgressionGenerator : MonoBehaviour
{
    public ScaleCalculator sc = new ScaleCalculator();
    public List<int> espacios = new List<int>();
    public List<Chord> estructura = new List<Chord>(); // conjunto de acordes en 8 compases

    public int totalDuration = 0;
    public string actualStrength = "fuerte";
    public string actualType;
    public List<string> possibleTypes;
    public List<int> duracionAcorde = new List<int>();
    public int index = 0;
    public Chord acorde;
    public List<Chord> fuertes;
    public List<Chord> debiles;
    public List<Chord> acordes;


    public void WeakOrStrong(List<Chord> acordes){
        foreach (Chord element in acordes){
            if(element.strength == "fuerte"){
                fuertes.Add(element);
            }
            if(element.strength == "debiles"){
                fuertes.Add(element);
            }
        } 
    }
    public List<Chord> FillCompasses()
    {
        //Clasificar en fuertes y débiles
        //WeakOrStrong(acordes);
        // Generar estructura de 8 compases
        //      Escoger un acorde random
        //      Si es igual a (actualStrength) agregar !
        //      Si es subdominante y el anterior tambien, no agregar (repetir funcion)
        //      Asignar duracion de los acordes
        // Un acorde puede durar 1 a 4 compases

        acorde = acordes[Random.Range(0,acordes.Count())];

        // Empezar con un acorde fuerte
        if(acorde.strength == actualStrength){
            estructura.Add(acorde);
        }
        else{
            SetChord();  
        }

        while(totalDuration < 8){ 
            // Verificar que no haya dos subdominantes seguidos
            if(actualType == "subdominante" & estructura[index-1].type == "subdominante"){
                SetChord(); 
            }
            else{
                acorde.SetDuration(Random.Range(0,5));
                totalDuration = totalDuration+acorde.duration;
                estructura.Add(acorde);
                index++;
            }
        }
        // Validar que el acorde no dure más de 4 compases y que toda la estructura no sume mas de 8 compases
        if(totalDuration > 8 || acorde.duration > 4){
            estructura.RemoveAt(estructura.Count()-1);
            FillCompasses();
        }

        return(estructura);
 
    }

    public void SetChord(){
        acorde = acordes[Random.Range(0,acordes.Count())];
        actualType = acorde.type;
        actualStrength = acorde.strength;
    }

}