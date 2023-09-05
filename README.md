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
