using UnityEngine;
using System.Collections;

public class MenuGUI {
	public delegate void OnCreateServerDel();
	public delegate void OnJoinGameDel();
	public delegate void OnSinglePlayerDel();

	OnCreateServerDel OnCreateServer;
	OnJoinGameDel     OnJoinGame;
	OnSinglePlayerDel OnSinglePlayer;

	GUIStyle singlePlayerStyle;
	GUIStyle hostAGameStyle;
	GUIStyle joinAGameStyle;
	GUIStyle editDeckStyle;
	GUIStyle createServerStyle;
	GUIStyle quitGameStyle;

	Texture2D bubbleTextContainer;

	int buttonWidth = 150;
	int buttonHeight = 40;
	int x = 40;

	public MenuGUI()
	{
		singlePlayerStyle = new GUIStyle();
		singlePlayerStyle.normal.background = Resources.Load("GUI/SinglePlayer") as Texture2D;
		singlePlayerStyle.hover.background = Resources.Load("GUI/SinglePlayer_Hover") as Texture2D;

		hostAGameStyle = new GUIStyle();
		hostAGameStyle.normal.background = Resources.Load("GUI/HostAGame") as Texture2D;
		hostAGameStyle.hover.background = Resources.Load("GUI/HostAGame_Hover") as Texture2D;

		joinAGameStyle = new GUIStyle();
		joinAGameStyle.normal.background = Resources.Load("GUI/JoinAGame") as Texture2D;
		joinAGameStyle.hover.background = Resources.Load("GUI/JoinAGame_Hover") as Texture2D;

		editDeckStyle = new GUIStyle();
		editDeckStyle.normal.background = Resources.Load("GUI/EditDeck") as Texture2D;
		editDeckStyle.hover.background = Resources.Load("GUI/EditDeck_Hover") as Texture2D;
		
		createServerStyle = new GUIStyle();
		createServerStyle.normal.background = Resources.Load("GUI/CreateServer") as Texture2D;
		createServerStyle.hover.background = Resources.Load("GUI/CreateServer_Hover") as Texture2D;

		quitGameStyle = new GUIStyle();
		quitGameStyle.normal.background = Resources.Load("GUI/QuitGame") as Texture2D;
		quitGameStyle.hover.background = Resources.Load("GUI/QuitGame_Hover") as Texture2D;

		bubbleTextContainer = Resources.Load("GUI/TextBubble") as Texture2D;
	}

	public void OnCreateServerCallback(OnCreateServerDel fnc)
	{
		OnCreateServer = fnc;
	}

	public void OnJoinGameCallback(OnJoinGameDel fnc)
	{
		OnJoinGame = fnc;
	}

	public void OnSinglePlayerCallback(OnSinglePlayerDel fnc)
	{
		OnSinglePlayer = fnc;
	}

	//Button Y Position.
	private int GetYPosition(int index)
	{
		int yPosition = 470;
		int yOffset   = 50;

		return yPosition + yOffset * index;
	}

	public void Render()
	{

		if(GUI.Button(new Rect(x, GetYPosition(-1), buttonWidth, buttonHeight), "", singlePlayerStyle))
		{
			OnSinglePlayer();
		}

		if(GUI.Button(new Rect(x, GetYPosition(0), buttonWidth, buttonHeight), "", hostAGameStyle))
		{
			OnCreateServer();
		}
		
		if(GUI.Button(new Rect(x, GetYPosition(1), buttonWidth, buttonHeight), "", joinAGameStyle))
		{
			OnJoinGame();
		}
		
		if(GUI.Button(new Rect(x, GetYPosition(2), buttonWidth, buttonHeight), "", editDeckStyle))
		{
			Application.LoadLevel("DeckEditor");
		}
		
		if(GUI.Button(new Rect(x, GetYPosition(3), buttonWidth, buttonHeight), "", createServerStyle))
		{
			Application.LoadLevel("Server");
		}
		
		if(GUI.Button(new Rect(x, GetYPosition(4), buttonWidth, buttonHeight), "", quitGameStyle))
		{
			Application.Quit();
		}

		string desc = "";
		int yTmpPos = 0;

		if(Util.MouseOn(x, GetYPosition(0), buttonWidth, buttonHeight, Input.mousePosition))
		{
			desc = "Hosting allows you to play with a friend sharing your IP with him.";
			yTmpPos = GetYPosition(0);
		}

		if(Util.MouseOn(x, GetYPosition(3), buttonWidth, buttonHeight, Input.mousePosition))
		{
			desc = "You can play with a friend or enter into a server if you know the IP.";
			yTmpPos = GetYPosition(3);
		}

		if(Util.MouseOn(x, GetYPosition(3), buttonWidth, buttonHeight, Input.mousePosition))
		{
			desc = "You can transforms your PC into a Server.\n" +
				   "You need to share your IP with people who wants to join to your server.";
			yTmpPos = GetYPosition(3);
		}

		if(desc != "")
		{
			yTmpPos -= 110;
			//GlobalFunction.DrawQuad(new Rect(x + buttonWidth + 30, 470, 368, 256), new Color(0.0f, 0.0f, 0.0f, 0.8f));
			GUI.DrawTexture(new Rect(x + buttonWidth + 20, yTmpPos, bubbleTextContainer.width, bubbleTextContainer.height), bubbleTextContainer);

			Color tmpColor = GUI.color;
			GUI.color = Color.black;
			GUI.Label(new Rect(x + + buttonWidth + 20 + 10, yTmpPos + 10, bubbleTextContainer.width - 20, bubbleTextContainer.height - 40), desc);
			//GUI.Label(new Rect(x + + buttonWidth + 30 + 10, 470 + 10, 368 - 20, 256 - 40), desc);
			GUI.color = tmpColor;
		}
	}
}
