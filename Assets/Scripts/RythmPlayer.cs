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

    public AudioSource sonido;
    public AudioSource sonido2;
    public AudioSource sonidoCorchea;
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
        rg.StartRythm();
        rg.CalcularRelleno();

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
        while (Time.time < setTheTime) 
        {
            Counter++;
            if (Counter % metrica == 1)             
            {
                sonido.Play();
                Debug.Log("primer negra");
            }
            else{
                sonido.Play();
                Debug.Log("negra");
            }

            if(rg.opciones_clave[rg.index] == 2){ // corcheas
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
                sonidoCorchea.Play();
                Debug.Log("corchea");
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
            }
            else if(rg.opciones_clave[rg.index] == 4){ // semicorcheas
                yield return new WaitForSecondsRealtime((float)tiempoSemicorcheas); 
                sonidoCorchea.Play();
                Debug.Log("semicorchea");
                yield return new WaitForSecondsRealtime((float)tiempoSemicorcheas); 
            }
            else{ 
                yield return new WaitForSecondsRealtime((float)tiempoEntreBeats); 
            }
            
            
        }
    }
}

