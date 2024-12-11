# Collected Item Move to Counter on HUD by DOTween 
 

Import the DOTween library 

 	 https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676

Prepare the scene

	* Create a carvas
	* Create 1 empty gameobject > add img component > (FondoScore) representing the background of the score
	* Create 1 empty gameobject > add img component > (Score) Attach coin sprite (Score icon) representing the score icon > add text component as well
	* Create 1 empty gameobject > add img component > (BotaoPontuacao) Add button > represented by the button > add text component as well

	* Create 1 empty gameobject > add img component > (StackCoins) Attach coin sprite and present the coins > duplicate 
	* In duplicate coins, reset the scale of x, y and z and gameObject (PilhaCoedas) that is grouping the coins, disable this component 

Collected Item Move to Counter on HUD | Movimentação de item coletado para contador no HUD | DOTween

	* Nas moedas duplicas, zerar a scala do x, y e z e gameObject (PilhaMoedas) que esta agrupando as moeda, desativar esse componente 


Criar script para manipular as animações das moedas(gameobjetos)
	
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

    public void Reset()
    {
        // Loop para restaurar as posições e rotações iniciais das moedas
        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            pilhaMoedas.transform.GetChild(i).position = inicialPos[i];
            pilhaMoedas.transform.GetChild(i).rotation = inicialRot[i];
        }
    }

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
		
        }    }   }



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
                } }
 
 
 
 
  
