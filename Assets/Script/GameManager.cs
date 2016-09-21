using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Neste estado, os valores esperados sao: 0 = Selecao de peca, 1 = animacao de peca, 2 = Player2
	public int gameState = 0;			
	// 0 = Player1, 1 = Player2
	//private int PlayerAtivo = 0;		
	// Peca selecionada
	private GameObject pecaSelecionada;	
	private Material materialBranco;
	private Material materialPreto;
	private Material materialSelecionado;

	void Start () 
	{
		//Debug.Log ("");

		//materialBranco = GameObject.FindWithTag ("PiecePlayer1").GetComponent<Renderer> ().material;
		//materialPreto = GameObject.FindWithTag ("PiecePlayer2").GetComponent<Renderer> ().material;
		materialBranco = GameObject.FindWithTag ("PiecePlayer1").transform.GetChild(0).GetComponent<Renderer> ().material;
		materialPreto = GameObject.FindWithTag ("PiecePlayer2").transform.GetChild(0).GetComponent<Renderer> ().material;
		materialSelecionado = new Material (materialPreto.shader);
		materialSelecionado.color = Color.red;
	}

	//Atualiza SlectedPiece com o input do GameObject para essa funcao
	public void SelectPiece(GameObject _PieceToSelect)
	{ 	
		// Muda a cor da peca seleciona para destacar. Muda a cor anterior quando a peca sai da selecao
		if(pecaSelecionada)
		{
			if (string.Equals(pecaSelecionada.tag,"PiecePlayer1")) {
				pecaSelecionada.transform.GetChild(0).GetComponent<Renderer> ().material = materialBranco;
			} else if (string.Equals(pecaSelecionada.tag,"PiecePlayer2")) {
				pecaSelecionada.transform.GetChild(0).GetComponent<Renderer> ().material = materialPreto;
			}
		}
		pecaSelecionada = _PieceToSelect;
		pecaSelecionada.transform.GetChild(0).GetComponent<Renderer>().material = materialSelecionado;
		//Debug.Log (pecaSelecionada.name);
	}

	// Move pecaSelecionada para a cordenada do input
	public void MovePiece(Vector2 _coordToMove)
	{	
		// Move a peca
		pecaSelecionada.transform.position = _coordToMove;		
		// Muda para o material anterior
		if (string.Equals(pecaSelecionada.tag,"PiecePlayer1")) {
			pecaSelecionada.transform.GetChild(0).GetComponent<Renderer> ().material = materialBranco;
		} else if (string.Equals(pecaSelecionada.tag,"PiecePlayer2")) {
			pecaSelecionada.transform.GetChild(0).GetComponent<Renderer> ().material = materialPreto;
		}
		// Tira a selecao da peca
		pecaSelecionada = null;									
	}

	// Muda o estado do jogo
	public void ChangeState(int _newState)
	{
		gameState = _newState;
	}
}