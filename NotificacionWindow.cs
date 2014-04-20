using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificacionWindow {
	Card source;
	string caption;
	bool bIsActive = false;
	Gameplay Game = null;

	public delegate void void0param();
	void0param actionToPerform = null;

	public NotificacionWindow(int _xPos, int _yPos)
	{
		caption = "No title";
	}

	public void SetGame(Gameplay _Game)
	{
		Game = _Game;
	}

	public bool IsOpen()
	{
		return bIsActive;
	}

	public void Render()
	{
		if(bIsActive)
		{
			float leftIndent = Screen.width / 2 - 597.0f / 2 + 150;
			float topIndent = Screen.height / 2 - 145.0f / 2;
			Game.connectionWindowRect = new Rect(leftIndent, topIndent, 597.0f, 145.0f);
			GUI.Box (Game.connectionWindowRect, "", Game.ConfirmationWindowStyle);

			GUI.Label(new Rect(leftIndent + 80, topIndent + 50, 300, 280), caption, Game.ConfirmationWindowTextStyle);

			if(GUI.Button(new Rect(leftIndent + 100, topIndent + 90, 80, 30), "Ok"))
			{
				bIsActive = false;
				actionToPerform();
			}
		}
	}
	
	public void Set(string text, void0param _f)
	{
		bIsActive = true;
		SetCaption(text);
		actionToPerform = _f;
	}
	
	public void SetCaption(string _caption)
	{
		caption = _caption;	
	}
}
