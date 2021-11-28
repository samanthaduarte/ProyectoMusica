using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool startSong;
    public ScaleCalculator sc = new ScaleCalculator();
    public ProgressionGenerator pg = new ProgressionGenerator();
    public ShapeGenerator sg = new ShapeGenerator();
    public MelodyGenerator mg = new MelodyGenerator();
    public RythmPlayer rp = new RythmPlayer();
    
    public List<Chord> acordesEscala = new List<Chord>();
    public List<Chord> estructura = new List<Chord>();
    public List<List<string>> formas = new List<List<string>>();

    public Button btnGenerar;
    public Text lblNota;

    public Note note = new Note();

    // Start is called before the first frame update
    void Start()
    {
        btnGenerar.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        rp.StartSong();
       

        // Generar una escala a partir de una nota 
        sc.CalculateScale();
        lblNota.text = "Nota: "+sc.notaInput.ToString();
        acordesEscala = sc.CalculateChords();


        // Generar todos los acordes de la escala
        // Para cada acorde
        //      Determinar fuerza de acorde
        //      Determinar tipo de acorde
        //acordes = sc.CalculateChords();
    
        // Generar estructura de 8 compases
        //      Escoger un acorde random
        //      Si es igual a (actualStrength) agregar
        //      Si es subdominante y el anterior tambien, no agregar (repetir funcion)
        pg.acordes = acordesEscala;

        // Generar 4 estructuras de 8 compases cada una
        //sg.GenerateForm();

    }

    public void PlayChords(){

    }
    public void PlayMelody(){

    }

}