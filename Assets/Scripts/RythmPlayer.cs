using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmPlayer : MonoBehaviour
{
    public Slider bpmSlider;
    public Text bpmTxt;

    public Button btnGenerar;
    public Text lblMetrica;
    public Text lblClave;
    public Text lblRelleno;

    public RythmGenerator rg = new RythmGenerator();

    public AudioSource mainBeat;
    public AudioSource mainBeat2;
    public AudioSource halfBeat;
    public double tiempoEntreBeats; 
    public double tiempoCorcheas; 
    public double tiempoSemicorcheas; 
    public double BPM; 
    public int Counter;
    public int setTheTime = 1000;
    public int metrica;


    private void Update() 
    {
        BPM = bpmSlider.value;
        tiempoEntreBeats = 60.0f / BPM;
        tiempoCorcheas = tiempoEntreBeats/2;
        tiempoSemicorcheas = tiempoEntreBeats/4;
        bpmTxt.text = ((int)BPM).ToString();

    }
    public void StartSong(){


        lblMetrica.text = "Métrica: "+rg.sub_cant.ToString()+"/"+rg.sub_base.ToString();
        lblClave.text = "Clave: "+string.Join(",", rg.clave);
        lblRelleno.text = "Relleno: "+string.Join(",", rg.relleno);
        Debug.Log(string.Join(",", rg.relleno));

        metrica = rg.sub_cant;

        bpmSlider.minValue = 30;
        bpmSlider.maxValue = 244;

        bpmSlider.value = 120;

        StartCoroutine(secondRoutine());

    }
    
    IEnumerator secondRoutine()
    {
        while (Time.time < setTheTime){
            Counter++;
            mainBeat.Play();
            Debug.Log("main beat");
            yield return new WaitForSecondsRealtime((float)tiempoEntreBeats); 
        }
    }
}

