using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVarAdvSearch {
	public static bool dropDownListOpen;
}

public class AdvancedSearch {
	private Texture2D _Background;
	private float _w = 235.0f;
	private float _h = 229.0f;
	private float _x = 0.0f;
	private float _y = 0.0f;
	public CardDataBase _Data;
	private List<CardInformation> AllCards;
	private DeckEditorManager _DeckEditor;
	private DeckSearcher _DeckSearcher;
	private string SearchByName = "";
	private string SearchByClan = "Royal Paladin";
	private int SearchByGrade = 0;
	public PopupList _DropDownList;
	public PopupList _ClanPopupList;
	private float xScale = 1.0f;
	private float yScale = 1.0f;
	
	public AdvancedSearch(float x, float y, DeckEditorManager deck, DeckSearcher searcher)
	{
		GlobalVarAdvSearch.dropDownListOpen = false;

		_DeckSearcher = searcher;
		_DeckEditor = deck;
		/*
		_w *= _DeckEditor._xWindowScale;
		_h *= _DeckEditor._yWindowScale;
		*/
		
		xScale = _DeckEditor._xWindowScale;
		yScale = _DeckEditor._yWindowScale;
		
		_x = x;
		_y = y;
		_Background = Resources.Load ("DeckEditor/AdvancedSearch") as Texture2D;
		_Data = new CardDataBase();
		AllCards = _Data.GetAllCards();
		
		_DropDownList = new PopupList((int)(_x + 80.0f), (int)(_y + 30.0f + 25.0f), 130, 20, 5);
		_DropDownList.Add("All");
		_DropDownList.Add("0");
		_DropDownList.Add("1");
		_DropDownList.Add("2");
		_DropDownList.Add("3");
		_DropDownList.Add("4");

		_ClanPopupList = new PopupList((int)(_x + 80), (int)(_y + 115), 130, 20, 5);
		_ClanPopupList.SetSliderYFactor(16.7f);
		_ClanPopupList.Add("All");
		_ClanPopupList.Add("Angel Feather");
		_ClanPopupList.Add("Aqua Force");
		_ClanPopupList.Add("Bermuda Triangle");
		_ClanPopupList.Add("Dark Irregulars");
		_ClanPopupList.Add("Dimension Police");
		_ClanPopupList.Add("Genesis");
		_ClanPopupList.Add("Gold Paladin");
		_ClanPopupList.Add("Granblue");
		_ClanPopupList.Add("Great Nature");
		_ClanPopupList.Add("Kagero");
		_ClanPopupList.Add("Link Joker");
		_ClanPopupList.Add("Megacolony");
		_ClanPopupList.Add("Murakumo");
		_ClanPopupList.Add("Narukami");
		_ClanPopupList.Add("Neo Nectar");
		_ClanPopupList.Add("Nova Grappler");
		_ClanPopupList.Add("Nubatama");
		_ClanPopupList.Add("Oracle Think Tank");
		_ClanPopupList.Add("Pale Moon");
		_ClanPopupList.Add("Royal Paladin");
		_ClanPopupList.Add("Shadow Paladin");
		_ClanPopupList.Add("Spike Brothers");
		_ClanPopupList.Add("Tachikaze");
	}
	
	public void Draw()
	{
		GUI.DrawTexture(new Rect(_x * xScale, _y * yScale, _w * xScale, _h * yScale), _Background);	
		
		GUI.Label(new Rect((_x + 15.0f) * xScale, (_y + 15.0f) * yScale, 75.0f * xScale, 50.0f * yScale), "Name: ");
		SearchByName = GUI.TextField(new Rect((_x + 80.0f) * xScale, (_y + 15.0f) * yScale, 125.0f * xScale, 25.0f * yScale), SearchByName);
		
		GUI.Label (new Rect((_x + 15.0f) * xScale, (_y + 30.0f + 25.0f) * yScale, 75.0f * xScale, 50.0f * yScale), "Grade: ");
		GUI.Label (new Rect((_x + 15.0f) * xScale, (_y + 80.0f + 25.0f) * yScale, 75.0f * xScale, 50.0f * yScale), "Clan: ");
		
		
		if(!_ClanPopupList.IsOpen() && GUI.Button(new Rect((_x + 60.0f) * xScale, (_y + _h - 25.0f - 15.0f) * yScale, 100.0f * xScale, 25.0f * yScale), "Search"))
		{
			_DeckSearcher.LastResult = Query(SearchQuery.ALL);
			
			_DeckSearcher.LastResult = FilterBy (SearchQuery.BYNAME, _DeckSearcher.LastResult);
			
			if(_DropDownList.GetValue() != "All")
			{
				SearchByGrade = int.Parse(_DropDownList.GetValue());
				_DeckSearcher.LastResult = FilterBy (SearchQuery.BYGRADE, _DeckSearcher.LastResult);
			}
			
			if(_ClanPopupList.GetValue() != "All")
			{
				SearchByClan = _ClanPopupList.GetValue();
				_DeckSearcher.LastResult = FilterBy (SearchQuery.BYCLAN, _DeckSearcher.LastResult);
			}
			
			_DeckSearcher.LoadCardList();
		}
		
		//_ClanList.Draw();
		if(!_DropDownList.IsOpen())
		{
			_ClanPopupList.Render();
		}

		_DropDownList.Render();
	}
	
	public List<Card2D> Query(SearchQuery sq)
	{
		List<Card2D> result = new List<Card2D>();
		
		for(int i = 0; i < AllCards.Count; i++)
		{
			if(sq == SearchQuery.ALL)
			{
				result.Add (new Card2D(AllCards[i], _DeckEditor));	
			}
		}
		
		return result;
	}
	
	public List<Card2D> FilterBy(SearchQuery sq, List<Card2D> source)
	{
		List<Card2D> result = new List<Card2D>();
		
		for(int i = 0; i < source.Count; i++)
		{
			if(sq == SearchQuery.BYNAME)
			{
				if(source[i]._CardInfo.name.Contains(SearchByName))
				{
					result.Add (new Card2D(source[i]._CardInfo, _DeckEditor));	
				}
			}
			else if(sq == SearchQuery.BYGRADE)
			{
				if(source[i]._CardInfo.grade == SearchByGrade)
				{
					result.Add (new Card2D(source[i]._CardInfo, _DeckEditor));	
				}
			}
			else if(sq == SearchQuery.BYCLAN)
			{
				if(source[i]._CardInfo.clan == SearchByClan)
				{
					result.Add (new Card2D(source[i]._CardInfo, _DeckEditor));	
				}
			}
		}

		result.Sort(delegate(Card2D x, Card2D y) {
			return x._CardInfo.name.CompareTo(y._CardInfo.name);
		});

		return result;
	}
}

public enum SearchQuery
{
	ALL,
	BYNAME,
	BYGRADE,
	BYCLAN
}