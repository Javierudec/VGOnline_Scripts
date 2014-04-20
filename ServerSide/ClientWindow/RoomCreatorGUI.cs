using UnityEngine;
using System.Collections;

public class RoomCreatorGUI {
	public delegate void onCreateRoomDel(string name, string password);
	public delegate void onRefreshDel();

	float x, y;

	string roomName, roomPassword;

	onCreateRoomDel onCreateGame;
	onRefreshDel    onRefresh;

	public RoomCreatorGUI(float _x, float _y)
	{
		x = _x;
		y = _y;

		roomName = "No Name";
		roomPassword = "";

		onCreateGame = null;
	}

	public void OnCreateGameCallback(onCreateRoomDel fnc)
	{
		onCreateGame = fnc;
	}

	public void OnRefreshCallback(onRefreshDel fnc)
	{
		onRefresh = fnc;
	}

	public void Render()
	{
		int labelHeight = 20;
		int labelWidth  = 100;

		GUI.Label(new Rect(x, y, labelWidth, labelHeight), "Create Game:");
		GUI.Label(new Rect(x, y + labelHeight, labelWidth, labelHeight), "Name:");
		GUI.Label(new Rect(x, y + labelHeight * 2, labelWidth, labelHeight), "Password:");

		roomName = GUI.TextField(new Rect(x + labelWidth, y + labelHeight, labelWidth, labelHeight), roomName);
		roomPassword = GUI.TextField(new Rect(x + labelWidth, y + labelHeight * 2, labelWidth, labelHeight), roomPassword);

		if(GUI.Button(new Rect(x, y + labelHeight * 3, labelWidth, labelHeight), "Create"))
		{
			onCreateGame(roomName, roomPassword);
		}

		if(GUI.Button(new Rect(x, y + labelHeight * 4, labelWidth, labelHeight), "Refresh"))
		{
			onRefresh();
		}
	}
}
