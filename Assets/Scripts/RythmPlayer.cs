using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmPlayer : MonoBehaviour
{
    public Button btnGenerar;
    public Text lblMetrica;
    public Text lblClave;
    public Text lblRelleno;

    public RythmGenerator rg = new RythmGenerator();

    public AudioSource bassdrum;
    public AudioSource snare;
    public AudioSource tom3;
    public AudioSource tom5;


    private void Start() {
        //btnGenerar.onClick.AddListener(TaskOnClick);
    }

    public void StartSong()
    {
        rg.StartRythm();
        rg.CalcularRelleno();

        lblMetrica.text = "Métrica: "+rg.sub_cant.ToString()+"/"+rg.sub_base.ToString();
        lblClave.text = "Clave: "+string.Join(",", rg.clave);
        lblRelleno.text = "Relleno: "+string.Join(",", rg.relleno);
        Debug.Log(string.Join(",", rg.relleno));
        

    }


}