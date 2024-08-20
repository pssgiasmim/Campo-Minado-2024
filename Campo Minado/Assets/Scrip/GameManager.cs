using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    Area[,] areas; //para indicar que se trata e uma Matriz, deve-se colocar uma v�rgula no meio de chaves
    //essa matriz N�O est� declarando tamanho e nem valores, apenas indica ser uma matriz;

    [SerializeField ]GameObject areaPrefab;

    const int diametroDoCampo = 5;

    private void Start()
    {
        GerarCampoMinado();
    }

    //M�todo que cria uma matriz e preenche os campos com instancias
    private void GerarCampoMinado()
    {
        areas = new Area[diametroDoCampo, diametroDoCampo]; //declara o tamanho em X e Y da matriz, 25 quadradinhos na cena.

        //pecorre as linhas da matriz
        //quando voc� n�o tem acesso ao tamanho da �rea, mas precisa da metade dela, vc faz "Mathf.Sqrt(areas)". Que � a ra�z quadrada do tamamho total, mas vc precisa ter um tamanho exato.
        for (int i = 0; i < diametroDoCampo; i++)
        {
            //percorre as colunas da matriz
            for (int j = 0; j < diametroDoCampo; j++)
            {
                Area area = Instantiate(areaPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<Area>();
                areas[i, i] = area;
            }
      
        }

    }

    public void ChecarEntorno(int i, int j)
    {

    }
}
