using UnityEngine;
using System.Collections;

public class GameHelper : MonoBehaviour {
	public string _CurText = "";
	private GamePhase _CurPhase = GamePhase.CHOOSE_VANGUARD;
	private bool bShowWindow = true;
	private bool bPlayerDontWantToSeeit = false;
	private TriggerIcon bHelpTrigger = TriggerIcon.DRAW;
	private bool bTriggerWindow = false;
	private bool bPowerWindow = false;
	public bool bCustomMessage = false;
	private Chat GameChat = null;
	string currentText = "";
	private Gameplay Game = null;
	
	public void SetChat(Chat _Chat)
	{
		GameChat = _Chat;	
	}

	public void SetGame(Gameplay game)
	{
		this.Game = game;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.H))
		{
			bPlayerDontWantToSeeit = !bPlayerDontWantToSeeit;	
		}		

		if(bCustomMessage)
		{
			bShowWindow = true;
			return;
		}

		_CurText = "";
		
		bShowWindow = true;
		if(_CurPhase == GamePhase.CHOOSE_VANGUARD)
		{
			_CurText = "Search for a 0 grade unit using left and right arrows, when you want to select your initial vanguard" +
			           " press X.";
		}
		else if(_CurPhase == GamePhase.ATTACK)
		{
			if(bTriggerWindow)
			{
				if(bHelpTrigger == TriggerIcon.CRITICAL)
				{
					_CurText = "Choose a unit, and that unit gets [Critical]+1";
				}
				else if(bHelpTrigger == TriggerIcon.STAND)
				{
					_CurText = "Choose a unit, and [Stand] it.";	
				}
				else if(bHelpTrigger == TriggerIcon.HEAL)
				{
					_CurText = "Choose a card in your damage zone to send it to the drop zone.";	
				}
				
			}	
			else if(bPowerWindow)
			{
				_CurText = "Choose a unit, and that unit gets [Power]+5000";	
			}
			else 
			{
				/*
				_CurText = "Choose an unit pressing left-clicking on it." +
					       "For attack, left-click over the unit that you want to battle.\nRight-click to end your turn.";
				*/
			}
		}
		else if(_CurPhase == GamePhase.GUARD)
		{
			if(bTriggerWindow)
			{
				if(bHelpTrigger == TriggerIcon.HEAL)
				{
					_CurText = "Choose a card in your damage zone to send it to the drop zone.";	
				}
			}
			else if(bPowerWindow)
			{
				_CurText = "Choose a unit, and that unit gets [Power]+5000";	
			}
			else if(Game.guardZone.cards.Count <= 0)
			{
				_CurText = "Choose from your hand the units you want to use to guard left-clickling on them. \nRight-click to finish your guard phase.";
			}
		}
		else if(_CurPhase == GamePhase.MAIN_PHASE)
		{
			_CurText = "You can ride/call units from your hand left-clicking over them and then selecting the place on the field where you want to put them.\nLeft-click to battle.";
		}
		else if(_CurPhase == GamePhase.MULLIGAN)
		{
			_CurText = "Select cards from your hand that you want to replace pressing left-click.\nRight-Click to finish Mulligan phase.";	
		}
		else
		{
			bShowWindow = false;	
		}
	}
	
	public void DrawGUI()
	{
		if(bShowWindow && !bPlayerDontWantToSeeit)
		{
			if(_CurText != currentText)
			{
				currentText = _CurText;
				GameChat.AddHelpMessage(currentText);
			}
		}	
	}
	
	public void SetGamePhase(GamePhase gp)
	{
		_CurPhase = gp;	
	}
	
	public void SetPowerIncrease()
	{
		bPowerWindow = true;
		bTriggerWindow = false;
	}
	
	public void SetTriggerEffect(TriggerIcon ti)
	{
		bHelpTrigger = ti;
		bPowerWindow = false;
		bTriggerWindow = true;
	}
	
	public void SetToNormal()
	{
		bPowerWindow = false;
		bTriggerWindow = false;
	}
	
	public void CustomMessage(string message)
	{
		_CurText = message;
		bCustomMessage = true;
	}

	public bool ShowHelperText()
	{
		return bPowerWindow || bTriggerWindow || bCustomMessage || _CurPhase == GamePhase.GUARD;
	}
	
	public void DisableCustomMessage()
	{
		bCustomMessage = false;	
		GameChat.ClearChat();
	}
}
