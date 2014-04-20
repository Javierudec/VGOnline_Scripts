using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SearchMode
{
	TOP_CARD,
	ALL_DECK,
	ALL_EXCEPT,
	TOP_CARD_WITH_REORDER,
	TOP_CARD_WITH_REORDER_BOTTOM
}

public class Deck {
	public delegate bool CheckCardFunc(Card c);
	public delegate bool CheckCardSelection(Game2DCard c);
	
	private List<Card> cards;
	private FieldInformation fieldInfo;
	private Vector3 initialPositionShowDeck;
	
	private Vector3 deltaPositionShowDeck;
	private GameObject Cursor;
	private bool bShowingDeck;
	private int currentCard;
	bool bUseBottomOrder = false;
	private bool bCloseButtonEnabled = true;
	bool bOrderRemaining = false;
	bool bDoReorder = false;
	int numCandidates = 0;
	private bool bCardReturningToDeck = false;
	private Card AuxCard = null;
	
	private bool bViewingDeck = false;
	private Texture2D ViewBackground;
	private List<Game2DCard> CardsWatching;
	private List<Game2DCard> TotalCards;
	private Gameplay _Game;
	private int cur2DCardSelected;
	private int curOffset;
	private CardIdentifier LastID;
	private bool bBlockKeyboardOnce = true;
	
	private int numSelections = 0;
	private List<CardIdentifier> CardSelectedVector; 
	
	CheckCardSelection CardCanBeSelected = null;
	
	private bool mouseOnCard = false;

	public List<Card> getCardList()
	{
		return cards;
	}
	
	public Deck(Gameplay game)
	{
		cards = new List<Card>();	
		fieldInfo = new FieldInformation();
		CardSelectedVector = new List<CardIdentifier>();
		
		initialPositionShowDeck = new Vector3(-15.43038f, 3.943099f, -18.63872f);
		deltaPositionShowDeck   = new Vector3(0.625f, 0.0f, 0.001f);
		
		Cursor = GameObject.FindGameObjectWithTag("Cursor");
		
		bShowingDeck = false;
		currentCard = 0;
		
		ViewBackground = Resources.Load ("ViewCardBackground") as Texture2D;
		
		CardsWatching = new List<Game2DCard>();
		TotalCards = new List<Game2DCard>();
		_Game = game;
	}

	public List<Card> GetFirstCards(int n)
	{
		List<Card> listToRet = new List<Card>();
		for(int i = cards.Count - 1, j = 0; i >= 0 && j < n; i--, j++)
		{
			listToRet.Add(cards[i]);
		}

		return listToRet;
	}

	public bool AnimationOngoing()
	{
		return bCardReturningToDeck;	
	}
	
	public void EnableCloseButton()
	{
		bCloseButtonEnabled = true;	
	}
	
	public void DisableCloseButton()
	{
		bCloseButtonEnabled = false;	
	}
	
	public void AddCard(Card card, bool bWithAnim = true)
	{
		if(card == null || fieldInfo == null)
			return;
		
		cards.Add(card);

		if(bWithAnim)
		{
			SetDeckPosition();
		}
	}
	
	public void linkGameObjectToCard(GameObject go, HandleMouse _m,  int index)
	{
		cards[index].SetGameObject(go, _m);	
	}
	
	public void SetDeckPosition()
	{
		Vector3 position = fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE);
		Vector3 delta = new Vector3(0.0f, 0.025f, 0.0f);
		
		for(int i = 0; i < cards.Count; i++)
		{
			/*
			cards[i].GetGameObject().transform.position = position + i * delta;	
			cards[i].GetGameObject().transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			*/
			cards[i].MoveAndRotate(position + i * delta, new Vector3(0.0f, 180.0f, 0.0f));
			cards[i].TurnDown();
		}
	}
	
	public Card DrawCard()
	{
		if(cards.Count > 0)
		{
			Card CardToReturn = cards[cards.Count - 1];
			cards.RemoveAt(cards.Count - 1);
			SetDeckPosition();
			return CardToReturn;
		}
		else
		{
			return null;	
		}
	}
	
	public void ShowDeck()
	{
		if(cards.Count <= 0)
		{
			return;	
		}
		
		for(int i = 0; i < cards.Count; i++)
		{
			cards[i].GetGameObject().transform.position = initialPositionShowDeck + (i * deltaPositionShowDeck);
			cards[i].GetGameObject().transform.eulerAngles = new Vector3(24.0f, 180.0f, 0.0f);
			cards[i].TurnUp();
		}

		SetMouseAtCard(0, true);
		
		bShowingDeck = true;
		currentCard = 0;
	}
	
	public void HideDeck()
	{
		SetDeckPosition();
		
		for(int i = 0; i < cards.Count; i++)
		{
			cards[i].TurnDown();	
		}
		
		bShowingDeck = false;
	}
	
	public bool ShowingDeck()
	{
		return bShowingDeck;	
	}
	
	private void SetMouseAtCard(int index, bool bNext)
	{
		Cursor.transform.position = cards[index].GetGameObject().transform.position + new Vector3(0.0f, 0.0f, -0.11f);
		Cursor.transform.eulerAngles = cards[index].GetGameObject().transform.eulerAngles;
		cards[index].GetGameObject().transform.position += new Vector3(0.0f, 0.0f, -0.1f);
		
		if(bNext)
		{
			if(index > 0)
			{
				cards[index - 1].GetGameObject().transform.position -= new Vector3(0.0f, 0.0f, -0.1f);
			}
		}
		else
		{
			if(index < cards.Count - 1)
			{
				cards[index + 1].GetGameObject().transform.position -= new Vector3(0.0f, 0.0f, -0.1f);
			}
		}
	}
	
	public void GoToNextCard()
	{
		if(currentCard < cards.Count - 1)
		{
			currentCard++;
			SetMouseAtCard(currentCard, true);
		}
	}
	
	public void GoToPrevCard()
	{
		if(currentCard > 0)
		{
			currentCard--;
			SetMouseAtCard(currentCard, false);
		}
	}
	
	public Card RemoveFromDeck(int index)
	{
		Card cardToReturn = cards[index];
		cards.RemoveAt(index);
		return cardToReturn;
	}
	
	public void RemoveFromDeck(Card card)
	{
		cards.Remove(card);
	}
	
	public int GetCurrentCard()
	{
		return currentCard;	
	}
	
	public Card GetCurrentCardObject()
	{
		return cards[currentCard];	
	}
	
	public void Shuffle()
	{
		System.Random rng = new System.Random();
		int n = cards.Count;
		while(n > 1)
		{
			n--;
			int k = rng.Next(n + 1);
			Card value = cards[k];
			cards[k] = cards[n];
			cards[n] = value;
		}
	}
	
	public Card Drive()
	{
		//Debug.Log("Drive Check!");
		
		Card cardToReturn = cards[cards.Count - 1];
		cards.RemoveAt(cards.Count - 1);
		
		cardToReturn.GetGameObject().transform.position = fieldInfo.GetPosition((int)fieldPositions.DRIVE);
		cardToReturn.GetGameObject().transform.eulerAngles = fieldInfo.GetDriveRotation();
		cardToReturn.TurnUp();
		
		return cardToReturn;	
	}
	
	public Card SearchForID(CardIdentifier id)
	{
		for(int i = cards.Count - 1; i >= 0; i--)
		{
			if(cards[i].cardID == id)
			{
				return cards[i];	
			}
		}
		
		return null;
	}

	public void AddToBottom(Card c)
	{
		cards.Insert(0, c);
		SetDeckPosition();
	}
	
	public int SearchForID_GetIndex(CardIdentifier id)
	{
		for(int i = cards.Count - 1; i >= 0; i--)
		{
			if(cards[i].cardID == id)
			{
				return i;	
			}
		}
		
		/*
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].cardID == id)
			{
				return i;	
			}
		}
		*/
		
		return -1;
	}
	
	public void ReturnToDeck(Card card, bool bBottom = false)
	{
		Vector3 posDeck = fieldInfo.GetPosition((int)fieldPositions.DECK_ZONE);
		card.GoTo(posDeck.x, posDeck.z);
		AuxCard = card;
		bCardReturningToDeck = true;
		
		if(!bBottom)
		{
			AddCard(card);
		}
		else
		{
			AddToBottom(card);	
		}
	}
	
	public void Update()
	{
		for(int i = 0; i < cards.Count; i++)
		{
			cards[i].Update();	
		}
		
		if(bCardReturningToDeck)
		{
			//AuxCard.Update();
			if(!AuxCard.AnimationOngoing())
			{
				bCardReturningToDeck = false;
				AuxCard.TurnDown();
			}
		}
		
		if(bViewingDeck)
		{	
			if(numSelections <= 0 || numCandidates <= 0)
			{
				if(!bOrderRemaining)
				{
					CloseDeck();
				}
				else
				{	
					if(numSelections <= 0)
					{
						CloseDeck();
					}
					else
					{
						bDoReorder = true;
						if(bUseBottomOrder)
						{
							_Game.GameChat.AddHelpMessage("Return the remaining cards to your deck. (From top to bottom)");	
						}
						else
						{
							_Game.GameChat.AddHelpMessage("Return the remaining cards to your deck. (From bottom to top)");
						}
					}
				}
			}
			
			mouseOnCard = false;
			for(int i = 0; i < CardsWatching.Count; i++) 
			{
				if(Util.MouseOn(CardsWatching[i]._x, CardsWatching[i]._y, CardsWatching[i].GetWidth(), CardsWatching[i].GetHeight(), Input.mousePosition))
				{
					cur2DCardSelected = i;	
					_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
					mouseOnCard = true;
				}
			}
			
			if(!mouseOnCard)
			{
				bBlockKeyboardOnce = false;	
			}
			
			if(Input.GetMouseButtonUp(0) && mouseOnCard)
			{	
				if(bBlockKeyboardOnce)
				{
					bBlockKeyboardOnce = false;
					return;
				}
				
				if(bDoReorder)
				{
					ReturnToDeckBy2DArray(cur2DCardSelected);
					if(TotalCards.Count <= 0)
					{
						CloseDeck();	
					}
				}
				else
				{
					if(DeleteFromCard2DArray(cur2DCardSelected))
					{
						numSelections--;
						numCandidates--;
					}
				}
			}
		}
	}
	
	private bool ReturnToDeckBy2DArray(int CurrentWatchingIdx, bool bTop = true)
	{
		if(CurrentWatchingIdx >= CardsWatching.Count || CurrentWatchingIdx < 0)
		{
			return false;	
		}
		
		Game2DCard temp = CardsWatching[CurrentWatchingIdx];
		
		Card tmp = SearchForID(temp._CardInfo.cardID);
		RemoveFromDeck(tmp);	
		
		if(!bUseBottomOrder)
		{
			AddCard(tmp);
		}
		else
		{
			AddToBottom(tmp);	
		}
		
		SetDeckPosition();
		
		TotalCards.Remove(temp);
		CardsWatching.Clear();
		for(int i = 0; i < 8; i++)
		{
			if((curOffset + i) < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[curOffset + i]);
			}
		}
		
		return true;
	}
	
	private bool DeleteFromCard2DArray(int CurrentWatchingIdx)
	{
		if(CurrentWatchingIdx >= CardsWatching.Count || CurrentWatchingIdx < 0)
		{
			return false;	
		}
		
		Game2DCard temp = CardsWatching[CurrentWatchingIdx];
		
		if(CardCanBeSelected != null && !CardCanBeSelected(temp)) return false;
		
		CardSelectedVector.Add(temp._CardInfo.cardID);
		TotalCards.Remove(temp);
		CardsWatching.Clear();
		for(int i = 0; i < 8; i++)
		{
			if((curOffset + i) < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[curOffset + i]);
			}
		}
		
		return true;
	}
	
	public List<CardIdentifier> GetLastSelectedList()
	{
		return CardSelectedVector;	
	}
	
	private void BeginViewDeck(int num)
	{
		TotalCards.Clear();
		CardsWatching.Clear();
		bViewingDeck = true;
		cur2DCardSelected = 0;
		curOffset = 0;
		bBlockKeyboardOnce = true;	
		numSelections = num;
		CardSelectedVector.Clear();
		CardCanBeSelected = null;
		bOrderRemaining = false;
		bDoReorder = false;
		numCandidates = 0;
		bUseBottomOrder = false;
	}
	
	private void FillDeckView()
	{
		for(int i = 0; i < 8; i++)
		{
			if(i < TotalCards.Count)
			{
				CardsWatching.Add(TotalCards[i]);
			}
		}	
		if(numSelections > TotalCards.Count)
		{
			numSelections = TotalCards.Count;	
		}
		for(int i = 0; i < TotalCards.Count; i++)
		{
			if(CardCanBeSelected == null || (CardCanBeSelected != null && CardCanBeSelected(TotalCards[i])))
			{
				numCandidates++;	
			}
		}
	}
	
	private void CreateCard(CardIdentifier id)
	{
		TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(id)));
	}
	
	public void ViewDeck(int numSelections, SearchMode mode, int num, string clanName, CheckCardSelection fnc = null)
	{
		BeginViewDeck(numSelections);
		CardCanBeSelected = fnc;
		if(mode == SearchMode.TOP_CARD)
		{
			for(int i = 0; i < num; i++)
			{
				int idx = cards.Count - 1 - i;
				if(idx >= 0 && (cards[idx].clan == clanName || clanName == ""))
				{
					CreateCard(cards[idx].cardID);
				}
			}
		}
		else if(mode == SearchMode.TOP_CARD_WITH_REORDER)
		{
			bOrderRemaining = true;
			
			for(int i = 0; i < num; i++)
			{
				int idx = cards.Count - 1 - i;
				if(idx >= 0 && (cards[idx].clan == clanName || clanName == ""))
				{
					CreateCard(cards[idx].cardID);
				}
			}			
		}
		FillDeckView();
	}
	
	public void ViewDeck(int numSelections, SearchMode mode, int num, CheckCardSelection fnc = null)
	{
		BeginViewDeck(numSelections);
		CardCanBeSelected = fnc;
		if(mode == SearchMode.TOP_CARD)
		{
			for(int i = 0; i < num; i++)
			{
				int idx = cards.Count - 1 - i;
				if(idx >= 0)
				{
					CreateCard(cards[idx].cardID);
				}
			}
		}
		else if(mode == SearchMode.TOP_CARD_WITH_REORDER)
		{
			bOrderRemaining = true;
			
			for(int i = 0; i < num; i++)
			{
				int idx = cards.Count - 1 - i;
				if(idx >= 0)
				{
					CreateCard(cards[idx].cardID);
				}
			}			
		}
		else if(mode == SearchMode.TOP_CARD_WITH_REORDER_BOTTOM)
		{
			bOrderRemaining = true;
			bUseBottomOrder = true;
			for(int i = 0; i < num; i++)
			{
				int idx = cards.Count - 1 - i;
				if(idx >= 0)
				{
					CreateCard(cards[idx].cardID);
				}
			}				
		}
		FillDeckView();
	}
	
	public void ViewDeck(int numSelections, CheckCardSelection fnc = null)
	{
		BeginViewDeck(numSelections);
		CardCanBeSelected = fnc;
		for(int i = cards.Count - 1; i >= 0; i--)
		{
			CreateCard(cards[i].cardID);
		}
		FillDeckView();
	}
	
	public void ViewDeck(int numSelections, CheckCardFunc func)
	{
		BeginViewDeck(numSelections);
		for(int i = cards.Count; i >= 0; i--)
		{
			if(func(cards[i]))
			{
				CreateCard(cards[i].cardID);
			}
		}
		FillDeckView();
	}
	
	public void ViewDeck(int numSelections, SearchMode mode, string clanName)
	{
		BeginViewDeck(numSelections);
		if(mode == SearchMode.ALL_DECK)
		{
			for(int i = 0; i < cards.Count; i++)
			{
				int idx = i;
				if(cards[idx].clan == clanName || clanName == "")
				{
					CreateCard(cards[idx].cardID);
				}
			}
		}
		FillDeckView();
	}
	
	public void ViewDeck(int numSelections, SearchMode mode, string clanName, string race)
	{
		BeginViewDeck(numSelections);
		if(mode == SearchMode.ALL_DECK)
		{
			for(int i = 0; i < cards.Count; i++)
			{
				int idx = i;
				if(cards[idx].clan == clanName && cards[idx].race == race)
				{
					CreateCard(cards[idx].cardID);
				}
			}
		}
		FillDeckView();
	}
	
	public void ViewDeck(string clan, int maxGrade, string nameContains = "")
	{
		BeginViewDeck(1);
		
		for(int i = 0; i < cards.Count; i++)
		{
			if((cards[i].clan == clan || clan == "") && cards[i].grade <= maxGrade && (nameContains == "" || cards[i].name.Contains(nameContains)))
			{	
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(cards[i].cardID)));
			}
		}
		
		FillDeckView();
	}
	
	public int GetNumGradeLessOrEqual(int g)
	{
		int cnt = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].grade <= g)
			{
				cnt++;	
			}
		}
		return cnt;
	}
	
	public int GetNumberNameContainAndGradeLess(string str, int g)
	{
		int cnt = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].grade <= g && cards[i].name.Contains(str))
			{
				cnt++;	
			}
		}
		return cnt;		
	}
	
	public void ViewDeck(CardIdentifier cardID1)
	{
		BeginViewDeck(1);		
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].cardID == cardID1)
			{	
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(cards[i].cardID)));
			}
		}
		FillDeckView();	
	}
	
	public void ViewDeck(int n, CardIdentifier cardID1)
	{
		BeginViewDeck(n);		
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].cardID == cardID1)
			{	
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(cards[i].cardID)));
			}
		}
		FillDeckView();	
	}
	
	public void ViewDeck(CardIdentifier cardID1, CardIdentifier cardID2)
	{
		BeginViewDeck(1);
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].cardID == cardID1 || cards[i].cardID == cardID2)
			{	
				TotalCards.Add(new Game2DCard(_Game.Data.GetCardInfo(cards[i].cardID)));
			}
		}
		
		FillDeckView();
	}
	
	public int Count(CheckCardFunc func)
	{
		int num = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(func(cards[i]))
			{
				num++;
			}
		}
		return num;
	}
	
	public void CloseDeck()
	{
		bViewingDeck = false;	
		if(cur2DCardSelected >= 0 && cur2DCardSelected < CardsWatching.Count)
		{
			LastID = CardsWatching[cur2DCardSelected]._CardInfo.cardID;
		}
		_Game.GameChat.ClearChat();
		
		if(bOrderRemaining)
		{
			for(int i = 0; i < TotalCards.Count; i++)
			{
				if(bUseBottomOrder)
				{
					AddToBottom(DrawCard());	
				}
				else
				{
					AddCard(DrawCard());	
				}
			}
		}
	}
	
	public CardIdentifier GetLastCardID()
	{
		return LastID;
	}
	
	public int GetNumberOfCardsWithClan(string clanName)
	{
		int num = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].clan == clanName)
			{
				num++;	
			}
		}
		return num;
	}
	
	public int GetNumberOfCardsWithClanAndRace(string clanName, string race)
	{
		int num = 0;
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].clan == clanName && cards[i].race == race)
			{
				num++;	
			}
		}
		return num;
	}
	
	public void DrawGUI()
	{
		if(bViewingDeck)
		{
			float _x = Screen.width / 2 - 300 + 160;
			float _y = Screen.height / 2 - 63;
			GUI.DrawTexture(new Rect(_x, _y, 600, 146), ViewBackground);
			for(int i = 0; i < CardsWatching.Count; i++)
			{
				bool bOp = false;
				if((CardCanBeSelected != null && !CardCanBeSelected(CardsWatching[i])) || bDoReorder) bOp = true;
				
				CardsWatching[i].DrawAt(_x + (CardsWatching[i].GetWidth() + 5) * i + 35, _y + 40, bOp); 	
			}
			
			if(GUI.Button(new Rect(_x, _y + 40, 30, 100), "<"))
			{
				if(cur2DCardSelected > 0)
				{
					cur2DCardSelected--;
				}
				else
				{
					if(curOffset > 0)
					{
						curOffset--;
						CardsWatching.RemoveAt(CardsWatching.Count - 1);
						CardsWatching.Insert(0, TotalCards[curOffset]); 
					}
				}
				
				_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
			}
			else if(GUI.Button(new Rect(_x + 600 - 40, _y + 40, 30, 100), ">"))
			{
				if(cur2DCardSelected < CardsWatching.Count - 1)
				{
					cur2DCardSelected++;	
				}
				else
				{
					if(curOffset < (TotalCards.Count - 8))
					{
						curOffset++;
						CardsWatching.RemoveAt(0);
						CardsWatching.Add(TotalCards[curOffset]); 
					}
				}
				_Game._CardMenuHelper.SetCard(CardsWatching[cur2DCardSelected]._CardInfo.cardID);
			}
			else if(GUI.Button (new Rect(_x + 600 - 25 - 10, _y + 10, 25, 25), "X"))
			{
				if(bCloseButtonEnabled)
				{	
					CloseDeck();
				}
			}
			else
			{
	
			}
		}
	}
	
	public bool IsOpen()
	{
		return bViewingDeck;	
	}
	
	public int Size()
	{
		return cards.Count;	
	}
	
	public Card TopCard()
	{
		return cards[cards.Count - 1];	
	}
	
	public void PutOnTop(Card card)
	{
		cards.Add(card);
	}
	
	public void PutOnBottom(Card card)
	{
		cards.Insert(0, card);
	}
	
	public bool ThereIsUnitGradeOrLess(int grade)
	{
		for(int i = 0; i < cards.Count; i++)
		{
			if(cards[i].grade <= grade)
			{
				return true;	
			}
		}
		
		return false;
	}
	
	//Returns card at position index with 0 starting at the top of the deck. null if an error occurs.
	public Card GetByIndex(int index)
	{
		int indexToReturn = (cards.Count - 1) - index;
		if(indexToReturn < 0)
		{
			return null; //Error.	
		}
		else
		{
			return cards[indexToReturn];	
		}
	}
}
