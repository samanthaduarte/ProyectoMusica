/*4/4
2 blancas               2 tiempos  
4 negras                1 tiempos    sub_cant
8 corcheas              1/2 tiempo   sub_cant * 2
16 semicorcheas         1/4 tiempo   sub_cant * 4

3/4
3 negras                1 tiempos
6 corcheas              1/2 tiempo
12 semicorcheas         1/4 tiempo

// AABB, ABAB, ABBA, AAAB, ABCD, ABCA, ABCB, ABCC

 while(agrupaciones.Sum() < subdivision_clave){
            agrupaciones.Add(randItem);
            Debug.Log(agrupaciones[agrupaciones.Sum()]);
        }
        for(int i = 0; i < subdivision_clave; i++){
            agrupaciones.Add(randItem);
            Debug.Log(agrupaciones[agrupaciones.Sum()]);
        }


public void CalculateQuality(){

        List<List<string>> acordes = new List<List<string>>();

        Console.WriteLine("Acordes: ");

        for (int i = 0; i < 7; i++) {
            List<string> acorde = new List<string>();
            acorde.Add(escala[i%7]);
            acorde.Add(escala[(i+2)%7]);
            acorde.Add(escala[(i+4)%7]);
            acordes.Add(acorde);
            i+=1;
        }

        for (int i = 0; i < acordes.Count(); i++) {
            if(i == 0 || i == 3 || i == 4){
                Console.WriteLine(acordes[i][0],"mayor:");
            }
            else if(i == 1 || i == 2 || i == 5){
                Console.WriteLine(acordes[i][0],"menor:");
            }
            else if(i == 6){
                Console.WriteLine(acordes[i][0],"disminuido:");
            }
            Console.WriteLine(acordes[i]);
        }
    }*/