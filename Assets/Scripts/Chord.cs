using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord : MonoBehaviour
{
    public int index;
    public List<string> acorde = new List<string>();
    public int duration = 0; //duracion (compases que ocupa) del acorde
    public string type; //tonica, dominante, subdominante
    public string strength; //fuerte o debil
    public List<string> strengthList = new List<string>(); 

    public void SetType(){
        // Determinar tipo del acorde
        if(index == 0 || index == 2 || index == 5){
            type = "tonica";
        }
        else if(index == 1 || index == 3){
            type = "subdominante";
        }
        else if(index == 4 || index == 6){
            type = "dominante";
        }
    }

    public void SetStrength(){
        // Determinar fuerza del acorde
        strengthList.Add("fuerte");
        strengthList.Add("debil");

        if(type == "tonica" ){
            strength = "fuerte";
        }
        else if(type == "sudominante" ){
            strength = "debil";
        }
        else if(type == "dominante"){
            strength = strengthList[Random.Range(0,2)];
        }
    }

    public void SetDuration(int dur){
        duration = dur;
    }

    public void PlayChord(){
        Note note = GameObject.Find("Sounds").GetComponent<Note>();
        note.PlayNote(acorde[0]);
        note.PlayNote(acorde[1]);
        note.PlayNote(acorde[2]);
    }
}

