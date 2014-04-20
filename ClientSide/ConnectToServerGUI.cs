using UnityEngine;
using System.Collections;

public class ConnectToServerGUI {
	public delegate void OnBackDel();

	Texture2D background;
	GUIStyle connectbuttonStyle;
	GUIStyle gobackbuttonStyle;
	
	OnBackDel OnBack;

	string playerName  = "";
	string connectToIP = "";

	int connectionPort = 0;
	int x = 100;
	int y = 100;
	int labelWidth  = 100;
	int labelHeight = 20;

	public ConnectToServerGUI()
	{
		playerName     = PlayerPrefs.GetString("playerName");
		connectToIP    = PlayerPrefs.GetString ("IP");
		connectionPort = PlayerPrefs.GetInt("PORT", 26500);

		background = Resources.Load("GUI/menubackgroud") as Texture2D;

		connectbuttonStyle = new GUIStyle();
		connectbuttonStyle.normal.background = Resources.Load ("GUI/Connect") as Texture2D;
		connectbuttonStyle.hover.background = Resources.Load ("GUI/Connect_Hover") as Texture2D;

		gobackbuttonStyle = new GUIStyle();
		gobackbuttonStyle.normal.background = Resources.Load ("GUI/goback") as Texture2D;
		gobackbuttonStyle.hover.background = Resources.Load ("GUI/goback_Hover") as Texture2D;
	}

	public void OnBackCallback(OnBackDel fnc)
	{
		OnBack = fnc;
	}

	public void Render()
	{
		float tempX = (Screen.width - background.width) * 0.5f;
		float tempY = (Screen.height - background.height) * 0.5f;
		float tempW = background.width;
		float tempH = background.height;

		GUI.DrawTexture(new Rect(tempX, tempY, tempW, tempH), background);

		float labelX = tempX + (tempW - labelWidth * 2) * 0.5f;
		float labelY = tempY + tempH * 0.2f;
		GUI.Label(new Rect(labelX, labelY, labelWidth, labelHeight), "Enter your player name");
		playerName = GUI.TextField(new Rect(labelX + labelWidth + labelWidth * 0.1f, labelY, labelWidth, labelHeight), playerName);

		GUI.Label(new Rect(labelX, labelY + labelHeight, labelWidth, labelHeight), "Server IP");
		connectToIP = GUI.TextField(new Rect(labelX + labelWidth + labelWidth * 0.1f, labelY + labelHeight, labelWidth, labelHeight), connectToIP);

		GUI.Label(new Rect(labelX, labelY + labelHeight * 2, labelWidth, labelHeight), "Server port");
		connectionPort = int.Parse(GUI.TextField(new Rect(labelX + labelWidth + labelWidth * 0.1f, labelY + labelHeight * 2, labelWidth, labelHeight), connectionPort.ToString()));	

		float offset = connectbuttonStyle.normal.background.width * 0.6f;

		if(GUI.Button (new Rect(labelX - offset, labelY + labelHeight * 8, connectbuttonStyle.normal.background.width, connectbuttonStyle.normal.background.height), "", connectbuttonStyle))
		{
			if(playerName != "")
			{
				Network.Connect(connectToIP, connectionPort);
				
				PlayerPrefs.SetString("IP", connectToIP);
				PlayerPrefs.SetInt("PORT", connectionPort);
				
				PlayerPrefs.SetString("playerName", playerName);
			}

			PlayerVariables.bHost = false;
		}

		if(GUI.Button(new Rect(labelX + offset + 40, labelY + labelHeight * 8, gobackbuttonStyle.normal.background.width, gobackbuttonStyle.normal.background.height), "", gobackbuttonStyle))
		{
			OnBack();
		}
	}
}
