using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
    bool revelado;

    int indexI, indexJ;

    [SerializeField] Sprite[] spritesVazios;

    public bool Bomba { get => bomba; }

    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }

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
            {

                // sempre que for pegar um iten do GetComponent, ele deve estar no meio do sinal de  < e >.
                GetComponent<SpriteRenderer>().sprite = spritesVazios[GameManager.instance.ChecarEntorno(indexI, indexJ)];
            }
        }

    }


}
