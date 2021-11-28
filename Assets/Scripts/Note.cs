using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public AudioSource do0;
    public AudioSource doSos;
    public AudioSource re;
    public AudioSource reSos;
    public AudioSource mi;
    public AudioSource fa;
    public AudioSource faSos;
    public AudioSource sol;
    public AudioSource solSos;
    public AudioSource la;
    public AudioSource laSos;
    public AudioSource si;
    public AudioSource do1;

    public void PlayNote(string note)
    {
        switch(note) 
        {
            case "do":
                do0.Play();
                break;
            case "do#":
                doSos.Play();
                break;
            case "re":
                re.Play();
                break;
            case "re#":
                reSos.Play();
                break;
            case "mi":
                mi.Play();
                break;
            case "fa":
                fa.Play();
                break;
            case "fa#":
                faSos.Play();
                break;
            case "sol":
                sol.Play();
                break;
            case "sol#":
                solSos.Play();
                break;
            case "la":
                la.Play();
                break;
            case "la#":
                laSos.Play();
                break;
            case "si":
                si.Play();
                break;
            case "do1":
                do1.Play();
                break;
        }

    }
}