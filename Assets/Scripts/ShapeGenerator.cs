using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public ProgressionGenerator pg = new ProgressionGenerator();
    private List<string> opciones = new List<string>();

    public List<List<Chord>> GenerateShape()
    {
        List<List<Chord>> shapes = new List<List<Chord>>();
        List<string> letters = new List<string>();
        opciones.Add("A");
        opciones.Add("B");
        opciones.Add("C");
        opciones.Add("D");

        // Una lista de 8 compases de acordes por seccion
        List<Chord> estructuraA = pg.FillCompasses();
        List<Chord> estructuraB = pg.FillCompasses();
        List<Chord> estructuraC = pg.FillCompasses();
        List<Chord> estructuraD = pg.FillCompasses();

        foreach (string letra in opciones){
            switch(opciones[Random.Range(0,4)]){
                // Generar una combinacion al azar
                case "A":
                    shapes.Add(estructuraA);
                    break;
                case "B":
                    shapes.Add(estructuraB);
                    break;
                case "C":
                    shapes.Add(estructuraC);
                    break;
                case "D":
                    shapes.Add(estructuraD);
                    break;
            }
        }

        // Devolver shape
        return(shapes);
    }
}