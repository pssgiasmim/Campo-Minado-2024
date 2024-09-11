using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
     public bool revelado;

    int indexI, indexJ;


    [SerializeField] Sprite[] spritesVazios;

    [SerializeField] Sprite bombaSprite;
    [SerializeField] Sprite bandeira;
    public bool Bomba { get => bomba; set => bomba = value; }

    //armazena a "localiza��o" dos bloquinhos na �rea. � um indice que come�a a apartir de 0
    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }


    //M�todo para se clicar num bloquinho, ele REVELAR se tem bomba ou n�o.
    //O m�todo tamb�m v� se o bot�o modo bandeira est� ativado ou n�o
    public void Revelar()
    {
        //o ! s� pode ser usado em vari�veis booleanas.
        if (!revelado && GameManager.instance.bandeira == false) // o ponto de ! faz a invers�o de valores do "revelado". Se ele est� verdadeiro vira falso.
        {
            if (bomba)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                revelado = true;

                // sempre que for pegar um iten do GetComponent, ele deve estar no meio do sinal de  < e >.
                GetComponent<SpriteRenderer>().sprite = spritesVazios[GameManager.instance.ChecarEntorno(indexI, indexJ)];

            }
        }
        //altera a sprite  para uma bandeira se o bloco ainda n�o foi revelado
        else if (!revelado && GameManager.instance.bandeira)
        {
            revelado = true;
            GetComponent<SpriteRenderer>().sprite = bandeira;
        }

        
    }

    public void RevelarBomba()
    {
        revelado = true;
        GetComponent<SpriteRenderer>().sprite = bombaSprite;

    }
}
