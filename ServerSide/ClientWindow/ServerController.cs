using UnityEngine;
using System.Collections;

public class ServerController : MonoBehaviour {
	RoomCreatorGUI _RoomCreatorGUI;
	RoomManager    _RoomManager;
	RoomViewGUI    _RoomViewGUI;

	public void Start()
	{
		PlayerVariables.bPlayingOnServer = true;

		_RoomCreatorGUI = new RoomCreatorGUI(0, 0);
		_RoomManager    = new RoomManager();
		_RoomViewGUI    = new RoomViewGUI(200, 0);

		_RoomCreatorGUI.OnCreateGameCallback(delegate(string roomName, string roomPassword) {
			Application.LoadLevel("SetupAGame");
			networkView.RPC("CreateRoom", RPCMode.Server, roomName, roomPassword, Network.player);
		});

		_RoomCreatorGUI.OnRefreshCallback(delegate {
			RefreshRoomList();
		});

		_RoomViewGUI.OnEnterRoomCallback(delegate(int roomIndex) {
			networkView.RPC("RequestEnterRoom", RPCMode.Server, Network.player, roomIndex);
		});

		_RoomViewGUI.SetRoomManager(_RoomManager);

		RefreshRoomList();
	}

	public void RefreshRoomList()
	{
		_RoomManager.ClearList();
		networkView.RPC("GetRoomList", RPCMode.Server, Network.player);
	}

	public void OnGUI()
	{
		_RoomCreatorGUI.Render();
		_RoomViewGUI.Render();
	}

	[RPC]
	void EnterRoomAccepted(int roomIndex)
	{
		PlayerVariables.bPlayerConnected = true;
		Application.LoadLevel("SetupAGame");	
	}

	[RPC]
	void RequestEnterRoom(NetworkPlayer player, int roomIndex)
	{

	}

	[RPC]
	void PlayerEnterRoom()
	{

	}

	[RPC]
	void RequestServerNetwork(NetworkPlayer player)
	{

	}
	
	[RPC]
	void SendServerNetwork(NetworkPlayer player)
	{
		PlayerVariables.opponent = player;
	}

	[RPC]
	void AddPlayerToRoom(NetworkPlayer player, int index)
	{
		_RoomManager.GetRoom(index).AddPlayer(new RoomPlayer(player));
	}

	[RPC]
	void CreateRoom(string roomName, string roomPassword, NetworkPlayer player)
	{

	}

	[RPC]
	void SendSingleRoom(string name, string password)
	{
		_RoomManager.AddRoom(new Room(name, password));
	}

	[RPC]
	void GetRoomList(NetworkPlayer player)
	{

	}

	[RPC]
	void ForceToRefresh()
	{
		RefreshRoomList();
	}
}
