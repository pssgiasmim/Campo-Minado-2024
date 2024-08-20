using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
    bool revelado;

    [SerializeField] Sprite[] sprite;

    //Método para se CLICAR num bloquinho, ele revelar se tem bomba ou não.
    private void Clicado()
    {
        if (!revelado) // o ponto de ! faz a inversão de valores do "revelado". Se ele está verdadeiro vira falso.
        {
            if (bomba)
            {
                //game over
            }
            else
            {               // sempre que for pegar um itenm do GetComponent, ele deve estar no meio do sinal de  < e >.
                //GetComponent<SpriteRenderer>().sprite =
            }
        }

    }


}
