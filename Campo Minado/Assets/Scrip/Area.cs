using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
    bool revelado;

    [SerializeField] Sprite[] sprite;

    //M�todo para se CLICAR num bloquinho, ele revelar se tem bomba ou n�o.
    private void Clicado()
    {
        if (!revelado) // o ponto de ! faz a invers�o de valores do "revelado". Se ele est� verdadeiro vira falso.
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
