using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomPlayer
{
	NetworkPlayer networkPlayer;

	public RoomPlayer(NetworkPlayer _NetWorkPlayer)
	{
		networkPlayer = _NetWorkPlayer;
	}

	public NetworkPlayer GetNetworkPlayer()
	{
		return networkPlayer;
	}
}

public class Room
{
	public delegate void OnViewPlayerListDel(RoomPlayer player);

	List<RoomPlayer> players;

	string nameRoom;
	string passwordRoom;

	int playersAllowed = 2;

	public Room(string _nameRoom, string _passwordRoom)
	{
		nameRoom = _nameRoom;
		passwordRoom = _passwordRoom;

		players = new List<RoomPlayer>();
	}

	public string GetRoomName()
	{
		return nameRoom;
	}

	public bool Remove(RoomPlayer p)
	{
		bool toReturn = false;
		if(players[0] == p) toReturn = true;
		players.Remove(p);
		return toReturn;
	}

	public bool HasPassword()
	{
		return passwordRoom != "";
	}

	public int GetPlayersAllowed()
	{
		return playersAllowed;
	}

	public int GetCurrentPlayers()
	{
		return players.Count;
	}

	public string GetPassword()
	{
		return passwordRoom;
	}

	public void AddPlayer(RoomPlayer roomPlayer)
	{
		players.Add(roomPlayer);
	}

	public void ViewPlayerList(OnViewPlayerListDel viewPlayer)
	{
		for(int i = 0; i < players.Count; i++)
		{
			viewPlayer(players[i]);
		}
	}

	public RoomPlayer GetPlayerByID(int index)
	{
		return players[index];
	}
}

public class RoomManager {
	public delegate void onViewRoomListDel(Room room);

	List<Room> roomList;

	public RoomManager()
	{
		roomList = new List<Room>();
	}

	public void AddRoom(Room room)
	{
		roomList.Add(room);
	}

	public void ViewRoomList(onViewRoomListDel onViewRoomList)
	{
		for(int i = 0; i < roomList.Count; i++)
		{
			onViewRoomList(roomList[i]);
		}
	}

	public int GetNumRooms()
	{
		return roomList.Count;
	}

	public void ClearList()
	{
		roomList.Clear();
	}

	public Room GetRoom(int index)
	{
		return roomList[index];
	}

	public bool RemovePlayer(NetworkPlayer p)
	{
		bool bRemoved = false;
		ViewRoomList(delegate(Room room) {
			room.ViewPlayerList(delegate(RoomPlayer player) {
				if(p == player.GetNetworkPlayer())
				{
					if(room.Remove(player))
					{
						roomList.Remove(room);
					}

					bRemoved = true;
					return;
				}
			});

			if(bRemoved) 
			{
				return;
			}
		});
		return bRemoved;
	}

	public NetworkPlayer GetOpponent(NetworkPlayer p)
	{
		for(int i = 0; i < roomList.Count; i++)
		{
			if(roomList[i].GetCurrentPlayers() >= 2)
			{
				if(roomList[i].GetPlayerByID(0).GetNetworkPlayer() == p) return roomList[i].GetPlayerByID(1).GetNetworkPlayer();
				if(roomList[i].GetPlayerByID(1).GetNetworkPlayer() == p) return roomList[i].GetPlayerByID(0).GetNetworkPlayer();
			}
		}

		return Network.player;
	}
}
