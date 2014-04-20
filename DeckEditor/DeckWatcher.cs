using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DeckWatcher : MonoBehaviour {
	private Texture2D _Background;
	private float _w = 460.0f;
	private float _h = 691.0f;
	private float _x = 0.0f;
	private float _y = 0.0f;
	public List<Card2D> _DeckList;
	private DeckEditorManager _DeckEditor;
	public string LastError = "";
	
	private float xCorr = 1.0f;
	private float yCorr = 1.0f;
	
	public DeckWatcher(float x, float y, DeckEditorManager deck)
	{
		_DeckEditor = deck;
		
		xCorr = _DeckEditor._xWindowScale;
		yCorr = _DeckEditor._yWindowScale;
		
		_x = x;
		_y = y;
		_Background = Resources.Load ("DeckEditor/DeckWatcher") as Texture2D;
		_DeckList = new List<Card2D>();
	}
	
	public void AddCard(Card2D card)
	{
		_DeckList.Add(card);
		card.Scale(0.65f);
		card.bInDeck = true;
	}

	public void SortDeck()
	{
		_DeckList.Sort(delegate(Card2D x, Card2D y) {
			if(y._CardInfo.grade < x._CardInfo.grade)
			{
				return -1;
			}
			else if(y._CardInfo.grade == x._CardInfo.grade)
			{
				return -y._CardInfo.name.CompareTo(x._CardInfo.name);
			}
			else
			{
				return 1;
			}
		});
	}

	public void Update()
	{
		for(int i = 0; i < _DeckList.Count; i++)
		{
			_DeckList[i].Update();
		}
	}
	
	public float GetWidth()
	{
		return _w;	
	}
	
	public float GetHeight()
	{
		return _h;	
	}
	
	public void Draw()
	{
		GUI.DrawTexture(new Rect(_x * xCorr, _y * yCorr, _w * xCorr, _h * yCorr), _Background);
		GUI.Label (new Rect((_x + 100.0f) * xCorr, (_y + _h - 80) * yCorr, 250 * xCorr, 50 * yCorr), "<= This card will be your initial vanguard.");
		
		int curIndex = 0;
		for(int i = 0; i < 10; i++)
		{
			for(int j = 0; j < 7; j++)
			{
				if(curIndex < _DeckList.Count)
				{
					_DeckList[curIndex].DrawAt(((_x + 15.0f) * xCorr + (_DeckList[curIndex].GetWidth() + 2.0f) * j),
						                       ((_y + 15.0f) * yCorr + (_DeckList[curIndex].GetHeight() + 2.0f) * i));
					curIndex++;
				}
				else
				{
					break;	
				}
			}
		}
	}
	
	public bool MouseOn()
	{
		float mX = Input.mousePosition.x;
		float mY = Input.mousePosition.y;
		float cX = _x; 
		float cY = Screen.height - (_y + GetHeight());
				
		if((mX > cX) &&
		   (mY > cY) && 
		   (mX < (cX + GetWidth() * xCorr)) && 
		   (mY < (cY + GetHeight() * yCorr))
		   )
		{
			return true;	
		}
		
		return false;
	}
	
	public bool SaveDeck(string name)
	{
		if(name == "")
		{
			LastError = "Deck name cannot be empty";
			
			return false;	
		}
		
		if(_DeckEditor._DeckInformation.numCards != 50)
		{
			LastError = "Your deck must contains 50 cards.";
			
			return false;	
		}
		
		if(_DeckList[_DeckList.Count - 1]._CardInfo.grade != 0)
		{
			LastError = "Your initial vanguard must be grade 0";
			
			return false;
		}
		
		if(_DeckEditor._DeckInformation.numTriggers != 16)
		{
			LastError = "\nA deck must contains exactly 16 Trigger Units.";
			
			return false;
		}
		
		if(!Directory.Exists("Deck"))
		{
			Directory.CreateDirectory("Deck");	
		}
		
		StreamWriter writer = new StreamWriter("Deck/" + name + ".cfd");
		for(int i = 0; i < _DeckList.Count; i++)
		{
			writer.WriteLine((int)_DeckList[i]._CardInfo.cardID);	
		}
		
		writer.Close();
		
		_DeckEditor._DeckInformation.ReloadDeckList();
		_DeckEditor._DeckInformation.decklist.SelectOptionWithValue(name);
		return true;
	}
	
	public void LoadDeck(string name)
	{
		StreamReader reader = new StreamReader("Deck/" + name + ".cfd");
		
		_DeckEditor._DeckInformation.numGrade0 = 0;
		_DeckEditor._DeckInformation.numGrade1 = 0;
		_DeckEditor._DeckInformation.numGrade2 = 0;
		_DeckEditor._DeckInformation.numGrade3 = 0;
		_DeckEditor._DeckInformation.numCards = 0;
		_DeckEditor._DeckInformation.numTriggers = 0;
		_DeckEditor._DeckInformation.numHealTriggers = 0;
		
		for(int i = 0; i < _DeckEditor._DeckInformation.CardList.Length; i++)
		{
			_DeckEditor._DeckInformation.CardList[i] = 0;	
		}
		
		while(reader.Peek() != -1)
		{
			string line = reader.ReadLine();
			int id = int.Parse(line);
			
			CardInformation info = _DeckEditor._DeckSearcher._AdvancedSearch._Data.GetCardInfo((CardIdentifier)id);
			
			_DeckEditor._DeckInformation.CardList[(int)info.cardID]++;
			
			if(info.grade == 0)
				_DeckEditor._DeckInformation.numGrade0++;
			else if(info.grade == 1)
				_DeckEditor._DeckInformation.numGrade1++;
			else if(info.grade == 2)
				_DeckEditor._DeckInformation.numGrade2++;
			else if(info.grade == 3)
				_DeckEditor._DeckInformation.numGrade3++;
			
			_DeckEditor._DeckInformation.numCards++;
			
			if(info.trigger != TriggerIcon.NONE)
			{
				_DeckEditor._DeckInformation.numTriggers++;	
			}
			
			if(info.trigger == TriggerIcon.HEAL)
			{
				_DeckEditor._DeckInformation.numHealTriggers++;	
			}
			
			AddCard(new Card2D(info, _DeckEditor));
		}
		reader.Close();
		
		//_DeckEditor._DeckInformation.decklist.SelectOptionWithValue(name);
		
		PlayerPrefs.SetString("DefaultDeck", name);
	}
}
