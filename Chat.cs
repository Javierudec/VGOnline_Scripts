using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ChatTab
{
	GAME,
	CHAT,
	HELP
};

public class Chat {
	//Max num of lines that the chat will handle.
	private const int MAX_LINES = 7;
	//Max length of a line. (Characters)
	private const int MAX_LINE_LENGTH = 10;
	//The chat messages will be hold in a list.
	private List<string> ChatMessage;
	private List<string> GameMessage;
	private List<string> HelpMessage;
	
	private string currentMessage = "";
	
	private float xScale = 1.0f;
	private float yScale = 1.0f;
	
	public ChatTab currentTab = ChatTab.CHAT;
	
	public Chat()
	{
		ChatMessage = new List<string>();
		GameMessage = new List<string>();
		HelpMessage = new List<string>();
		//Input.eatKeyPressOnTextFieldFocus = false;
		
		xScale = Screen.width / 1024.0f;
		yScale = Screen.height / 768.0f;
	}
	
	public void AddChatMessage(string name, string message)
	{
		if(name == "ADMIN" || name == "ADMIN2") return;
		
		string tempMessage;
		tempMessage = name + ": " + message;
		ChatMessage.Add(tempMessage);
		if(ChatMessage.Count > MAX_LINES)
		{
			ChatMessage.RemoveAt(0);	
		}
	}
	
	public void AddGameMessage(string name, string message)
	{
		string tempMessage;
		tempMessage = name + ": " + message;
		GameMessage.Add(tempMessage);
		if(GameMessage.Count > MAX_LINES)
		{
			GameMessage.RemoveAt(0);	
		}
	}
	
	public void AddHelpMessage(string message)
	{	
		string tempMessage;
		tempMessage = message;
		HelpMessage.Add(tempMessage);
		if(HelpMessage.Count > 1)
		{
			HelpMessage.RemoveAt(0);	
		}
	}
	
	public void DrawGUI()
	{
		if(GUI.Button(new Rect(0, 600 * yScale, 60 * xScale, 20 * yScale), "Chat"))
		{
			currentTab = ChatTab.CHAT;
		}
		
		if(GUI.Button(new Rect(60 * xScale, 600 * yScale, 60 * xScale, 20 * yScale), "Game"))
		{
			currentTab = ChatTab.GAME;
		}
		
		if(GUI.Button(new Rect(120 * xScale, 600 * yScale, 60 * xScale, 20 * yScale), "Help"))
		{
			currentTab = ChatTab.HELP;
		}
		
		Rect ChatWindow = new Rect(0, 620 * yScale, 340 * xScale, 120 * yScale);
		Rect WriterWindow = new Rect(0, 740 * yScale, 340 * xScale, 20 * yScale);
	
		string chat_str = "";
		if(currentTab == ChatTab.CHAT)
		{
			chat_str = FillWindow(ChatMessage);
		}
		else if(currentTab == ChatTab.GAME)
		{
			chat_str = FillWindow(GameMessage);	
		}
		else if(currentTab == ChatTab.HELP)
		{
			chat_str = FillWindow(HelpMessage);	
		}
		
		GUI.TextArea(ChatWindow, chat_str);
		currentMessage = GUI.TextField(WriterWindow, currentMessage);
		
	}
	
	string FillWindow(List<string> messages)
	{
		string chat_str = "";
		for(int i = 0; i < messages.Count; i++)
		{
			chat_str += messages[i];
			chat_str += "\n";
		}		
		return chat_str;
	}
	
	public string GetCurrentMessage()
	{	
		return currentMessage;
	}

	public void ClearChat()
	{
		currentMessage = "";	
	}
	
	public void SetTab(ChatTab t)
	{
		currentTab = t;	
	}
}
