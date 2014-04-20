using UnityEngine;
using System.Collections;

public class RoomViewGUI {
	public delegate void OnEnterRoomDel(int roomIndex);

	OnEnterRoomDel onEnterRoom;
	float x, y;
	float roomWidth  = 450;
	float roomHeight = 20;
	RoomManager _RoomManager = null;

	public RoomViewGUI(float _x, float _y)
	{
		x = _x;
		y = _y;
	}

	public void SetRoomManager(RoomManager roomManager)
	{
		_RoomManager = roomManager;
	}

	public void OnEnterRoomCallback(OnEnterRoomDel fnc)
	{
		onEnterRoom = fnc;
	}

	public void Render()
	{
		int countRooms = 0;
		_RoomManager.ViewRoomList(delegate(Room room) {
			string roomCaption = room.GetRoomName();

			roomCaption = roomCaption + " (" + room.GetCurrentPlayers() + "/" + room.GetPlayersAllowed() + ")"; 

			if(room.HasPassword())
			{
				roomCaption += " (Password required)";
			}

			if(GUI.Button(new Rect(x, y + roomHeight * countRooms, roomWidth, roomHeight), roomCaption))
			{
				onEnterRoom(countRooms);
			}

			countRooms++;
		});
	}
}
