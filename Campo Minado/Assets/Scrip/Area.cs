using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{

    bool bomba;
    bool revelado;

    int indexI, indexJ;


    [SerializeField] Sprite[] spritesVazios;

    [SerializeField] Sprite bombaSprite;
    [SerializeField] Sprite bandeira;
    public bool Bomba { get => bomba; set => bomba = value; }

    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }


    //Método para se clicar num bloquinho, ele REVELAR se tem bomba ou não.
    public void Revelar()
    {
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

        
    }

    public void RevelarBomba()
    {
        revelado = true;
        GetComponent<SpriteRenderer>().sprite = bombaSprite;

    }

    //Método para dar a opção de ativar o modo bandeira [bloqueia o bloco e muda a sprite]
    public void BloqueioArea()
    {
        if (GameManager.instance.bandeira == true)
        {
           
            
                revelado = true;
                GetComponent<SpriteRenderer>().sprite = bandeira;
            
            
        }
    }
  
    
}
