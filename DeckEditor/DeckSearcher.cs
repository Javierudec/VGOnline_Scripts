using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DeckSearcher {
	private Texture2D _Background;
	public AdvancedSearch _AdvancedSearch;
	private DeckEditorManager _DeckEditor;
	private float _w = 243.0f;
	private float _h = 544.0f;
	private float _x = 0.0f;
	private float _y = 0.0f;
	private int MaxCardList = 8;
	private GUIStyle UpArrowStyle;
	private GUIStyle DownArrowStyle;
	
	private int CurrentPosition = 4;

	private List<Card2D> CardListRight;
	private List<Card2D> CardListLeft;
	public List<Card2D> LastResult;
	
	private float xCorr = 1.0f;
	private float yCorr = 1.0f;
	
	public DeckSearcher(float x, float y, DeckEditorManager deck)
	{
		_DeckEditor = deck;
		
		xCorr = _DeckEditor._xWindowScale;
		yCorr = _DeckEditor._yWindowScale;
		
		_x = x;
		_y = y;
		
		_Background = Resources.Load ("DeckEditor/SearchResult") as Texture2D;
		
		_AdvancedSearch = new AdvancedSearch(800.0f, 0.0f, deck, this);
		
		CardListRight = new List<Card2D>();
		CardListLeft = new List<Card2D>();
		/*
		LastResult = _AdvancedSearch.Query(SearchQuery.ALL);
		LastResult = _AdvancedSearch.FilterBy(SearchQuery.BYCLAN, LastResult);
		
		LoadCardList();
		*/
		UpArrowStyle = new GUIStyle();
		UpArrowStyle.normal.background = Resources.Load ("DeckEditor/UpArrow") as Texture2D;
		DownArrowStyle = new GUIStyle();
		DownArrowStyle.normal.background = Resources.Load ("DeckEditor/DownArrow") as Texture2D;
	}
	
	public void LoadCardList()
	{
		CardListLeft.Clear();
		CardListRight.Clear();
		
		int minIndex = MaxCardList;
		if(minIndex > LastResult.Count)
		{	
			minIndex = LastResult.Count;
		}
		
		for(int i = 0; i < MaxCardList; i += 2)
		{
			if(i < LastResult.Count)
			{
				CardListLeft.Add (LastResult[i]);

			}

			if((i + 1) < LastResult.Count)
			{
				CardListRight.Add (LastResult[i + 1]);	
			}
		}
		
		CurrentPosition = 4;
	}
	
	public void Draw()
	{
		GUI.DrawTexture(new Rect(_x * xCorr, _y * yCorr, _w * xCorr, _h * yCorr), _Background);
		
		DrawCardListed();
		
		if(GUI.Button(new Rect((_x + _w - 28.0f - 5.0f) * xCorr, (_y + 5.0f) * yCorr, 28.0f * xCorr, 28.0f * yCorr), "", UpArrowStyle))
		{
			UpList();
		}
		
		if(GUI.Button (new Rect((_x + _w - 28.0f - 5.0f) * xCorr, (_y + _h - 5.0f - 28.0f) * yCorr, 28.0f * xCorr, 28.0f * yCorr), "", DownArrowStyle))
		{
			DownList();
		}
		_AdvancedSearch.Draw();
		
	}
	
	private void UpList()
	{		
		if(CurrentPosition == 4)
			return;
		
		int removeAt = MaxCardList/2 - 1;
		if(removeAt < CardListRight.Count)
			CardListRight.RemoveAt(MaxCardList/2 - 1);
		
		if(removeAt < CardListLeft.Count)
			CardListLeft.RemoveAt(MaxCardList/2 - 1);
		
		int nextLeft = (CurrentPosition - 5) * 2;
		int nextRight = nextLeft + 1;
			
		CurrentPosition--;
		
		if(nextLeft >= 0)
		{
			CardListLeft.Insert(0, LastResult[nextLeft]);
		}
		
		if(nextRight >= 0)
		{
			CardListRight.Insert (0, LastResult[nextRight]);
		}
		
	}
	
	private void DownList()
	{

		
		int nextLeft = CurrentPosition * 2;
		int nextRight = nextLeft + 1;
			
		
		
		bool bRemove = false;
		
		if(nextLeft < LastResult.Count)
		{
			bRemove = true;
			CardListLeft.Add (LastResult[nextLeft]);
		}
		
		if(nextRight < LastResult.Count)
		{
			bRemove = true;
			CardListRight.Add (LastResult[nextRight]);
		}
		
		if(bRemove)
		{
			CurrentPosition++;
			CardListRight.RemoveAt(0);
			CardListLeft.RemoveAt(0);
		}
	}
	
	public void Update()
	{
		if(!_DeckEditor._DeckInformation.decklist.IsOpen()
		   && !_AdvancedSearch._ClanPopupList.IsOpen())
		{
			float scrollMovement = Input.GetAxis("Mouse ScrollWheel");
			if(scrollMovement < 0)
			{
				DownList();
			}
			else if(scrollMovement > 0)
			{
				UpList();
			}
		}

		for(int i = 0; i < CardListLeft.Count; i++)
		{
			CardListLeft[i].Update();	
		}
		
		for(int i = 0; i < CardListRight.Count; i++)
		{
			CardListRight[i].Update();	
		}
	}
	
	private void DrawCardListed()
	{
		for(int i = 0; i < CardListLeft.Count; i++)
		{
			CardListLeft[i].DrawAt((_x + 23.0f) * xCorr, ((_y + 15.0f) * yCorr + (CardListLeft[i].GetHeight() + 8.0f * yCorr) * i));
		}
		
		for(int i = 0; i < CardListRight.Count; i++)
		{
			CardListRight[i].DrawAt(((_x + 23.0f) * xCorr + CardListRight[i].GetWidth() + 15.0f * xCorr), ((_y + 15.0f) * yCorr + (CardListRight[i].GetHeight() + 8.0f * yCorr) * i));
		}
	}
}
