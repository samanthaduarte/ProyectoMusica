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

    private void Start() {
        btnGenerar.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        rg.StartRythm();
        rg.CalcularRelleno();

        lblMetrica.text = "Métrica: "+rg.sub_cant.ToString()+"/"+rg.sub_base.ToString();
        lblClave.text = "Clave: "+string.Join(",", rg.clave);
        lblRelleno.text = "Relleno: "+string.Join(",", rg.relleno);
    }


}