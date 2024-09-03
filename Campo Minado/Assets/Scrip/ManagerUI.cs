using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] Image barraDeDificuldade;
    [SerializeField] Gradient corDaBarra;

    public void AtualizarBarra(float value)
    {
        barraDeDificuldade.fillAmount = value;
        barraDeDificuldade.color = corDaBarra.Evaluate(value);
    }
}
