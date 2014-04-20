using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DelegateCardNameWindow
{
	public delegate bool f(CardInformation c);
}

public class SelectionCardNameWindow {
	Card owner;
	string caption;
	int xPos, yPos;
	int buttonWidth = 50;
	int buttonHeight = 20;
	bool bIsActive = false;
	List<string> completeNameList;
	List<string> filterNameList;
	string filterCondition;
	string currentSelection;
	int currentID;
	Gameplay _Game;
	DelegateCardNameWindow.f f = null;
	List<CardInformation> completeCardList;
	
	public SelectionCardNameWindow(int _xPos, int _yPos)
	{
		xPos = _xPos;
		yPos = _yPos;
		caption = "No title";
	}
	
	public void SetConstraint(DelegateCardNameWindow.f _f)
	{
		f = _f;	
	}
	
	public void SetGame(Gameplay _G)
	{
		_Game = _G;	
	}
	
	public void Filter(string name)
	{
		string str = name.ToLower();
		filterNameList.Clear();
		for(int i = 0; i < completeNameList.Count; i++)
		{
			if(completeNameList[i].ToLower().Contains(str) && (f == null || f(completeCardList[i])))
			{
				filterNameList.Add(completeNameList[i]);	
			}
		}
		if(filterNameList.Count > 0)
		{
			currentSelection = filterNameList[0];
			currentID = 0;
		}
		else
		{
			currentSelection = "";	
		}
	}
	
	public void Render()
	{
		if(bIsActive)
		{
			GUI.Box(new Rect(xPos, yPos, 400, 200), caption);
			filterCondition = GUI.TextField(new Rect(xPos + 25, yPos + 40, 300, 20), filterCondition);
			GUI.TextArea(new Rect(xPos + 25, yPos + 100, 300, 20), currentSelection);
			
			if(GUI.Button(new Rect(xPos + 310, yPos + 40, buttonWidth, buttonHeight), "Filter"))
			{
				Filter (filterCondition);
			}
			
			if((currentID > 0) && GUI.Button(new Rect(xPos + 310, yPos + 100, buttonWidth, buttonHeight), "UP"))
			{
				currentID--;
				currentSelection = filterNameList[currentID];
			}
			
			if((currentID < (filterNameList.Count - 1)) && GUI.Button(new Rect(xPos + 310, yPos + 120, buttonWidth, buttonHeight), "DOWN"))
			{
				currentID++;
				currentSelection = filterNameList[currentID];
			}
			
			if(GUI.Button(new Rect(xPos + 150, yPos + 160, 100, 30), "OK"))
			{
				bIsActive = false;
				_Game.SendPacket(GameAction.MESSAGE, currentSelection + " was declared.");
				owner.unitAbilities.SelectionCardNameOnClose(currentSelection);
			}
		}
	}
	
	public void CreateCardList()
	{
		completeNameList = new List<string>();
		filterNameList = new List<string>();
		completeCardList = new List<CardInformation>();
	}
	
	public void AddNewNameToTheList(CardInformation c)
	{
		completeNameList.Add(c.name);
		completeCardList.Add(c);
	}
	
	public void Set(Card _owner)
	{
		owner = _owner;
		bIsActive = true;
		
		filterNameList.Clear();
		for(int i = 0; i < completeNameList.Count; i++)
		{
			if(f == null || f(completeCardList[i]))
			{
				filterNameList.Add(completeNameList[i]);
			}
		}
		filterCondition = "";
		currentSelection = filterNameList[0];
		currentID = 0;
	}
	
	public void SetCaption(string _caption)
	{
		caption = _caption;	
	}
}
