using UnityEngine;
using System.Collections;

public enum ClientStatus
{
	Disconnected,
	Connecting,
	Hosting
}

public class MultiplayerScript : MonoBehaviour {
	public Texture2D backgroundTexture;
	
	ClientStatus status;

	ConnectToServerGUI _ConnectToServerGUI;
	CreateServerGUI    _CreateServerGUI;
	MenuGUI            _MenuGUI;

	void Start () {
		_ConnectToServerGUI = new ConnectToServerGUI();
		_CreateServerGUI    = new CreateServerGUI();
		_MenuGUI            = new MenuGUI();

		//Resetting variables.
		PlayerVariables.bPlayingAgainstIA = false;

		_MenuGUI.OnSinglePlayerCallback(delegate {
			PlayerVariables.bPlayingAgainstIA = true;
			Application.LoadLevel("SetupAGame");
		});

		_MenuGUI.OnCreateServerCallback(delegate {
			status = ClientStatus.Hosting;
		});

		_MenuGUI.OnJoinGameCallback(delegate {
			status = ClientStatus.Connecting;
		});

		_ConnectToServerGUI.OnBackCallback(delegate {
			status = ClientStatus.Disconnected;
		});

		_CreateServerGUI.OnBackCallback(delegate {
			status = ClientStatus.Disconnected;
		});

		status = ClientStatus.Disconnected;
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		
		if(status == ClientStatus.Disconnected)
		{
			_MenuGUI.Render();
		}
		else if(status == ClientStatus.Connecting)
		{
			_ConnectToServerGUI.Render();
		}
		else if(status == ClientStatus.Hosting)
		{
			_CreateServerGUI.Render();
		}
	}

	void OnPlayerDisconnected(NetworkPlayer networkPlayer)
	{	
		Network.RemoveRPCs(networkPlayer);
		Network.DestroyPlayerObjects(networkPlayer);
	}

	[RPC]
	void EnterServer()
	{
		Application.LoadLevel("ServerManager");
	}

	[RPC]
	void EnterSingleMatch()
	{
		Application.LoadLevel("SetupAGame");
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
}
