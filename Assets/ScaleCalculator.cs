using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Calculador de escalas, calidad y acordes diatonicos
public class ScaleCalculator : MonoBehaviour {

    public int notaIndex = 0;
    
    public List<string> notas = new List<string>();

    public void Start(){
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
    }
    // Recibe una nota y devuelve su escala
    public List<string> CalculateScale(string notaInput){

        int sl1 = 0;
        int sl2 = 0;

        List<string> escala = new List<string>();
        List<string> escala1 = new List<string>();
        List<string> escala2 = new List<string>();
        List<string> notasEscala = new List<string>();
        int contador = 5;

        Console.WriteLine("Por favor ingrese la nota:\n");
        //string notaInput = Console.ReadLine();

        //Mostrar escala
        for (int i = 0; i < notas.Count(); i++)
        {
            if(notaInput == notas[i]){
                sl1 = i;
            }
        }
        escala1 = notas.GetRange(0,sl1);
        escala1.Reverse();

        for (int i = 0; i < notas.Count(); i++)
        {
            if(notaInput == notas[i]){
                sl2 = i+1;
            }
        }
        escala2 = notas.GetRange(0,sl2);
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

        //Console.WriteLine(escala);
        escala.RemoveAt(escala.Count());

        return(escala);
    }

    // Recibe una escala e imprime sus acordes y calidades
    public void CalculateQuality(List<string> escala){

        List<List<string>> acordes = new List<List<string>>();

        Console.WriteLine("Acordes: ");

        for (int i = 0; i < 7; i++) {
            List<string> acorde = new List<string>();
            acorde.Add(escala[i%7]);
            acorde.Add(escala[(i+2)%7]);
            acorde.Add(escala[(i+4)%7]);
            acordes.Add(acorde);
            i+=1;
        }

        for (int i = 0; i < acordes.Count(); i++) {
            if(i == 0 || i == 3 || i == 4){
                Console.WriteLine(acordes[i][0],"mayor:");
            }
            else if(i == 1 || i == 2 || i == 5){
                Console.WriteLine(acordes[i][0],"menor:");
            }
            else if(i == 6){
                Console.WriteLine(acordes[i][0],"disminuido:");
            }
            Console.WriteLine(acordes[i]);
        }
    }
    
}

