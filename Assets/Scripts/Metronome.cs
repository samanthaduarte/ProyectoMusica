using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class script : MonoBehaviour
{
    public Canvas canvas;

    public Button btnComenzar;
    public Slider bpmSlider;
    public Slider metSlider;
    public Toggle corToggle;
    public Text bpmTxt;
    public Text metTxt;

    public AudioSource sonido1;
    public AudioSource sonido2;
    public AudioSource sonido3;
    public double tiempoEntreBeats; 
    public double tiempoCorcheas; 
    public double BPM; 
    public int Counter;
    public int setTheTime = 1000;
    public int metrica;

    public void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("canv").GetComponent<Canvas>();
        btnComenzar = canvas.transform.GetChild(0).GetComponent<Button>();
        metSlider = canvas.transform.GetChild(1).GetComponent<Slider>();
        bpmSlider = canvas.transform.GetChild(2).GetComponent<Slider>();
        corToggle = canvas.transform.GetChild(3).GetComponent<Toggle>();

        bpmTxt = bpmSlider.transform.GetChild(4).GetComponent<Text>();
        metTxt = metSlider.transform.GetChild(4).GetComponent<Text>();

        sonido1 = GameObject.FindGameObjectWithTag("click1").GetComponent<AudioSource>();
        sonido2 = GameObject.FindGameObjectWithTag("click2").GetComponent<AudioSource>();
        sonido3 = GameObject.FindGameObjectWithTag("click3").GetComponent<AudioSource>();

        btnComenzar.onClick.AddListener(TaskOnClick);
        metSlider.minValue = 2;
        metSlider.maxValue = 7;
        bpmSlider.minValue = 30;
        bpmSlider.maxValue = 244;
        corToggle.isOn = false;

        metSlider.value = 4;
        bpmSlider.value = 120;
        
    }

    private void Update() 
    {
        metrica = (int)metSlider.value;
        BPM = bpmSlider.value;
        tiempoEntreBeats = 60.0f / BPM;
        tiempoCorcheas = tiempoEntreBeats/2;
        bpmTxt.text = ((int)BPM).ToString();
        metTxt.text = metrica.ToString();
    }
    
    void TaskOnClick()
    {
        StartCoroutine(secondRoutine());
    }

    IEnumerator secondRoutine()
    {
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

            if(corToggle.isOn == true){
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
                sonido3.Play();
                Debug.Log("corchea");
                yield return new WaitForSecondsRealtime((float)tiempoCorcheas); 
            }
            else{
                yield return new WaitForSecondsRealtime((float)tiempoEntreBeats); 
            }
            
            
        }
    }
}

