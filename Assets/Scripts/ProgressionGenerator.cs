using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProgressionGenerator : MonoBehaviour
{
    public List<Chord> acordes;
    public List<Chord> estructura = new List<Chord>(); // conjunto de acordes en 8 compases
    public bool listaLlena = false;
    public Chord randChord;
    public string lastRandType;
    public List<Chord> fuertes;
    public List<Chord> debiles;

    public List<int> totalDuration;


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
                    totalDuration.Add(randChord.duration);
                    lastRandType = randChord.type;
                    estructura.Add(randChord);

            }
            else if(totalDuration.Sum() == 8){
                listaLlena = true;
            }
        }

        return(estructura);
    }

    public void SetChord(){
        randChord = acordes[Random.Range(0,acordes.Count())];
        randChord.duration = Random.Range(1,5);
        lastRandType = randChord.type;
    }

}