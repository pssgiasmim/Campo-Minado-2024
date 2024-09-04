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
    Area[,] areas; //para indicar que se trata e uma Matriz, deve-se colocar uma vírgula no meio de chaves
    //essa matriz NÃO está declarando tamanho e nem valores, apenas indica ser uma matriz;

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


    //Método que cria uma matriz e preenche os campos com instancias
    public void GerarCampoMinado()
    {
        //Mathf.Pow é para fazer um número ficar ao quadrado 
        if (numeroDeBombas < Mathf.Pow(diametroDoCampo, 2))
        {
            areas = new Area[diametroDoCampo, diametroDoCampo]; //declara o tamanho em X e Y da matriz, 25 quadradinhos na cena.

            //pecorre as linhas da matriz
            //quando você não tem acesso ao tamanho da área, mas precisa da metade dela, vc faz "Mathf.Sqrt(areas)". Que é a raíz quadrada do tamamho total, mas vc precisa ter um tamanho exato.
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

    //Método que checa os blocos ao redor do bloco selecionado
    public int ChecarEntorno(int x, int y)
    {
        //bombas é 0. Essa varíável é especifica deste método
        int quantidadeDeBombas = 0;
         
        //verificação das linhas
        for (int i = -1; i < 2; i++)
        {
            //verificação das colunas
            for (int j = -1; j < 2; j++)
            {
                if (x+i < diametroDoCampo && y+j < diametroDoCampo && x+i >= 0 && y+j >= 0)
                {
                    //verificação se tem bomba na area atual que é linha + coluna [ i+j ]
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
                //verificação das colunas
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

    //Método para distribuir bombas na cena
    void DistribuirBombas()
    {
        //iterador inica em, 0
        int quantidadeDeBombas = 0;

        //eu sei que eu preciso ter 10 bombas na cena, mas não sei quantas vezes é necessário repetir o procedimento até chegar no 10. Isso é um WHILE
        //enquanto a quantidade de bombas for menor do que 10
        while (quantidadeDeBombas < numeroDeBombas)
        {
            //Gera dois valores aleatórios dentros do index[endereço]
            int[] index = new int[2];

            index[0] = Random.Range(0, diametroDoCampo);
            index[1] = Random.Range(0, diametroDoCampo);

            //verificação para se o index não tem bomba
            if (areas[index[0], index[1]].Bomba == false)
            {
                //colocar uma bomba lá no index
                areas[index[0], index[1]].Bomba = true;
                quantidadeDeBombas++;
            }
            
        }
        
    }

    //Método para chamar a tela de game over
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
               //o Break é um interrompimento forçado do método, quando certa condição for atendida. No nosso caso, é caso a area que ele percorreu naquele momento seja uma bomba.
            }
            

        }

        gameOver.SetActive(true);


    }
}
