using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Area[,] areas;

    [SerializeField] GameObject AreaPrefab;

    const int diametroDoCampo = 5;

    private void Start()
    {
        GerarCampoMinado();
    }

    void GerarCampoMinado()
    {
        areas = new Area[diametroDoCampo, diametroDoCampo];

        for(int i = 0; i < diametroDoCampo; i++)
        {
            for(int j = 0; j < diametroDoCampo; j++)
            {
                Area area = Instantiate(AreaPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<Area>();
                areas[i, j] = area;
            }
        }
    }
}
