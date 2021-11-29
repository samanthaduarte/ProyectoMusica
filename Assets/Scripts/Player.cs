using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ScaleCalculator sc = new ScaleCalculator();
    public ProgressionGenerator pg = new ProgressionGenerator();
    public ShapeGenerator sg = new ShapeGenerator();
    public RythmPlayer rp = new RythmPlayer();
    
    public List<Chord> acordesEscala = new List<Chord>();

    public Button btnGenerar;
    public Text lblNota;

    List<List<Chord>> song = new List<List<Chord>>();

    // Start is called before the first frame update
    void Start()
    {
        btnGenerar.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Generar clave, ritmo y relleno
        rp.StartSong();

        // Calcular la escala de una nota
        sc.CalculateScale();
        lblNota.text = "Nota: "+sc.notaInput.ToString();

        // Calcular todos los acordes de la escala
        acordesEscala = sc.CalculateChords();

        // Generar 4 estructuras de 8 compases cada una
        pg.acordes = acordesEscala; // pasar acordes generados de la escala al generador de formas
        song = sg.GenerateShape();

    }

    // Toma los acordes de la forma y los reproduce
    public void PlayChords(){

    }
    public void PlayMelody(){

    }

}