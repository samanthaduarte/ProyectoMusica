using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{

    public Button btnComenzar;
    public Slider bpmSlider;
    public Text bpmTxt;

    public AudioSource sonido1;
    public AudioSource sonido2;
    public AudioSource sonido3;
    public double tiempoEntreBeats; 
    public double tiempoCorcheas; 
    public double tiempoSemicorcheas; 
    public double BPM; 
    public int Counter;
    public int setTheTime = 1000;
    public int metrica;

    public RythmGenerator rg = new RythmGenerator();

    private void Update() 
    {
        BPM = bpmSlider.value;
        tiempoEntreBeats = 60.0f / BPM;
        tiempoCorcheas = tiempoEntreBeats/2;
        tiempoSemicorcheas = tiempoEntreBeats/4;
        bpmTxt.text = ((int)BPM).ToString();

    }
    public void StartSong(){
        metrica = rg.sub_cant;

        btnComenzar.onClick.AddListener(TaskOnClick);

        bpmSlider.minValue = 30;
        bpmSlider.maxValue = 244;

        bpmSlider.value = 120;
    }
    
    void TaskOnClick()
    {
        StartCoroutine(secondRoutine());
    }

    IEnumerator secondRoutine()
    {
        metrica = rg.sub_cant;
        while (Time.time < setTheTime) 
        {
            Counter++;
            if (Counter % metrica == 1)             
            {
                sonido1.Play();
                Debug.Log("toc");
            }
            else
            {
                sonido2.Play();
                Debug.Log("tic");
            }

            if(rg.opciones_clave[rg.index] == 2){ // corcheas
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
                sonido3.Play();
                Debug.Log("corchea");
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
            }
            else if(rg.opciones_clave[rg.index] == 4){ // semicorcheas
                yield return new WaitForSecondsRealtime((float)tiempoSemicorcheas); 
                sonido3.Play();
                Debug.Log("semicorchea");
                yield return new WaitForSecondsRealtime((float)tiempoSemicorcheas); 
            }
            else{ // negras
                yield return new WaitForSecondsRealtime((float)tiempoEntreBeats); 
                Debug.Log("negra");
            }
            
            
        }
    }
}

