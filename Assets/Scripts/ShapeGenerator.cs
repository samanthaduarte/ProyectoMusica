using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public List<Chord> estructura = new List<Chord>(); // conjunto de acordes en 8 compases
    public ProgressionGenerator pg = new ProgressionGenerator();
    public List<string> opciones = new List<string>();

    public List<List<Chord>> GenerateShape(List<string> estructura)
    {
        List<List<Chord>> shapes = new List<List<Chord>>();
        List<string> letters = new List<string>();
        opciones.Add("A");
        opciones.Add("B");
        opciones.Add("C");
        opciones.Add("D");

        // Asignar una estructura diferente a cada letra
        foreach (string letra in opciones){
            switch(opciones[Random.Range(0,5)]){
                // Generar una combinacion al azar
                case "A":
                    shapes.Add(pg.FillCompasses());
                    break;
                case "B":
                    shapes.Add(pg.FillCompasses());
                    break;
                case "C":
                    shapes.Add(pg.FillCompasses());
                    break;
                case "D":
                    shapes.Add(pg.FillCompasses());
                    break;
            }
        }

        // Devolver shape
        return(shapes);
    }
}