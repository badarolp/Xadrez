using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	// Camera usada pelo jogador
	private Camera PlayerCam;			
	// GameObject responsavel pelo gerenciamento do game
	private GameManager GameManager; 	

	// Inicializacao
	void Start () 
	{
		// Acha o GameObject da Camera pela tag
		PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		GameManager = gameObject.GetComponent<GameManager>();
	}

	// Update eh chamado uma vez por frame
	void Update () {
		// Procura por inputs do mouse
		GetMouseInputs();		
	}

	// Detecta mouse inputs
	void GetMouseInputs()
	{	
		Ray _ray;
		RaycastHit _hitInfo;
		// Seleciona um pedaco se o gameState eh 0 ou 1
		if(GameManager.gameState < 2)
		{
			// On Left Click
			if(Input.GetMouseButtonDown(0))
			{
				// Especifica o ray para ser classificado da posicao do mouse click
				_ray = PlayerCam.ScreenPointToRay(Input.mousePosition); 
				// Raycast e verifica se eh uma colisao
				if(Physics.Raycast (_ray,out _hitInfo))
				{	
					// Seleciona o pedaco se tiver uma Tag
					if(_hitInfo.collider.gameObject.tag == ("PiecePlayer1") || _hitInfo.collider.gameObject.tag == ("PiecePlayer2"))
					{
						GameManager.SelectPiece(_hitInfo.collider.gameObject);
						GameManager.ChangeState (1);
					}
				}
			}
		}

		// Move a peca se o gameState eh 1
		if(GameManager.gameState == 1)
		{
			Vector2 selectedCoord;
			// Com click esquerdo
			if(Input.GetMouseButtonDown(0))
			{
				// Especifica o ray para ser classificado da posicao do mouse click
				_ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
				// Raycast and e verifica se eh uma colisao
				if(Physics.Raycast (_ray,out _hitInfo))
				{
					// Seleciona a peca se tiver uma Tag
					if(_hitInfo.collider.gameObject.tag == ("Cube"))
					{
						selectedCoord = new Vector2(_hitInfo.collider.gameObject.transform.position.x,_hitInfo.collider.gameObject.transform.position.y);
						GameManager.MovePiece(selectedCoord);
						GameManager.ChangeState (0);
					}
				}
			}	
		}
	}
}