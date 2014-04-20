using UnityEngine;
using System.Collections;

public class ServerLauncher : MonoBehaviour {
	ServerLauncherGUI _ServerLauncherGUI;
	ServerPlayerList  _ServerPlayerList;
	RoomManager       _RoomManager;

	int numberOfPlayers = 32;
	int connectionPort = 26500;

	void Start () 
	{
		_ServerLauncherGUI = new ServerLauncherGUI();
		_ServerPlayerList  = new ServerPlayerList();
		_RoomManager       = new RoomManager();

		_ServerLauncherGUI.SetServerLauncher(this);
		_ServerLauncherGUI.SetServerStatus(ServerStatus.STARTING);

		Network.InitializeServer(numberOfPlayers, connectionPort, false);
	}

	void OnGUI() 
	{
		_ServerLauncherGUI.Render();
	}

	void OnServerInitialized()
	{
		_ServerLauncherGUI.SetServerStatus(ServerStatus.UP);
	}

	void OnPlayerConnected(NetworkPlayer newPlayer)
	{
		networkView.RPC("EnterServer", newPlayer);

		_ServerPlayerList.AddPlayer(new Player(newPlayer));
	}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		_ServerPlayerList.RemovePlayer(player);
	
		if(_RoomManager.RemovePlayer(player))
		{
			networkView.RPC("ForceToRefresh", RPCMode.Others);
		}
	}

	public int GetNumPlayers()
	{
		return _ServerPlayerList.GetNumPlayers();
	}

	public int GetNumRooms()
	{
		return _RoomManager.GetNumRooms();
	}

	[RPC]
	void RequestEnterRoom(NetworkPlayer player, int roomIndex)
	{
		Room room = _RoomManager.GetRoom(roomIndex);
		if(room.GetCurrentPlayers() < room.GetPlayersAllowed())
		{
			room.AddPlayer(new RoomPlayer(player));
			networkView.RPC ("EnterRoomAccepted", player, roomIndex);

			room.ViewPlayerList(delegate(RoomPlayer roomPlayer) {
				networkView.RPC("PlayerEnterRoom", roomPlayer.GetNetworkPlayer());
			});
		}
	}

	[RPC]
	void RequestServerNetwork(NetworkPlayer player)
	{
		networkView.RPC ("SendServerNetwork", Network.player);
	}

	[RPC]
	void SendServerNetwork(NetworkPlayer player)
	{

	}

	[RPC]
	void PlayerEnterRoom()
	{

	}

	[RPC]
	void EnterRoomAccepted(int roomIndex)
	{

	}

	[RPC]
	void EnterSingleMatch()
	{

	}
	
	[RPC]
	void EnterServer()
	{

	}

	[RPC]
	void GetRoomList(NetworkPlayer player)
	{
		int index = 0;
		_RoomManager.ViewRoomList(delegate(Room room) {
			networkView.RPC("SendSingleRoom", player, room.GetRoomName(), room.GetPassword());
			room.ViewPlayerList(delegate(RoomPlayer p) {
				Debug.Log("AddPlayer");
				networkView.RPC("AddPlayerToRoom", player, p.GetNetworkPlayer(), index);
			});
			index++;
		});
	}

	[RPC]
	void AddPlayerToRoom(NetworkPlayer player, int index)
	{

	}

	[RPC] 
	void SendSingleRoom(string name, string password)
	{

	}

	[RPC]
	void CreateRoom(string roomName, string roomPassword, NetworkPlayer player)
	{
		_RoomManager.AddRoom(new Room(roomName, roomPassword));
		_RoomManager.GetRoom(_RoomManager.GetNumRooms() - 1).AddPlayer(new RoomPlayer(player));
		networkView.RPC("ForceToRefresh", RPCMode.Others);
	}

	[RPC]
	void ForceToRefresh()
	{

	}

	[RPC]
	void ReadyForPlayServer(NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("ReadyForPlay", opponent);
	}
	
	[RPC]
	void ReadyForPlay()
	{
		
	}

	[RPC]
	void SendChooseInfo(int c)
	{

	}
	
	[RPC]
	void SendChooseInfo_Server(int c, NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("SendChooseInfo", opponent, c);		
	}

	[RPC]
	void SelectFirstRPC()
	{

	}
	
	[RPC]
	void SelectFirstRPC_Server(NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("SelectFirstRPC", opponent);			
	}

	[RPC]
	void SelectSecondRPC()
	{

	}
	
	[RPC]
	void SelectSecondRPC_Server(NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("SelectSecondRPC", opponent);			
	}

	[RPC]
	void StartGameRequest(bool bFirstTurn)
	{

	}
	
	[RPC]
	void StartGameRequest_Server(bool bFirstTurn, NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("StartGameRequest", opponent, bFirstTurn);			
	}

	[RPC]
	void SendInformationToOpponent_Server(int cardID, int gameAction, int other1, int other2, string str1, int other3, NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("SendInformationToOpponent", opponent, cardID, gameAction, other1, other2, str1, other3);
	}

	[RPC]
	void SendInformationToOpponent(int cardID, int gameAction, int other1, int other2, string str1, int other3)
	{
		
	}

	[RPC]
	void ConfirmAction()
	{

	}
	
	[RPC]
	void ConfirmAction_Server(NetworkPlayer player)
	{
		NetworkPlayer opponent = _RoomManager.GetOpponent(player);
		networkView.RPC("ConfirmAction", opponent);				
	}
}
