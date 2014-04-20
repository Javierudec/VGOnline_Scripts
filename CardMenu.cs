using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardMenu {
	private Card _Card;
	private bool bOpen = false; 
	private float _x = 500.0f;
	private float _y = 200.0f;
	private float _w;
	private float _h;
	private Texture2D OptionNormal;
	private Texture2D OptionSelected;
	private Gameplay _Game;
	private int iSelectedCard;
	private int num_options;
	private List<string> optionNames;
	private List<ClickFunction> function;
	private Camera _Camera;
	private float _customW = 0;
	private bool bIgnore = false;
	
	public CardMenu(Gameplay Game)
	{
		_Game = Game;
		OptionNormal = Resources.Load ("CardMenuNormal") as Texture2D;
		OptionSelected = Resources.Load("CardMenuSelected") as Texture2D;

		_w = 285.0f * 0.24f;
		_h = 43.0f * 0.45f;
		optionNames = new List<string>();
		function = new List<ClickFunction>();
		
		_Camera = (Camera)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Camera");
	}
	
	public void OpenDeckMenu(Card card)
	{
		_Card = card;
		bOpen = true;
		iSelectedCard = 0;
		_Game.playerHand.bBlockHand = false;
		
		num_options = 0;
		_customW = 20;

		_Game.playerDeck.RemoveFromDeck(card);
		SetOption("Put on top");
		SetOption("Put on bottom");
		
		Vector3 pos = _Camera.WorldToScreenPoint(card.GetGameObject().transform.position);
		_x = pos.x + 10.0f;
		_y = Camera.main.pixelHeight - pos.y - 50.0f;
		_Game.bBlockMouse = true;
		
		_Game._CardMenuHelper.SetCard(card.cardID);
		
	}
	
	public void OpenOnDropList(Card card, float mx, float my)
	{
		bOpen = true;
		bIgnore = true;
		num_options = 0;
		iSelectedCard = 0;
		_Card = card;
		
		if(card.unitAbilities.HasOnDropEffect() > 0)
		{
			SetOption("Activate");	
		}
		
		SetOption("Cancel");
		_x = mx;
		_y = my;
		_Game.bBlockMouse = true;	
		
		if(num_options == 1)
		{
			Close ();
			_Game.bCardMenuJustClosed = false;
		}
	}
	
	public void OpenOnSoulList(Card card, float mx, float my)
	{
		bOpen = true;
		bIgnore = true;
		num_options = 0;
		iSelectedCard = 0;
		_Card = card;
		
		if(card.unitAbilities.HasOnSoulEffect() > 0)
		{
			SetOption("Activate");	
		}
		
		SetOption("Cancel");
		_x = mx;
		_y = my;
		_Game.bBlockMouse = true;	
		
		if(num_options == 1)
		{
			Close ();
			_Game.bCardMenuJustClosed = false;
		}
	}
	
	public void OpenOnDrop(Card card)
	{
		bOpen = true;
		bIgnore = true;
		num_options = 0;
		iSelectedCard = 0;
		_Card = card;
		SetOption("View Dropzone");
		SetOption("Cancel");
		
		_customW = 30;
		
		Vector3 pos = _Camera.WorldToScreenPoint(card.GetGameObject().transform.position);
		_x = pos.x + 10.0f;
		_y = Camera.main.pixelHeight - pos.y - 50.0f;
		//_Game.bBlockMouse = true;
	}
	
	public void OpenBindMenu(Vector3 position)
	{
		bOpen = true;
		bIgnore = true;
		num_options = 0;
		iSelectedCard = 0;
		SetOption("View Bindzone");
		SetOption("Cancel");
		
		_customW = 30;
		
		Vector3 pos = _Camera.WorldToScreenPoint(position);
		_x = pos.x + 10.0f;
		_y = Camera.main.pixelHeight - pos.y - 50.0f;
		_Game.bBlockMouse = true;
	}
	
	public void Open(Card card)
	{
		bIgnore = true;
		_Card = card;
		bOpen = true;
		iSelectedCard = 0;
		_Game.playerHand.bBlockHand = false;
		
		num_options = 0;
		if(_Card.bIsInhand)
		{
			Card tmpVanguard = _Game.field.GetCardAt(fieldPositions.VANGUARD_CIRCLE);
			if(tmpVanguard.grade >= _Card.grade)
			{
				SetOption("Call");
			}
			
			if(tmpVanguard.grade == _Card.grade || tmpVanguard.grade == (_Card.grade - 1))
			{
				if(_Game.bRideThisTurn && _Card.unitAbilities.CanRide())
				{
					SetOption("Ride");
				}
			}
			
			if(_Card.unitAbilities.HasInHandEffect(_Card))
			{
				SetOption ("Activate");	
			}
		}
		else if(_Card._Coord == CardCoord.DAMAGE)
		{
			if(_Card.unitAbilities.HasOnDamageEffect() > 0)
			{
				SetOption("Activate");	
			}
		}
		else
		{
			//Card is on the field.
			int count = _Card.unitAbilities.HasOnFieldEffect(_Card);
			if(count == 1)
			{
				SetOption("Activate");	
			}
			else if(count > 1)
			{
				for(int i = 1; i <= count; i++)
				{
					SetOption("Activate " + i);	
				}
			}
			
			if(card.IsVanguard() && _Game.field.GetNumberOfCardsInSoul() > 0)
			{
				SetOption("View soul");	
			}
			
			if(card.pos == fieldPositions.REAR_GUARD_LEFT ||
			   card.pos == fieldPositions.REAR_GUARD_RIGHT||
			   card.pos == fieldPositions.FRONT_GUARD_LEFT||
			   card.pos == fieldPositions.FRONT_GUARD_RIGHT)
			{
				Card c = card.unitAbilities.GetSameColum(card.pos);
				if(c == null || !c.IsLocked())
				{	
					SetOption("Move");
				}
			}
		}
		
		SetOption("Cancel");
		
		Vector3 pos = _Camera.WorldToScreenPoint(card.GetGameObject().transform.position);
		_x = pos.x + 10.0f;
		_y = Camera.main.pixelHeight - pos.y - 50.0f;
		//_Game.bBlockMouse = true;
		
		if(num_options == 1)
		{
			Close ();
			_Game.bCardMenuJustClosed = false;
		}
	}
	
	public void SetOption(string name)
	{
		num_options++;
		optionNames.Add(name);	
		
		if(name == "Call")
		{
			function.Add (ClickFunction.CALL);	
		}
		else if(name == "Ride")
		{
			function.Add (ClickFunction.RIDE);	
		}
		else if(name == "Cancel")
		{
			function.Add (ClickFunction.CANCEL);	
		}
		else if(name == "Activate" || name == "Activate 1")
		{
			function.Add (ClickFunction.ACTIVE);	
		}
		else if(name == "Activate 2")
		{
			function.Add (ClickFunction.ACTIVE2);	
		}
		else if(name == "Put on top")
		{
			function.Add (ClickFunction.PUTONTOP);	
		}
		else if(name == "Put on bottom")
		{
			function.Add (ClickFunction.PUTONBOTTOM);	
		}
		else if(name == "View soul")
		{
			function.Add (ClickFunction.VIEWSOUL);	
		}
		else if(name == "Move")
		{
			function.Add (ClickFunction.MOVE);	
		}
		else if(name == "View Dropzone")
		{
			function.Add (ClickFunction.VIEWDROP);	
		}
		else if(name == "View Bindzone")
		{
			function.Add(ClickFunction.VIEWBINDZONE);	
		}
	}
	
	public void Close()
	{
		bOpen = false;
		_Game.bBlockMouse = false;
		_Game.bCardMenuJustClosed = true;
		_Game.bBlockDropMenu = true;
		function.Clear();
		optionNames.Clear();
		_customW = 0;
		_Game.playerHand.bBlockHand = false;
	}
	
	public bool IsOpen()
	{
		return bOpen;	
	}
	
	private void DrawBox(int id, string text, bool bSelected)
	{
		if(!bSelected)
		{
			GUI.DrawTexture(new Rect(_x, _y + _h * id, _w + _customW, _h), OptionNormal);
		}
		else 
		{
			GUI.DrawTexture(new Rect(_x, _y + _h * id, _w + _customW, _h), OptionSelected);
		}
		GUI.Label(new Rect(_x + 6.0f, _y + 0.5f + _h * id, _w + _customW, _h), text);	
	}
	
	public void Draw()
	{
		if(bOpen)
		{
			for(int i = 0; i < num_options; i++)
			{
				DrawBox(i, optionNames[i], i == iSelectedCard);
			}
		}
	}
	
	public void Update()
	{
		if(!bOpen)
		{
			return;
		}
		
		Vector3 mousePosition = Input.mousePosition;
		float mX = mousePosition.x;
		float mY = Screen.height - mousePosition.y;
		
		//Debug.Log("Card: " + _x + " " + _y + " Mouse: " + mX + " " + mY + " Bottom-Right: " + (_x + _w) + " " + (_y + _h * num_options));
		
		if(mX > _x && mY > _y && mX < (_x + _w) && mY < (_y + _h * num_options))
		{
			iSelectedCard = (int)((mY - _y) / _h);
		
		
		/*
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			iSelectedCard--;
			if(iSelectedCard < 0)
				iSelectedCard = 0;
		}
		else if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			iSelectedCard++;
			if(iSelectedCard >= num_options)
			{
				iSelectedCard = num_options - 1;	
			}
		}
		else 
		*/
			if(Input.GetMouseButtonUp(0))
			{
				if(bIgnore)
				{
					bIgnore = false;
					return;
				}
				
				if(function[iSelectedCard] == ClickFunction.CALL)
				{
					Close ();
					_Game.Call();
					//_Game.playerHand.FixPositions();
				}
				else if(function[iSelectedCard] == ClickFunction.RIDE)
				{
					Close ();
					_Game.Ride ();
					//_Game.playerHand.FixPositions();
					//_Game.bRideThisTurn = true;
				}
				else if(function[iSelectedCard] == ClickFunction.CANCEL)	
				{
					Close();
				}
				else if(function[iSelectedCard] == ClickFunction.ACTIVE)
				{
					Close();
					_Card.unitAbilities.ActiveAbility(_Card, 1);
				}
				else if(function[iSelectedCard] == ClickFunction.ACTIVE2)
				{
					Close();
					_Card.unitAbilities.ActiveAbility(_Card, 2);
				}
				else if(function[iSelectedCard] == ClickFunction.PUTONTOP)
				{
					Close ();
					_Card.TurnDown();
					_Game.playerDeck.PutOnTop(_Card);
				}
				else if(function[iSelectedCard] == ClickFunction.PUTONBOTTOM)
				{
					Close ();
					_Card.TurnDown();
					_Game.playerDeck.PutOnBottom(_Card);
				}
				else if(function[iSelectedCard] == ClickFunction.VIEWSOUL)
				{
					Close();
					_Game.field.ViewSoul();
				}
				else if(function[iSelectedCard] == ClickFunction.MOVE)
				{
					Close();
					_Game.field.Move (_Card);
				}
				else if(function[iSelectedCard] == ClickFunction.VIEWDROP)
				{
					Close();
					_Game.field.ViewDropZone();
				}
				else if(function[iSelectedCard] == ClickFunction.VIEWBINDZONE)
				{
					Close();
					_Game.field.ViewBindZone();
				}
			}
		}
		else
		{
			bIgnore = false;	
		}
	}
}


public enum ClickFunction
{
	RIDE,
	CALL,
	CANCEL,
	ACTIVE,
	ACTIVE2,
	PUTONTOP,
	PUTONBOTTOM,
	VIEWSOUL,
	MOVE,
	VIEWDROP,
	VIEWBINDZONE
}