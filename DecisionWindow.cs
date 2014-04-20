using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecisionWindow {
	Card source;
	string caption;
	bool bIsActive = false;
	Gameplay Game = null;
	int id = -1;

	public DecisionWindow(int _xPos, int _yPos)
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

			if(GUI.Button(new Rect(leftIndent + 100, topIndent + 90, 80, 30), "Accept"))
			{
				bIsActive = false;

				if(Util.IsEnemyPosition(source.pos))
				{
					Game.SendPacket (GameAction.DECISIONWINDOW_ACCEPT, source.pos, id);
					Game.bEffectOnGoing = false;
				}
			}

			if(GUI.Button(new Rect(leftIndent + 400, topIndent + 90, 80, 30), "Cancel"))
			{			
				bIsActive = false;

				if(Util.IsEnemyPosition(source.pos))
				{
					Game.SendPacket (GameAction.DECISIONWINDOW_DENIED, source.pos, id);
					Game.bEffectOnGoing = false;
				}
			}
		}
	}
	
	public void Set(Card _source, int _id = -1)
	{
		id = _id;
		source = _source;
		bIsActive = true;

		if(Util.IsEnemyPosition(source.pos))
		{
			Game.bEffectOnGoing = true;
		}
	}
	
	public void SetCaption(string _caption)
	{
		caption = _caption;	
	}
}
