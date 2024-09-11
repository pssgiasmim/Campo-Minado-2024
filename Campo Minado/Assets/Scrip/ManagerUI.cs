using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    //M�todo que altera as propriedades de uma imagem
    [SerializeField] Image barraDeDificuldade;
    [SerializeField] Gradient corDaBarra;
    [SerializeField] TextMeshProUGUI gameOverText;

    public void AtualizarBarra(float value)
    {
        //o fillAmount faz a barrinha ter uma progress�o, o qunato a barra vai ser preenchida
        barraDeDificuldade.fillAmount = value;

        //Vai fazer ter um gradiente entre cores na barra
        barraDeDificuldade.color = corDaBarra.Evaluate(value);
    }

    //M�todo que altera o valor do texto para vit�ria ou derrota.
    //Como � uma informa��o moment�nea, n�o � necess�rio criar uma vari�vel booleana, pode apenas criar um par�metro booleano
    public void AtualizarTexto(bool venceu)
    { 
        if (venceu)
        {
            gameOverText.text = "Vit�ria";

        }
        else
        {
            gameOverText.text = "Derrota";
        }
    }
}
