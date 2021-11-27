using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ScaleCalculator sc = new ScaleCalculator();
    public RythmGenerator rg = new RythmGenerator();
    public ProgressionGenerator pg = new ProgressionGenerator();
    public FormGenerator fg = new FormGenerator();
    public MelodyGenerator mg = new MelodyGenerator();
    
    public List<Chord> acordes = new List<Chord>();
    public List<Chord> estructura = new List<Chord>();
    public List<List<string>> formas = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        // Generar una escala a partir de una nota 
        //sc.CalculateScale();

        // Generar todos los acordes de la escala
        // Para cada acorde
        //      Determinar fuerza de acorde
        //      Determinar tipo de acorde
        //acordes = sc.CalculateChords();

        // Generar la clave
        rg.StartRythm();
        rg.CalcularRelleno();
    
        // Generar estructura de 8 compases
        //      Escoger un acorde random
        //      Si es igual a (actualStrength) agregar
        //      Si es subdominante y el anterior tambien, no agregar (repetir funcion)
        //estructura = pg.FillCompasses(acordes);

        // Generar 4 estructuras de 8 compases cada una
        //fg.GenerateForm();

    }

}