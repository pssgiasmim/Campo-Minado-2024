using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    //Método que altera as propriedades de uma imagem
    [SerializeField] Image barraDeDificuldade;
    [SerializeField] Gradient corDaBarra;
    [SerializeField] TextMeshProUGUI gameOverText;

    public void AtualizarBarra(float value)
    {
        //o fillAmount faz a barrinha ter uma progressão, o qunato a barra vai ser preenchida
        barraDeDificuldade.fillAmount = value;

        //Vai fazer ter um gradiente entre cores na barra
        barraDeDificuldade.color = corDaBarra.Evaluate(value);
    }

    //Método que altera o valor do texto para vitória ou derrota.
    //Como é uma informação momentânea, não é necessário criar uma variável booleana, pode apenas criar um parâmetro booleano
    public void AtualizarTexto(bool venceu)
    { 
        if (venceu)
        {
            gameOverText.text = "Vitória";

        }
        else
        {
            gameOverText.text = "Derrota";
        }
    }
}
