using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProgressionGenerator : MonoBehaviour
{
    public ScaleCalculator sc = new ScaleCalculator();
    public List<int> espacios = new List<int>();
    public int totalDuration = 0;
    public string actualStrength = "fuerte";

    public List<Chord> FillCompasses(List<Chord> acordes)
    {
        List<Chord> estructura = new List<Chord>(); // conjunto de acordes en 8 compases

        // Generar estructura de 8 compases
        //      Escoger un acorde random
        //      Si es igual a (actualStrength) agregar
        //      Si es subdominante y el anterior tambien, no agregar (repetir funcion)

        while(totalDuration < 8){
            // Escoger un acorde random
            int index = Random.Range(0,acordes.Count());

            // Recalcular si
            if(estructura.Count()>1){
                if(acordes[index].type == "subdominante" & acordes[index-1].type == "subdominante"){
                        estructura.Add(acordes[index]);
                }
            }
            else{
                // asignar duracion y agregar a estructura
                acordes[index].duration = Random.Range(0,5);
                totalDuration = totalDuration + acordes[index].duration;
                estructura.Add(acordes[index]);
            }
        }

        return(estructura);
 
    }

}
