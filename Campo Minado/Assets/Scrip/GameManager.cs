using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    Area[,] areas; //para indicar que se trata e uma Matriz, deve-se colocar uma v�rgula no meio de chaves
    //essa matriz N�O est� declarando tamanho e nem valores, apenas indica ser uma matriz;

    [SerializeField] GameObject areaPrefab;

    int diametroDoCampo;
    int numeroDeBombas;

    ManagerUI managerUI;
    GameObject menu, gameOver;

    private void Start()
    {
        managerUI = GetComponent<ManagerUI>();
        menu = GameObject.Find("Menu Window");
        gameOver = GameObject.Find("Game Over");
    }

    public void DerfinirDiametro(string value)
    {
        diametroDoCampo = int.Parse(value);
        managerUI.AtualizarBarra((float)numeroDeBombas / (diametroDoCampo * diametroDoCampo));
    }

    public void DefinirNumeroDeBombas(string value)
    {
        numeroDeBombas = int.Parse(value);
        managerUI.AtualizarBarra((float)numeroDeBombas / (diametroDoCampo * diametroDoCampo));
    }

    public void IniciarJogo()
    {
        ExcluirCampo();

        //Organizar a camera para ficar no meio do diametro
        Camera.main.transform.position = new Vector3(diametroDoCampo / 2f - 0.5f, diametroDoCampo / 2f - 0.5f, -10);

        //Organizar a camera na altura do campo (matriz)
        Camera.main.orthographicSize = diametroDoCampo / 2f;

        DistribuirBombas();

        //Busca o objeto "Menu Window" e faz ele desligar [false]
        menu.SetActive(false);

        //Busca o objeto "Game Over" e faz ele desligar [false]
        gameOver.SetActive(false);
    }

    private void ExcluirCampo()
    {
        if (areas != null) // != siginifica diferente
        {
            foreach (Area area in areas)
            {
                Destroy(area.gameObject);
            }
        }
        
    }


    //M�todo que cria uma matriz e preenche os campos com instancias
    public void GerarCampoMinado()
    {
        //Mathf.Pow � para fazer um n�mero ficar ao quadrado 
        if (numeroDeBombas < Mathf.Pow(diametroDoCampo, 2))
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
                    area.DefinirIndex(i, j);
                    areas[i, j] = area;
                }

            }

          
        }
       

    }

    //M�todo que checa os blocos ao redor do bloco selecionado
    public int ChecarEntorno(int x, int y)
    {
        //bombas � 0. Essa var��vel � especifica deste m�todo
        int quantidadeDeBombas = 0;
         
        //verifica��o das linhas
        for (int i = -1; i < 2; i++)
        {
            //verifica��o das colunas
            for (int j = -1; j < 2; j++)
            {
                if (x+i < diametroDoCampo && y+j < diametroDoCampo && x+i >= 0 && y+j >= 0)
                {
                    //verifica��o se tem bomba na area atual que � linha + coluna [ i+j ]
                    if (areas[x + i, y + j].Bomba)
                    {
                        quantidadeDeBombas++;
                    }

                }

            }
        }

        if (quantidadeDeBombas == 0)
        {
            for (int i = -1; i < 2; i++)
            {
                //verifica��o das colunas
                for (int j = -1; j < 2; j++)
                {
                    if (x + i < diametroDoCampo && y + j < diametroDoCampo && x + i >= 0 && y + j >= 0)
                    {

                        areas[x + i, y + j].Revelar();

                    }

                }
            }

        }


        return quantidadeDeBombas;
    }

    //M�todo para distribuir bombas na cena
    void DistribuirBombas()
    {
        //iterador inica em, 0
        int quantidadeDeBombas = 0;

        //eu sei que eu preciso ter 10 bombas na cena, mas n�o sei quantas vezes � necess�rio repetir o procedimento at� chegar no 10. Isso � um WHILE
        //enquanto a quantidade de bombas for menor do que 10
        while (quantidadeDeBombas < numeroDeBombas)
        {
            //Gera dois valores aleat�rios dentros do index[endere�o]
            int[] index = new int[2];

            index[0] = Random.Range(0, diametroDoCampo);
            index[1] = Random.Range(0, diametroDoCampo);

            //verifica��o para se o index n�o tem bomba
            if (areas[index[0], index[1]].Bomba == false)
            {
                //colocar uma bomba l� no index
                areas[index[0], index[1]].Bomba = true;
                quantidadeDeBombas++;
            }
            
        }
        
    }

    //M�todo para chamar a tela de game over
    public void GameOver()
    {

        /*for (int i = 0; i < diametroDoCampo; i++)
        {
            for (int j = 0; j < diametroDoCampo; j++)
            {

                if (areas[i, j].Bomba)
                {
                    areas[i, j].RevelarBomba();
                }
            }

        }*/

        //O FOREACH percorre todos os elementos de uma matriz, substitui os dois for acima
        foreach (Area area in areas)
        {
            if(area.Bomba)
            {
                area.RevelarBomba();
               //o Break � um interrompimento for�ado do m�todo, quando certa condi��o for atendida. No nosso caso, � caso a area que ele percorreu naquele momento seja uma bomba.
            }
            

        }

        gameOver.SetActive(true);


    }
}
