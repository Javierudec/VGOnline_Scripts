using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
	NetworkPlayer networkPlayer;

	public Player(NetworkPlayer _networkPlayer)
	{
		networkPlayer = _networkPlayer;
	}

	public NetworkPlayer GetNetworkPlayer()
	{
		return networkPlayer;
	}
}

public class ServerPlayerList {
	List<Player> playerList;

	public ServerPlayerList()
	{
		playerList = new List<Player>();
	}

	public int GetNumPlayers()
	{
		return playerList.Count;
	}

	public void AddPlayer(Player player)
	{
		playerList.Add(player);
	}

	public void RemovePlayer(NetworkPlayer player)
	{
		foreach(Player p in playerList)
		{
			if(p.GetNetworkPlayer() == player)
			{
				playerList.Remove(p);
				return;
			}
		}
	}
}
