using UnityEngine;
using System.Collections;
using System;

public class DeckEditorManager : MonoBehaviour {
	public CardHelpMenu _CardHelper;
	public DeckSearcher _DeckSearcher;
	public DeckInformation _DeckInformation;
	public DeckWatcher _DeckWatcher;
	
	//Dragged Card
	public Card2D _DraggedCard = null;
	public bool bCardDragged = false;
	public Vector2 v2CardDraggedOffset;
	

	
	public string DeckName = "";
	
	bool bDeckResult = false;
	bool bDeckSavedSuccess = false;
	bool bDeckSavedFail = false;
	
	public float _xWindowScale = 1.0f;
	public float _yWindowScale = 1.0f;
	
	private GUIStyle textStyle = null;
	
	// Use this for initialization
	void Start () {		
		Debug.Log("Start Method() Called.");

		textStyle = new GUIStyle();
		
		_xWindowScale = Screen.width / 1024.0f;
		_yWindowScale = Screen.height / 768.0f;
		
		textStyle.fontSize = (int)(textStyle.fontSize * _xWindowScale);
		textStyle.normal.textColor = Color.white;
		
		_CardHelper = (CardHelpMenu)GameObject.FindGameObjectWithTag("DeckEditorManager").GetComponent("CardHelpMenu");
		_CardHelper.bRenderGamePhases = false;
		
		_DeckSearcher = new DeckSearcher(800.0f, 230.0f, this);
		_DeckInformation = new DeckInformation(342.0f, 0.0f, this);
		_DeckWatcher = new DeckWatcher(342.0f, 85.0f, this);
	}
	
	// Update is called once per frame
	void Update () {
		_DeckSearcher.Update();
		_DeckWatcher.Update();
		_DeckInformation.Update();
		
		bool bInsideDeckWatcher = false;
		if(_DeckWatcher.MouseOn())
		{
			bInsideDeckWatcher = true;
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			if(_DraggedCard != null)
			{
				if(bInsideDeckWatcher && _DeckInformation.numCards < 50 && _DeckInformation.IsCardAllowed(_DraggedCard))
				{
					_DeckWatcher.AddCard(_DraggedCard);
					_DeckInformation.numCards++;
					if(_DraggedCard._CardInfo.grade == 0)
						_DeckInformation.numGrade0++;
					else if(_DraggedCard._CardInfo.grade == 1)
						_DeckInformation.numGrade1++;
					else if(_DraggedCard._CardInfo.grade == 2)
						_DeckInformation.numGrade2++;
					else if(_DraggedCard._CardInfo.grade == 3)
						_DeckInformation.numGrade3++;
					
					_DeckInformation.CardList[(int)_DraggedCard._CardInfo.cardID]++;
					
					if(_DraggedCard._CardInfo.trigger != TriggerIcon.NONE)
					{
						_DeckInformation.numTriggers++;	
					}
					
					if(_DraggedCard._CardInfo.trigger == TriggerIcon.HEAL)
					{
						_DeckInformation.numHealTriggers++;	
					}
					
					if(_DraggedCard._CardInfo.bSentinel)
					{
						_DeckInformation.numSentinels++;	
					}
				}
				
				_DraggedCard = null;
				bCardDragged = false;
			}
		}
	}
	
	void OnGUI()
	{		
		_CardHelper.DrawGUI();
		
		_DeckWatcher.Draw();
		_DeckInformation.Draw();
		_DeckSearcher.Draw();
		
		if(GUI.Button(new Rect(10.0f * _xWindowScale, 710.0f * _yWindowScale, 80 * _xWindowScale, 25 * _yWindowScale), "Go back"))
		{
			Application.LoadLevel("MainMenu");	
		}
		
		if(_DraggedCard != null)
		{
			_DraggedCard.DrawAt(Input.mousePosition.x - v2CardDraggedOffset.x, Screen.height - (Input.mousePosition.y + v2CardDraggedOffset.y));	
		}
		
		//Bottom - left menu
		GUI.Label(new Rect(10 * _xWindowScale, 600 * _yWindowScale, 100 * _xWindowScale, 50 * _yWindowScale), "Save your deck: ", textStyle);
		GUI.Label(new Rect(10 * _xWindowScale, 630 * _yWindowScale, 100 * _xWindowScale, 50 * _yWindowScale), "Deck name: ", textStyle);
		DeckName = GUI.TextField(new Rect(90 * _xWindowScale, 630 * _yWindowScale, 100 * _xWindowScale, 25 * _yWindowScale), DeckName);
		if(GUI.Button(new Rect(200 * _xWindowScale, 630 * _yWindowScale, 50 * _xWindowScale, 25 * _yWindowScale), "Save"))
		{
			bDeckResult = true;
			
			if(_DeckWatcher.SaveDeck(DeckName))
			{
				bDeckSavedSuccess = true;
				bDeckSavedFail = false;
			}
			else
			{
				bDeckSavedSuccess = false;
				bDeckSavedFail = true;
			}
		}
		
		if(bDeckResult)
		{
			if(bDeckSavedFail)
			{
				GUI.Label(new Rect(10 * _xWindowScale, 670 * _yWindowScale, 300 * _xWindowScale, 50 * _yWindowScale), "Fail to save your deck: " + _DeckWatcher.LastError, textStyle);
			}
			
			if(bDeckSavedSuccess)
			{
				GUI.Label(new Rect(10 * _xWindowScale, 670 * _yWindowScale, 300 * _xWindowScale, 50 * _yWindowScale), "Your deck was saved successfully.", textStyle);
			}
		}
	}
}
