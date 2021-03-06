using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;


// Calculador de escalas, calidad y acordes diatonicos
public class ScaleCalculator : MonoBehaviour {
    public List<string> escala = new List<string>();
    public List<Chord> acordes = new List<Chord>();
    public GameObject chordPrefab;
    public string notaInput;
    private List<string> notas = new List<string>();

    private List<string> escala1 = new List<string>();
    private List<string> escala2 = new List<string>();
    private List<string> notasEscala = new List<string>();

    private List<string> sl1;
    private List<string> sl2;


    // Devuelve la escala de una nota
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

    }

    // Genera todos los acordes de la escala
    public List<Chord> CalculateChords(){

        for (int i = 0; i < 7; i++) {
            
            GameObject acordeGM = Instantiate(chordPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Chord acordeObj = acordeGM.GetComponent<Chord>();
            acordeObj.index = i;
            acordeObj.acorde.Add(escala[i%7]); // agregar notas al objeto chord
            acordeObj.acorde.Add(escala[(i+2)%7]);
            acordeObj.acorde.Add(escala[(i+4)%7]);
            //acordeObj.SetName();
            acordeObj.SetType();
            acordeObj.SetStrength();
            acordeObj.SetName();
            acordes.Add(acordeObj);
        }
        return(acordes);

    }

}