# collected-coin-anim-dotween
Collected Item Move to Counter on HUD by DOTween

Collected Item Move to Counter on HUD | Movimentação de item coletado para contador no HUD | DOTween


1°) Importar a biblioteca DOTween

2°) Preparar o cenario

	* Criar um carvas
	* Criar 1 gameobjeto vazio > adicionar componente img > (FundoPontuacao) representado o plano de fundo da pontuacao
	* Criar 1 gameobjeto vazio > adicionar componente img > (Pontuacao) Anexar sprite da moeda (iconePontuacao) represetando o icone da pontuação > add component texto tambem
	* Criar 1 gameobjeto vazio > adicionar componente img > (BotaoPontuacao) Adicionar button > representado o botao > add component texto tambem	
	
	* Criar 1 gameobjeto vazio > adicionar componente img > (PilhaMoedas) Anexar sprite da moeda epresetando as moedas > duplicar 6 
	* Nas moedas duplicas, zerar a scala do x, y e z e gameObject (PilhaMoedas) que esta agrupando as moeda, desativar esse componente 


3°) Criar script para manipular as animações das moedas(gameobjetos)
	
	using TMPro;
	using UnityEngine;
	using DG.Tweening;


     public class AniCoin: MonoBehaviour
     {

    [SerializeField] private GameObject pilhaMoedas; // Referência ao objeto contendo as moedas empilhadas
    [SerializeField] private TextMeshProUGUI pontuacao; // Referência ao componente de texto para exibir a pontuação
    [SerializeField] private Vector3[] inicialPos; // Armazena as posições iniciais das moedas
    [SerializeField] private Quaternion[] inicialRot; // Armazena as rotações iniciais das moedas
    [SerializeField] private int moedasColetaveis; // Quantidade de moedas coletáveis

    public void Start()
    {
        // Inicialização das posições e rotações iniciais das moedas
        inicialPos = new Vector3[moedasColetaveis];
        inicialRot = new Quaternion[moedasColetaveis];

        // Loop para armazenar as posições e rotações iniciais de cada moeda
        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            inicialPos[i] = pilhaMoedas.transform.GetChild(i).position;
            inicialRot[i] = pilhaMoedas.transform.GetChild(i).rotation;
        }
    }

resetar 

    public void Reset()
    {
        // Loop para restaurar as posições e rotações iniciais das moedas
        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            pilhaMoedas.transform.GetChild(i).position = inicialPos[i];
            pilhaMoedas.transform.GetChild(i).rotation = inicialRot[i];
        }
    }

recomeçar 

    public void Recompensa(int moedasColetaveis)
    {
        Reset(); // Restaura as posições e rotações iniciais das moedas

        var delay = 0f; // Inicializa o atraso para a animação das moedas

        pilhaMoedas.SetActive(true); // Ativa o objeto contendo as moedas empilhadas

        // Loop para animar cada moeda individualmente
        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            // Animação de escala da moeda
            pilhaMoedas.transform.GetChild(i).DOScale(endValue: 1f, duration: 0.3f)
                .SetDelay(delay).SetEase(Ease.OutBack);

            // Animação de posição usando ancoragem
            pilhaMoedas.transform.GetChild(i).GetComponent<RectTransform>()
                .DOAnchorPos(endValue: new Vector2(x: 305f, y: 603f), duration: 1f)
                .SetDelay(delay + 0.5f).SetEase(Ease.OutBack);

            // Outra animação de escala da moeda
            pilhaMoedas.transform.GetChild(i).DOScale(endValue: 1f, duration: 0.3f)
                .SetDelay(delay + 1f).SetEase(Ease.OutBack);

            delay += 0.2f; // Incrementa o atraso para a próxima moeda
	
	    StartCoroutine(routine: ContadorMoedas(moedasColetaveis: 7));
		
        }
    }	}

contar 

    IEnumerator ContadorMoedas(int moedasColetaveis)
    {
        yield return new WaitForSecondsRealtime(time: 1f);

        var timer = 0f;

        for (int i = 0; i < moedasColetaveis; i++)
        {
            PlayerPrefs.SetInt("moeda", PlayerPrefs.GetInt(key: "moeda") + moedasColetaveis);

            pontuacao.text = PlayerPrefs.GetInt(key: "moeda").ToString();

            timer += 0.1f;

            yield return new WaitForSecondsRealtime(timer);
        }
    }
