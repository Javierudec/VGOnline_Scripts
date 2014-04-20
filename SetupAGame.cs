using UnityEngine;
using System.Collections;
using System.IO;
using System;

public enum Choose
{
	ROCK,
	PAPER,
	SCISSOR,
	NONE
};

public class SetupAGame : MonoBehaviour {
	string nextLevel = "Battlefield";

	Texture2D settingsBackground;
	Texture2D avatar;
	Texture2D enemyAvatar;
	Texture2D versus;
	float _x;
	float _y;
	float _xAvatar;
	float _yAvatar;
	float _xEnemyAvatar;
	float _yEnemyAvatar;
	float _xVersus;
	float _yVersus;
	GUIStyle font;
	bool bPlayerReady = false;
	bool bEnemyReady  = false;
	public PopupList decklist = null;
	Texture2D readyState;
	Texture2D notReadyState;
	bool bPlayingPaperGame = false;
	Texture2D paper;
	Texture2D scissor;
	Texture2D rock;
	Texture2D enemyChoose;
	Texture2D firstTurnIdle;
	Texture2D firstTurnOver;
	Texture2D secondTurnIdle;
	Texture2D secondTurnOver;
	float xPaper;
	float yPaper;
	float xScissor;
	float yScissor;
	float xRock;
	float yRock;
	float _w;
	float _h;
	bool bSelectingCard = false;
	bool bSelectedCCard = false;
	Choose _Choose = Choose.NONE;
	Choose _EnemyChoose = Choose.NONE;
	float deltaX = 0;
	float deltaY = 0;
	float middleX = 0;
	float middleY = 0;
	float enemyMiddleY = 0;
	float enemyX = 0;
	float enemyY = 0;
	float speed = 260;
	float enemyDeltaY = 0;
	bool bChoosingWinner = false;
	float endGameDelay = 0;
	bool bCanSelect = false;
	bool bSelectingPlayerOrder = false;
	Texture2D firstTurnTexture;
	Texture2D secondTurnTexture;
	float xFirstTurn;
	float yFirstTurn;
	float xSecondTurn;
	float ySecondTurn;
	float wTurn;
	float hTurn;
	bool bPlayerConnected = false;

	Timer AITimerStartGame;
	bool bAIStartGame = false;

	private void LoadResources()
	{
		settingsBackground = Resources.Load ("SetupAGame_Background") as Texture2D;
		avatar             = Resources.Load ("DefaultAvatar")         as Texture2D;
		enemyAvatar        = Resources.Load ("DefaultAvatar")         as Texture2D;
		versus             = Resources.Load ("Versus")                as Texture2D;
		readyState         = Resources.Load ("ReadyState")            as Texture2D;
		notReadyState      = Resources.Load ("NotReadyState")         as Texture2D;
		paper              = Resources.Load ("Paper")                 as Texture2D;
		scissor            = Resources.Load ("Scissors")              as Texture2D;
		rock               = Resources.Load ("Rock")                  as Texture2D;
		enemyChoose        = Resources.Load ("FaceDownCard")          as Texture2D;
		firstTurnIdle      = Resources.Load ("FirstTurn_Idle")        as Texture2D;
		firstTurnOver      = Resources.Load ("FirstTurn_Over")        as Texture2D;
		secondTurnIdle     = Resources.Load ("SecondTurn_Idle")       as Texture2D;
		secondTurnOver     = Resources.Load ("SecondTurn_Over")       as Texture2D;

		firstTurnTexture  = firstTurnIdle;
		secondTurnTexture = secondTurnIdle;
	}

	private void SettingPositions()
	{
		wTurn = firstTurnIdle.width;
		hTurn = firstTurnIdle.height;
		
		xFirstTurn = xSecondTurn = Screen.width / 2 - firstTurnIdle.width / 2;
		yFirstTurn = Screen.height / 3 - firstTurnIdle.height / 2;
		
		ySecondTurn = Screen.height * 2 / 3 - firstTurnIdle.height / 2;

		_w = rock.width * 0.4f;
		_h = rock.height * 0.4f;
		
		middleX = Screen.width / 2 - _w / 2;
		middleY = Screen.height * 2 / 3 - _h / 2;
		
		xPaper   = Screen.width / 4 - (_w / 2);
		xScissor = Screen.width * 2 / 4 - (_w / 2);
		xRock    = Screen.width * 3 / 4 - (_w / 2);
		yPaper   = yScissor = yRock = Screen.height / 2 - _h / 2;
		
		enemyMiddleY = Screen.height / 3 - _h / 2;
		enemyX       = middleX;
		enemyY       = -_h;
		
		_x = 0;
		_y = Screen.height / 2 - settingsBackground.height / 2;

		_xAvatar = Screen.width / 3 - 64;
		_yAvatar = 30;

		_xEnemyAvatar = Screen.width * 2 / 3 - 64;
		_yEnemyAvatar = 30;

		_xVersus = _xAvatar + (_xEnemyAvatar - _xAvatar) / 2 - versus.width / 2 + 64;
		_yVersus = _y + settingsBackground.height / 4;
	}

	private void SetGameAgainstIA()
	{
		SetPlayerDeckList();

		PlayerVariables.enemyAI          = new AichiTD01();
		PlayerVariables.enemyName        = PlayerVariables.enemyAI.GetName();
		PlayerVariables.bPlayerConnected = true;

		bPlayerReady = false;
		bEnemyReady  = true;
	}

	private void SetPlayerDeckList()
	{
		string[] deckNames = Directory.GetFiles("Deck");
		
		bool bAddDummy = false;
		int len = deckNames.Length;
		if(len == 0) 
		{
			bAddDummy = true;
			len++;
		}
		
		decklist = new PopupList((int)(_xAvatar + 128 - 100), (int)(_y + settingsBackground.height - 50), 200, 20, 8);
		for(int i = 0; i < deckNames.Length; i++)
		{
			decklist.Add(deckNames[i].Substring(5, deckNames[i].Length - 5 - 4));
		}
		
		if(bAddDummy)
		{
			decklist.Add("No deck");	
		}
		
		string defaultDeck = PlayerPrefs.GetString("DefaultDeck");
		
		if(defaultDeck != "")
		{
			decklist.SelectOptionWithValue(defaultDeck);
		}	
	}

	void Start ()
	{
		LoadResources();

		SettingPositions();

		font = new GUIStyle();
		font.fontSize = 15;
		font.normal.textColor = Color.white;

		if(PlayerVariables.bPlayingAgainstIA)
		{
			SetGameAgainstIA();
		}
		else
		{
			SetPlayerDeckList();

			PlayerVariables.enemyName = "";
			bPlayerReady = false;

			if(!PlayerVariables.bHost && !PlayerVariables.bPlayingOnServer)
			{
				OnConnectedToServer();
			}
		}

		bAIStartGame = false;
		AITimerStartGame = new Timer();
	}
	
	void Update () {
		if(PlayerVariables.bPlayingAgainstIA
		   && bAIStartGame
		   && AITimerStartGame.GetMiliseconds() >= 1)
		{
			bAIStartGame = false;
			AITimerStartGame.Stop();
			Application.LoadLevel(nextLevel);
		}

		AITimerStartGame.Update();

		if(bEnemyReady && bPlayerReady && !bChoosingWinner && !bSelectingPlayerOrder)
		{
			if(!bPlayingPaperGame)
			{
				bPlayingPaperGame = true;
				bSelectingCard = true;
			}
		}
		
		if(bSelectingPlayerOrder)
		{
			if(bCanSelect)
			{
				if(MouseOn(xFirstTurn, yFirstTurn, wTurn, hTurn, Input.mousePosition))
				{
					if(firstTurnTexture != firstTurnOver)
					{
						firstTurnTexture = firstTurnOver;
						SelectFirst();
					}
					
					if(Input.GetMouseButtonUp(0))
					{
						StartGame(true);
						//MultiplayerScript.DeckName = PlayerPrefs.GetString("DefaultDeck");
						Application.LoadLevel(nextLevel);
					}
				}
				else 
				{
					if(firstTurnTexture != firstTurnIdle)
					{
						firstTurnTexture = firstTurnIdle;
					}
				}
				
				if(MouseOn(xSecondTurn, ySecondTurn, wTurn, hTurn, Input.mousePosition))
				{
					if(secondTurnIdle != secondTurnOver)
					{
						secondTurnTexture = secondTurnOver;
						SelectSecond();
					}
					
					if(Input.GetMouseButtonUp(0))
					{
						StartGame(false);
						//MultiplayerScript.DeckName = PlayerPrefs.GetString("DefaultDeck");
						Application.LoadLevel(nextLevel);
					}
				}
				else 
				{
					secondTurnTexture = secondTurnIdle;	
				}
			}
			else
			{
				if(PlayerVariables.bPlayingAgainstIA)
				{
					if(PlayerVariables.enemyAI.ChooseFirstTurn())
					{
						SelectFirstRPC();
						PlayerVariables.bFirstTurn = false;
					}
					else
					{
						SelectSecondRPC();
						PlayerVariables.bFirstTurn = true;
					}

					if(!bAIStartGame)
					{
						AITimerStartGame.Start();
						bAIStartGame = true;
					}
				}
			}
			
			return;
		}
		
		if(bChoosingWinner)
		{
			endGameDelay -= Time.deltaTime;
			
			if(endGameDelay <= 0)
			{
				bPlayingPaperGame = false;
				if(_Choose == _EnemyChoose)
				{
					deltaX = deltaY = enemyY = 0;
					_Choose = _EnemyChoose = Choose.NONE;
					bPlayingPaperGame = true;
					bSelectingCard = true;
					bCanSelect = false;
					bSelectedCCard = false;
					bSelectingPlayerOrder = false;
					enemyChoose = Resources.Load ("FaceDownCard") as Texture2D;
					bChoosingWinner = false;
				}
				else
				{
					bSelectingPlayerOrder = true;
					bChoosingWinner = false;
					
					if(_Choose == Choose.PAPER && _EnemyChoose == Choose.ROCK ||
					   _Choose == Choose.ROCK  && _EnemyChoose == Choose.SCISSOR ||
				       _Choose == Choose.SCISSOR && _EnemyChoose == Choose.PAPER)
					{
						bCanSelect = true;
					}
					else
					{
						bCanSelect = false;	
					}
				}
			}
			
			return;
		}
		
		if(bPlayingPaperGame)
		{
			if(bSelectedCCard)
			{
				if(_EnemyChoose != Choose.NONE)
				{
					if(_EnemyChoose == Choose.PAPER)
					{
						enemyChoose = paper;
					}
					else if(_EnemyChoose == Choose.ROCK)
					{
						enemyChoose = rock;
					}
					else if(_EnemyChoose == Choose.SCISSOR)
					{
						enemyChoose = scissor;
					}
				
					bChoosingWinner = true;
					endGameDelay = 1;
				}
				
				return;
			}
			
			if(bSelectingCard)
			{
				if(MouseOn(xRock, yRock, _w, _y, Input.mousePosition) && Input.GetMouseButtonUp(0))
				{
					bSelectingCard = false;
					_Choose = Choose.ROCK;
					Debug.Log ("Rock");
				}
				
				if(MouseOn(xScissor, yScissor, _w, _y, Input.mousePosition) && Input.GetMouseButtonUp(0))
				{
					bSelectingCard = false;
					_Choose = Choose.SCISSOR;
				}

				if(MouseOn(xPaper, yPaper, _w, _y, Input.mousePosition) && Input.GetMouseButtonUp(0))
				{
					bSelectingCard = false;
					_Choose = Choose.PAPER;
				}
			}
			else
			{
				bool bDone = true;
				
				if(_Choose == Choose.PAPER)
				{
					if(Math.Abs((deltaX + xPaper) - middleX) > 5)
					{
						if(deltaX + xPaper < middleX)
						{
							deltaX += speed * Time.deltaTime;
						}
						else
						{
							deltaX -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}
					else
					{
						deltaX = middleX - xPaper;	
					}
					
					if(Math.Abs((deltaY + yPaper) - middleY) > 5)
					{
						if(deltaY + yPaper < middleY)
						{
							deltaY += speed * Time.deltaTime;
						}
						else
						{
							deltaY -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}
					else
					{
						deltaY = middleY - yPaper;	
					}
				}
				else if(_Choose == Choose.ROCK)
				{
					if(Math.Abs((deltaX + xRock) - middleX) > 5)
					{
						if(deltaX + xRock < middleX)
						{
							deltaX += speed * Time.deltaTime;
						}
						else
						{
							deltaX -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}
					else 
					{
						deltaX = middleX - xRock;	
					}
					
					if(Math.Abs((deltaY + yRock) - middleY) > 5)
					{
						if(deltaY + yRock < middleY)
						{
							deltaY += speed * Time.deltaTime;
						}
						else
						{
							deltaY -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}	
					else
					{
						deltaY = middleY - yRock;	
					}
				}
				else if(_Choose == Choose.SCISSOR)
				{
					if(Math.Abs((deltaX + xScissor) - middleX) > 5)
					{
						if(deltaX + xScissor < middleX)
						{
							deltaX += speed * Time.deltaTime;
						}
						else
						{
							deltaX -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}
					else 
					{
						deltaX = middleX - xScissor;	
					}
					
					if(Math.Abs((deltaY + yScissor) - middleY) > 5)
					{
						if(deltaY + yScissor < middleY)
						{
							deltaY += speed * Time.deltaTime;
						}
						else
						{
							deltaY -= speed * Time.deltaTime;	
						}
						
						bDone = false;
					}
					else
					{
						deltaY = middleY - yScissor;	
					}
				}
					
				if(Math.Abs((enemyDeltaY + enemyY) - enemyMiddleY) > 5)
				{
					if(enemyDeltaY + enemyY < enemyMiddleY)
					{
						enemyDeltaY += speed * Time.deltaTime;
					}
					else
					{
						enemyDeltaY -= speed * Time.deltaTime;	
					}
					
					bDone = false;
				}
				else
				{
					enemyDeltaY = enemyMiddleY - enemyY;
				}
				
				if(bDone)
				{
					bSelectedCCard = true;	
					SendChoose(_Choose);
				}
			}
		}
	}
	
	bool MouseOn(float _x, float _y, float _w, float _h, Vector3 mousePos)
	{
		float x = mousePos.x;
		float y = Screen.height - mousePos.y;
		
		if(x > _x && x < (_x + _w) && y > _y && y < (_y + _h))
		{
			return true;	
		}
		return false;
	}
	
	void OnGUI()
	{
		if(bChoosingWinner)
		{
			if(_Choose == Choose.PAPER)	GUI.DrawTexture(new Rect(xPaper + deltaX, yPaper + deltaY, _w, _h), paper);
			else if(_Choose == Choose.SCISSOR) GUI.DrawTexture(new Rect(xScissor + deltaX, yScissor + deltaY, _w, _h), scissor);
			else if(_Choose == Choose.ROCK) GUI.DrawTexture(new Rect(xRock + deltaX, yRock + deltaY, _w, _h), rock);	
			GUI.DrawTexture(new Rect(enemyX, enemyY + enemyDeltaY, _w, _h), enemyChoose);
			return;	
		}
		
		if(bSelectingPlayerOrder)
		{	
			GUI.DrawTexture(new Rect(xFirstTurn, yFirstTurn, firstTurnIdle.width, firstTurnIdle.height), firstTurnTexture);
			GUI.DrawTexture(new Rect(xSecondTurn, ySecondTurn, firstTurnIdle.width, firstTurnIdle.height), secondTurnTexture);
			return;
		}
		
		if(!bPlayingPaperGame)
		{
			GUI.DrawTexture(new Rect(_x, _y, settingsBackground.width, settingsBackground.height), settingsBackground);
			GUI.DrawTexture(new Rect(_xAvatar + _x, _yAvatar + _y, 128, 128), avatar);
			GUI.DrawTexture(new Rect(_xEnemyAvatar + _x, _yEnemyAvatar + _y, 128, 128 ), enemyAvatar);
			GUI.DrawTexture(new Rect(_xVersus, _yVersus, versus.width, versus.height), versus);
			
			if(!bPlayerReady)
			{
				decklist.Render();
			}
			
			if(bPlayerReady)
			{
				GUI.DrawTexture(new Rect(_xAvatar + (128 - readyState.width), _y + _yAvatar + (128 - readyState.height), readyState.width, readyState.height), readyState);
			}
			else
			{
				GUI.DrawTexture(new Rect(_xAvatar + (128 - readyState.width), _y + _yAvatar + (128 - readyState.height), readyState.width, readyState.height), notReadyState);
			}
			
			if(bEnemyReady)
			{
				GUI.DrawTexture(new Rect(_xEnemyAvatar + (128 - readyState.width), _y + _yEnemyAvatar + (128 - readyState.height), readyState.width, readyState.height), readyState);
			}
			else
			{
				GUI.DrawTexture(new Rect(_xEnemyAvatar + (128 - readyState.width), _y + _yEnemyAvatar + (128 - readyState.height), readyState.width, readyState.height), notReadyState);
			}
			
			GUI.Label(new Rect(_xAvatar + _x + (64 - 4.5f * PlayerVariables.playerName.Length), _yAvatar + _y + (128 + 5), 100, 35), PlayerVariables.playerName, font);
			GUI.Label(new Rect(_xEnemyAvatar + _x + (64 - 4.5f * PlayerVariables.enemyName.Length), _yEnemyAvatar + _y + (128 + 5), 100, 35), PlayerVariables.enemyName, font);			
			
			if(GUI.Button(new Rect(Screen.width - 100, _y + (settingsBackground.height - 25 - 25), 100, 25), "Back to menu"))
			{
				Network.Disconnect();
				Application.LoadLevel("MainMenu");	
			}
		

			/*
			if(bPlayerReady) Debug.Log ("bPlayerReady = true");
			else Debug.Log ("bPlayerReady = false");

			if(bPlayerConnected) Debug.Log ("bPlayerConnected = true");
			else Debug.Log ("bPlayerConnected = false");
			*/

			if(!bPlayerReady && PlayerVariables.bPlayerConnected)
			{
				if(GUI.Button(new Rect(_xEnemyAvatar, _y + (settingsBackground.height - 50), 100, 25), "Ready!"))
				{
					bPlayerReady = true;
					PlayerPrefs.SetString("DefaultDeck", decklist.GetValue());
					Ready();
				}
			}
		}
		else
		{
			if(bSelectingCard)
			{
				GUI.DrawTexture(new Rect(xPaper, yPaper, _w, _h), paper);
				GUI.DrawTexture(new Rect(xScissor, yScissor, _w, _h), scissor);
				GUI.DrawTexture(new Rect(xRock, yRock, _w, _h), rock);
			}
			else
			{
				if(_Choose == Choose.PAPER)	GUI.DrawTexture(new Rect(xPaper + deltaX, yPaper + deltaY, _w, _h), paper);
				else if(_Choose == Choose.SCISSOR) GUI.DrawTexture(new Rect(xScissor + deltaX, yScissor + deltaY, _w, _h), scissor);
				else if(_Choose == Choose.ROCK) GUI.DrawTexture(new Rect(xRock + deltaX, yRock + deltaY, _w, _h), rock);	
				GUI.DrawTexture(new Rect(enemyX, enemyY + enemyDeltaY, _w, _h), enemyChoose);
			}
		}
	}
	
	void OnPlayerConnected(NetworkPlayer np)
	{
		PlayerVariables.bPlayerConnected = true;
		Debug.Log ("Player Connected.");
		
		PlayerVariables.player = Network.player;
		PlayerVariables.opponent = np;
		
		networkView.RPC ("EnterSingleMatch", np);
		networkView.RPC ("GetPlayerNetwork", np, PlayerVariables.player);
		networkView.RPC ("GetEnemyName",     np, PlayerVariables.playerName);
	}
	
	void OnConnectedToServer() {
		PlayerVariables.bPlayerConnected = true;
		networkView.RPC ("GetEnemyName", PlayerVariables.opponent, PlayerVariables.playerName);
	}
	
	void StartGame(bool bFirstTurn)
	{
		PlayerVariables.bFirstTurn = bFirstTurn;

		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("StartGameRequest_Server", RPCMode.Server, bFirstTurn, Network.player);
		}
		else
		{
			networkView.RPC ("StartGameRequest", PlayerVariables.opponent, bFirstTurn);
		}
	}
	
	void Ready()
	{
		PlayerVariables.DeckName = PlayerPrefs.GetString("DefaultDeck");

		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("ReadyForPlayServer", RPCMode.Server, Network.player);	
		}
		else if(PlayerVariables.bPlayingAgainstIA)
		{

		}
		else
		{
			networkView.RPC ("ReadyForPlay", PlayerVariables.opponent);	
		}
	}
	
	[RPC]
	void ReadyForPlay()
	{
		bEnemyReady = true;	
	}

	[RPC]
	void ReadyForPlayServer(NetworkPlayer player)
	{

	}
	
	void OnDisconnectedFromServer()
	{
		CleanVariables();
		Application.LoadLevel("MainMenu");	
	}
	
	void OnPlayerDisconnected(NetworkPlayer networkPlayer)
	{	
		Network.RemoveRPCs(networkPlayer);
		Network.DestroyPlayerObjects(networkPlayer);
		Network.Disconnect();
		CleanVariables();
		Application.LoadLevel("MainMenu");	
	}
	
	void CleanVariables()
	{
		//PlayerVariables.serverName = "";
		PlayerVariables.enemyName = "";
	}
	
	void SendChoose(Choose c)
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("SendChooseInfo_Server", RPCMode.Server, (int)c, Network.player);	
		}
		else if(PlayerVariables.bPlayingAgainstIA)
		{
			_EnemyChoose = PlayerVariables.enemyAI.GetChoosePaperGame();
		}
		else
		{
			networkView.RPC ("SendChooseInfo", PlayerVariables.opponent, (int)c);		
		}
	}
	
	[RPC]
	void SendChooseInfo(int c)
	{
		_EnemyChoose = (Choose)c;
	}

	[RPC]
	void SendChooseInfo_Server(int c, NetworkPlayer player)
	{

	}
	
	void SelectFirst()
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("SelectFirstRPC_Server", RPCMode.Server, Network.player);
		}
		else
		{
			networkView.RPC ("SelectFirstRPC", PlayerVariables.opponent);
		}
	}

	[RPC]
	void PlayerEnterRoom()
	{
		PlayerVariables.bPlayerConnected = true;
	}

	[RPC]
	void SelectFirstRPC()
	{
		firstTurnTexture = firstTurnOver;
		secondTurnTexture = secondTurnIdle;
	}

	[RPC]
	void SelectFirstRPC_Server(NetworkPlayer player)
	{

	}
	
	void SelectSecond()
	{
		if(PlayerVariables.bPlayingOnServer)
		{
			networkView.RPC ("SelectSecondRPC_Server", RPCMode.Server, Network.player);	
		}
		else
		{
			networkView.RPC ("SelectSecondRPC", PlayerVariables.opponent);	
		}
	}
	
	[RPC]
	void SelectSecondRPC()
	{
		firstTurnTexture = firstTurnIdle;
		secondTurnTexture = secondTurnOver;
	}

	[RPC]
	void SelectSecondRPC_Server(NetworkPlayer player)
	{

	}

	[RPC]
	void ForceToRefresh()
	{

	}
	
	[RPC]
	void StartGameRequest(bool bFirstTurn)
	{
		if(!bFirstTurn)
		{
			PlayerVariables.bFirstTurn = true;
		}
		else
		{
			PlayerVariables.bFirstTurn = false;	
		}
	
		Application.LoadLevel(nextLevel);	
	}

	[RPC]
	void StartGameRequest_Server(bool bFirstTurn, NetworkPlayer player)
	{

	}
	
	[RPC]
	void GetServerName(string _serverName)
	{
		//PlayerVariables.serverName = _serverName;	
	}

	[RPC]
	void GetPlayerNetwork(NetworkPlayer opponentPlayer)
	{
		PlayerVariables.opponent = opponentPlayer;	
	}
	
	[RPC]
	void GetEnemyName(string name)
	{
		PlayerVariables.enemyName = name;	
	}

	[RPC]
	void EnterSingleMatch()
	{
		Application.LoadLevel("SetupAGame");
	}
}
