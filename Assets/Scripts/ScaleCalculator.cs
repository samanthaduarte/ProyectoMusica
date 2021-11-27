using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;


// Calculador de escalas, calidad y acordes diatonicos
public class ScaleCalculator : MonoBehaviour {

    public int notaIndex = 0;
    public List<string> escala = new List<string>();
    public string notaInput;
    public List<string> notas = new List<string>();

    public List<string> escala1 = new List<string>();
    public List<string> escala2 = new List<string>();
    public List<string> notasEscala = new List<string>();

    public List<string> sl1;
    public List<string> sl2;


    // Recibe una nota y devuelve su escala
    public void CalculateScale(){
        notas.Add("do");
        notas.Add("do#");
        notas.Add("re");
        notas.Add("re#");
        notas.Add("mi");
        notas.Add("fa");
        notas.Add("fa#");
        notas.Add("sol");
        notas.Add("sol#");
        notas.Add("la");
        notas.Add("la#");
        notas.Add("si");

        int contador = 5;

        notaInput = notas[Random.Range(0,notas.Count())];

        Debug.Log(notaInput);

        //Mostrar escala
        for (int i = 0; i < notas.Count(); i++)
        {
            if(notaInput == notas[i]){
                sl1 = notas.GetRange(0,i);
            }
        }
        escala1 = sl1;
        notas.Reverse();

        for (int i = 0; i < notas.Count(); i++)
        {
            if(notaInput == notas[i]){
                sl2 = notas.GetRange(0,i+1);
            }
        }
        escala2 = sl2;
        escala2.Reverse();


        notasEscala.AddRange(escala2);
        notasEscala.AddRange(escala1);

        escala.Add(notasEscala[0]);
        escala.Add(notasEscala[2]);
        escala.Add(notasEscala[4]);
        escala.Add(notasEscala[5]);
        escala.Add(notasEscala[7]);
        escala.Add(notasEscala[9]);
        escala.Add(notasEscala[11]);
        escala.Add(notasEscala[0]);

        Debug.Log(escala);
    }

    // Genera todos los acordes de la escala
    public List<Chord> CalculateChords(){

        List<Chord> acordes = new List<Chord>();
        for (int i = 0; i < 7; i++) {
            Chord acordeObj = new Chord();
            acordeObj.index = i;
            acordeObj.acorde.Add(escala[i%7]); // agregar notas al objeto chord
            acordeObj.acorde.Add(escala[(i+2)%7]);
            acordeObj.acorde.Add(escala[(i+4)%7]);
            acordeObj.SetType();
            acordeObj.SetStrength();
            acordes.Add(acordeObj);
            i+=1;
        }
        return(acordes);
    }

}