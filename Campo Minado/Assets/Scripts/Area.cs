using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    bool bomba;
    bool revelado;

    [SerializeField] Sprite[] spritesVazios;

    public void Clicado()
    {
        Debug.Log("Clicado");
        if (!revelado)
        {
            if (bomba)
            {
                //GameOver
            }
            else
            {
                //GetComponent<SpriteRenderer>().sprite = spritesVazios[];
            }
        }
    }
}
