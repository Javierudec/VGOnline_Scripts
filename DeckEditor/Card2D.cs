using UnityEngine;
using System.Collections;

public class Card2D {
	private float _cardWidth = 300.0f;
	private float _cardHeight = 440.0f;
	private Texture2D texture;
	public CardInformation _CardInfo;
	private float _x;
	private float _y;
	private DeckEditorManager _DeckEditor;
	public bool bInDeck = false;
	
	public Card2D(CardInformation cardInfo, DeckEditorManager deck)
	{
		_DeckEditor = deck;
		_CardInfo = cardInfo;
		texture = Resources.Load ("CardHelper/" + _CardInfo.clan + "/" + _CardInfo.mat) as Texture2D;
		_cardWidth  *= 0.28f * _DeckEditor._xWindowScale;
		_cardHeight *= 0.28f * _DeckEditor._yWindowScale;
	}
	
	public void DrawAt(float x, float y)
	{
		_x = x;
		_y = y;
		GUI.DrawTexture(new Rect(x, y, _cardWidth, _cardHeight), texture); 	 
	}
	
	public void Scale(float value)
	{
		_cardWidth *= value;
		_cardHeight *= value;
	}
	
	public float GetHeight()
	{
		return _cardHeight;	
	}
	
	public float GetWidth()
	{
		return _cardWidth;	
	}
	
	public void Update()
	{
		bool bMouseOn = false;
		
		if(MouseOn ())
		{
			_DeckEditor._CardHelper.SetCard(_CardInfo.cardID);
			bMouseOn = true;
		}
		
		if(Input.GetMouseButtonDown(0))
		{
			if(bMouseOn && !_DeckEditor.bCardDragged && !_DeckEditor._DeckInformation.decklist.IsOpen() &&
			  !_DeckEditor._DeckSearcher._AdvancedSearch._DropDownList.IsOpen() &&
			  !_DeckEditor._DeckSearcher._AdvancedSearch._ClanPopupList.IsOpen())
			{
				if(!bInDeck)
				{
					if(_DeckEditor._DeckInformation.CardList[(int)_CardInfo.cardID] < _DeckEditor._DeckInformation.CardLimit[(int)_CardInfo.cardID])
					{
						
						if(_CardInfo.trigger != TriggerIcon.NONE)
						{
							if(_DeckEditor._DeckInformation.numTriggers >= 16)
							{
								return;	
							}
						}
						
						if(_CardInfo.trigger == TriggerIcon.HEAL)
						{
							if(_DeckEditor._DeckInformation.numHealTriggers >= 4)
							{
								return;	
							}
						}
						
						if(_DeckEditor._CardHelper.GetDesc().Contains("Sentinel"))
						{
							if(_DeckEditor._DeckInformation.numSentinels >= 4)
							{
								return;	
							}
						}
						
						_DeckEditor._DraggedCard = new Card2D(_CardInfo, _DeckEditor);
						_DeckEditor.bCardDragged = true;
						_DeckEditor.v2CardDraggedOffset = new Vector2(Input.mousePosition.x - _x, Screen.height - Input.mousePosition.y - _y);
					}
				}
				else
				{
					_DeckEditor._DraggedCard = new Card2D(_CardInfo, _DeckEditor);
					_DeckEditor.bCardDragged = true;
					_DeckEditor.v2CardDraggedOffset = new Vector2(Input.mousePosition.x - _x, Screen.height - Input.mousePosition.y - _y);	
					_DeckEditor._DeckWatcher._DeckList.Remove(this);
					_DeckEditor._DeckInformation.numCards--;
					if(_DeckEditor._DraggedCard._CardInfo.grade == 0)
						_DeckEditor._DeckInformation.numGrade0--;
					else if(_DeckEditor._DraggedCard._CardInfo.grade == 1)
						_DeckEditor._DeckInformation.numGrade1--;
					else if(_DeckEditor._DraggedCard._CardInfo.grade == 2)
						_DeckEditor._DeckInformation.numGrade2--;
					else if(_DeckEditor._DraggedCard._CardInfo.grade == 3)
						_DeckEditor._DeckInformation.numGrade3--;
					_DeckEditor._DeckInformation.CardList[(int)_CardInfo.cardID]--;
				
					if(_CardInfo.trigger != TriggerIcon.NONE)
					{
						_DeckEditor._DeckInformation.numTriggers--;	
					}
					
					if(_CardInfo.trigger == TriggerIcon.HEAL)
					{
						_DeckEditor._DeckInformation.numHealTriggers--;	
					}
					
					if(_DeckEditor._CardHelper.GetDesc().Contains("Sentinel"))
					{
						_DeckEditor._DeckInformation.numSentinels--;	
					}
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
		   (mX < (cX + GetWidth())) && 
		   (mY < (cY + GetHeight()))
		   )
		{
			return true;	
		}
		
		return false;
	}
}
