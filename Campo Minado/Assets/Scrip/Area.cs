using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
    public bool revelado, bandeira;

    int indexI, indexJ;


    [SerializeField] Sprite[] spritesVazios;

    [SerializeField] Sprite bombaSprite;
    [SerializeField] Sprite bandeiraSprite;
    [SerializeField] Sprite spriteOriginal;

    public bool Bomba { get => bomba; set => bomba = value; }

    //armazena a "localiza��o" dos bloquinhos na �rea. � um indice que come�a a apartir de 0
    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }

    public void Clicado()
    {
        if (GameManager.instance.bandeira)
        {
            TransformarBandeira();
        }
        else
        {
            Revelar();
        }
    }

    void TransformarBandeira()
    {
        //altera a sprite  para uma bandeira se o bloco ainda n�o foi revelado
        if (!bandeira)
        {
            bandeira = true;
            GetComponent<SpriteRenderer>().sprite = bandeiraSprite;
        }
        else
        {
            bandeira = false;
            GetComponent<SpriteRenderer>().sprite = spriteOriginal;
        }
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
                //chama o checar vit�ria
                GameManager.instance.ChecarVitoria();
            }
        }

    }

    public void RevelarBomba()
    {
        revelado = true;
        GetComponent<SpriteRenderer>().sprite = bombaSprite;

    }
}
