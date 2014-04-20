using UnityEngine;
using System.Collections;

public enum ServerStatus 
{
	DOWN,
	STARTING,
	UP
}

public class ServerLauncherGUI {
	ServerLauncher _ServerLauncher;

	ServerStatus status = ServerStatus.STARTING;

	public ServerLauncherGUI()
	{

	}

	public void Render()
	{
		if(status == ServerStatus.UP)
		{
			ServerUpGUI();
		}
		else if(status == ServerStatus.STARTING)
		{
			ServerConnectingGUI();
		}
	}

	public void SetServerStatus(ServerStatus _status)
	{
		status = _status;
	}

	public void SetServerLauncher(ServerLauncher serverLauncher)
	{
		_ServerLauncher = serverLauncher;
	}

	void ServerUpGUI()
	{
		GUI.Label(new Rect(0, 0 , 200, 20), "Server UP!...");
		GUI.Label(new Rect(0, 20, 200, 20), "Players online: " + _ServerLauncher.GetNumPlayers());
		GUI.Label(new Rect(0, 40, 200, 20), "Number of rooms: " + _ServerLauncher.GetNumRooms());
	}

	void ServerConnectingGUI()
	{
		GUI.Label(new Rect(0, 0, 100, 20), "Starting server...");
	}
}
