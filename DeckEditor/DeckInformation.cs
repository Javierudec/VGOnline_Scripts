using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class DeckInformation : MonoBehaviour {
	private Texture2D _Background;
	private float _w = 462.0f;
	private float _h = 85.0f;
	private float _x = 0.0f;
	private float _y = 0.0f;
	public int numCards = 0;
	public int numGrade0 = 0;
	public int numGrade1 = 0;
	public int numGrade2 = 0;
	public int numGrade3 = 0;
	private DeckEditorManager _DeckEditor;
	//public DropDownList decklist = null;
	public PopupList decklist;
	
	private int CurrentSelected = -1;
	private int LastSelected = -1;
	
	private float xCorr = 1.0f;
	private float yCorr = 1.0f;
	
	private GUIStyle textStyle = null;
	
	public int[] CardList;
	public int[] CardLimit;	
	public int numTriggers = 0; //max 16
	public int numHealTriggers = 0; //max 4
	public int numSentinels = 0; //max 4

	public RestrictedCardList restrictedList = null;

	public DeckInformation(float x, float y, DeckEditorManager deck)
	{
		restrictedList = new RCL_Official();
		restrictedList.SetDeckInformation(this);

		CardList = new int[Enum.GetNames(typeof(CardIdentifier)).Length];
		CardLimit = new int[Enum.GetNames(typeof(CardIdentifier)).Length];
		
		for(int i = 0; i < CardList.Length; i++)
		{
			CardList[i] = 0;
			CardLimit[i] = 4;
		}

		CardLimit[(int)CardIdentifier.MASS_PRODUCTION_SAILOR] = 16;
		
		_DeckEditor = deck;
		
		xCorr = _DeckEditor._xWindowScale;
		yCorr = _DeckEditor._yWindowScale;
		
		textStyle = new GUIStyle();
		textStyle.fontSize = (int)(15  * xCorr);
		textStyle.normal.textColor = Color.white;
		
		_x = x;
		_y = y;
		_Background = Resources.Load ("DeckEditor/DeckInformation") as Texture2D;
		
		
		if(!Directory.Exists("Deck"))
		{
			Directory.CreateDirectory("Deck");	
		}
		
		string[] deckNames = Directory.GetFiles("Deck");
		
		bool bAddDummy = false;
		int len = deckNames.Length;
		if(len == 0) 
		{
			bAddDummy = true;
			len++;
		}

		decklist = new PopupList((int)(_x + (15.0f + 230.0f)), (int)(_y + (40.0f)), 200, 20, 5);
		//decklist.SetSliderYFactor((16.8f/24.0f) * decklist.GetNumOptions());

		for(int i = 0; i < deckNames.Length; i++)
		{
			decklist.Add(deckNames[i].Substring(5, deckNames[i].Length - 5 - 4));
			Debug.Log (deckNames[i].Substring(5, deckNames[i].Length - 5 - 4));
		}
		
		if(bAddDummy)
		{
			decklist.Add("No deck");	
		}
		
		string defaultDeck = PlayerPrefs.GetString("DefaultDeck");
			
		if(defaultDeck != "")
		{
			decklist.SelectOptionWithValue(defaultDeck);
		}


		_DeckEditor.DeckName = decklist.GetValue();
		//decklist.GetValue();
	}
	
	public void Update()
	{
		CurrentSelected = decklist.GetID ();
			
		if(CurrentSelected != LastSelected)
		{
			if(decklist.GetValue() != "No deck")
			{
				_DeckEditor._DeckWatcher._DeckList.Clear();
				_DeckEditor._DeckWatcher.LoadDeck(decklist.GetValue());
				_DeckEditor.DeckName = decklist.GetValue();
			}
			LastSelected = CurrentSelected;
		}
	}
	
	public void ReloadDeckList()
	{
		string[] deckNames = Directory.GetFiles("Deck");
		
		decklist = new PopupList((int)(_x + (15.0f + 230.0f)), (int)(_y + (40.0f)), 200, 20, 5);
		//decklist.SetSliderYFactor((16.8f/24.0f) * decklist.GetNumOptions());
		for(int i = 0; i < deckNames.Length; i++)
		{
			decklist.Add(deckNames[i].Substring(5, deckNames[i].Length - 5 - 4));
		}	
	}
	
	public void Draw()
	{
		GUI.DrawTexture(new Rect(_x * xCorr, _y * yCorr, _w * xCorr, _h * yCorr), _Background);	
		GUI.Label(new Rect((_x + 15.0f) * xCorr, (_y + 10.0f) * yCorr, 100.0f * xCorr, 50.0f * yCorr), "Num. cards: " + numCards, textStyle);
		
		GUI.Label(new Rect((_x + 15.0f) * xCorr, (_y + 25.0f) * yCorr, 100.0f * xCorr, 50.0f * yCorr), "G0: " + numGrade0, textStyle);
		GUI.Label(new Rect((_x + 15.0f + 70.0f) * xCorr, (_y + 25.0f) * yCorr, 100.0f * xCorr, 50.0f * yCorr), "G1: " + numGrade1, textStyle);
		GUI.Label(new Rect((_x + 15.0f + 140.0f) * xCorr, (_y + 25.0f) * yCorr, 100.0f * xCorr, 50.0f * yCorr), "G2: " + numGrade2, textStyle);
		GUI.Label(new Rect((_x + 15.0f + 210.0f) * xCorr, (_y + 25.0f) * yCorr, 100.0f * xCorr, 50.0f * yCorr), "G3: " + numGrade3, textStyle);

		decklist.Render();
		
		if(GUI.Button(new Rect((_x + 15.0f + 330.0f) * xCorr, (_y + 10.0f) * yCorr, 100.0f * xCorr, 25.0f * yCorr), "Clear deck"))
		{
			_DeckEditor._DeckWatcher._DeckList.Clear();
			numCards = 0;
			numGrade0 = 0;
			numGrade1 = 0;
			numGrade2 = 0;
			numGrade3 = 0;
			for(int i = 0; i < _DeckEditor._DeckInformation.CardList.Length; i++)
			{
				_DeckEditor._DeckInformation.CardList[i] = 0;	
			}
			_DeckEditor._DeckInformation.numHealTriggers = 0;
			_DeckEditor._DeckInformation.numSentinels = 0;
			_DeckEditor._DeckInformation.numTriggers = 0;
		}

		if(GUI.Button(new Rect((_x + 15.0f) * xCorr, (_y + 45.0f) * yCorr, 100.0f * xCorr, 25.0f * yCorr), "Sort deck"))
		{
			SortDeck();
		}
	}

	public bool IsCardAllowed(Card2D cardToVerify)
	{
		return restrictedList.IsCardAllowed(cardToVerify);
	}

	public void SortDeck()
	{
		_DeckEditor._DeckWatcher.SortDeck();
	}
}
