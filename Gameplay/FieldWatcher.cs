using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldWatcher {
	public delegate bool filterDelegate(Card c);
	public delegate void actionDelegate(Card c);
	public delegate void onCloseDelegate();

	actionDelegate performAction = null;
	onCloseDelegate onCloseAction = null;

	List<Card> cList = new List<Card>();
	List<Game2DCard> gList = new List<Game2DCard>();

	Gameplay game = null;

	bool bIsActive = false;
	bool bIsExitEnabled = true;

	float x = Screen.width / 2 - 300 + 160;
	float y = Screen.height / 2 - 63;

	int indexOffset = 0;

	GUIStyle exitBtnStyle = new GUIStyle();
	GUIStyle leftArrowBtnStyle = new GUIStyle();
	GUIStyle rightArrowBtnStyle = new GUIStyle();

	Texture2D backgroundTexture;

	int maxCardsToView = 8;

	public FieldWatcher(Gameplay _game)
	{
		game = _game;
		backgroundTexture = Resources.Load("ViewCardBackground") as Texture2D;

		exitBtnStyle.normal.background = Resources.Load("GUI/exit") as Texture2D;
		exitBtnStyle.hover.background  = Resources.Load("GUI/exit_hover") as Texture2D;

		leftArrowBtnStyle.normal.background = Resources.Load("GUI/left_arrow") as Texture2D;
		leftArrowBtnStyle.hover.background  = Resources.Load("GUI/left_arrow_hover") as Texture2D;
		
		rightArrowBtnStyle.normal.background = Resources.Load("GUI/right_arrow") as Texture2D;
		rightArrowBtnStyle.hover.background  = Resources.Load("GUI/right_arrow_hover") as Texture2D;

		Reset();
	}

	public void Open()
	{
		bIsActive = true;
	}

	public void Close(bool bDestroyList = false)
	{
		bIsActive = false;
		game.bBlockMouseOnce = true;

		if(bDestroyList)
		{
			DestroyList();
		}
	}

	public void SetIsExitEnabled(bool b)
	{
		bIsExitEnabled = b;
	}

	public void DestroyList()
	{
		if(onCloseAction != null)
		{
			onCloseAction();
		}
	}

	public bool IsActive()
	{
		return bIsActive;
	}

	public void Reset()
	{
		cList.Clear();
		gList.Clear();
		onCloseAction = null;
		performAction = null;
		bIsExitEnabled = true;
	}

	public void AddCardList(List<Card> cList)
	{
		foreach(Card c in cList)
		{
			this.cList.Add(c);
			gList.Add(new Game2DCard(game.Data.GetCardInfo(c.cardID)));
		}
	}

	public void SetActionToPerform(actionDelegate perform)
	{
		performAction = perform;
	}

	public void SetOnCloseEvent(onCloseDelegate function)
	{
		onCloseAction = function;
	}

	public void Filter(filterDelegate filterMethod)
	{
		for(int i = 0; i < cList.Count; i++)
		{
			Card c = cList[i];

			if(!filterMethod(c))
			{
				cList.RemoveAt(i);
				gList.RemoveAt(i);
			}
		}
	}

	public void RemoveFromList(Card c)
	{
		int index = cList.IndexOf(c);
		cList.RemoveAt(index);
		gList.RemoveAt(index);
	}

	public void Draw()
	{
		if(!bIsActive)
		{
			return;
		}

		GUI.DrawTexture(new Rect(x, y, 600, 146), backgroundTexture);
			
		int limit = indexOffset + maxCardsToView;
		if(limit > gList.Count)
		{
			limit = gList.Count;
		}

		for(int i = indexOffset; i < limit; i++)
		{
			gList[i].DrawAt(x + (gList[i].GetWidth() + 5) * (i - indexOffset) + 45, 
			                y + 30); 	
		}
			
		if(GUI.Button(new Rect(x - 5, y + 50, 38, 38), "", leftArrowBtnStyle))
		{
			indexOffset--;
			if(indexOffset < 0)
			{
				indexOffset = 0;
			}
		}

		if(GUI.Button(new Rect(x + 570, y + 50, 38, 38), "", rightArrowBtnStyle))
		{
			indexOffset++;
			if((indexOffset + maxCardsToView) >= gList.Count)
			{
				indexOffset = gList.Count - maxCardsToView;
			}
		}

		if(bIsExitEnabled && GUI.Button (new Rect(x + 575, y - 5, 28, 28), "", exitBtnStyle))
		{
			Close(true);
		}
	}

	public void Update()
	{
		if(!bIsActive)
		{
			return;
		}

		for(int i = 0; i < gList.Count; i++) 
		{
			if(Util.MouseOn(gList[i]._x, 
			                gList[i]._y, 
			                gList[i].GetWidth(), 
			                gList[i].GetHeight(), 
			                Input.mousePosition)
			   )
			{
				game._CardMenuHelper.SetCard(gList[i]._CardInfo.cardID);

				if(ActionCanBePerformed())
				{
					if(performAction != null)
					{
						performAction(cList[i]);
					}
				}
			}
		}
	}

	public bool ActionCanBePerformed()
	{
		return Input.GetMouseButtonDown(0);
	}
}
