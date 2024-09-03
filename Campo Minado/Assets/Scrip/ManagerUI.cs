using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    //M�todo que altera as propriedades de uma imagem
    [SerializeField] Image barraDeDificuldade;
    [SerializeField] Gradient corDaBarra;

    public void AtualizarBarra(float value)
    {
        //o fillAmount faz a barrinha ter uma progress�o, o qunato a barra vai ser preenchida
        barraDeDificuldade.fillAmount = value;

        //Vai fazer ter um gradiente entre cores na barra
        barraDeDificuldade.color = corDaBarra.Evaluate(value);
    }
}
