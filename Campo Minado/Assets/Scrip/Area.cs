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

    //armazena a "localização" dos bloquinhos na área. é um indice que começa a apartir de 0
    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }


    //Método para se clicar num bloquinho, ele REVELAR se tem bomba ou não.
    //O método também vê se o botão modo bandeira está ativado ou não
    public void Revelar()
    {
        //o ! só pode ser usado em variáveis booleanas.
        if (!revelado && GameManager.instance.bandeira == false) // o ponto de ! faz a inversão de valores do "revelado". Se ele está verdadeiro vira falso.
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
        //altera a sprite  para uma bandeira se o bloco ainda não foi revelado
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
