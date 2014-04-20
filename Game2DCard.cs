using UnityEngine;
using System.Collections;

public class Game2DCard {
	private float _cardWidth = 300.0f;
	private float _cardHeight = 440.0f;
	private Texture2D texture;
	public CardInformation _CardInfo;
	public float _x;
	public float _y;
	
	public Game2DCard(CardInformation cardInfo)
	{
		_CardInfo = cardInfo;
		texture = Resources.Load ("CardHelper/" + _CardInfo.clan + "/" + _CardInfo.mat) as Texture2D;
		_cardWidth  *= 0.2f;
		_cardHeight *= 0.2f;
	}
	
	public void DrawAt(float x, float y, bool bOpacity = false)
	{
		_x = x;
		_y = y;
		
		Color prev = GUI.color;
		
		if(bOpacity)
		{
			GUI.color = new Color(prev.r, prev.g, prev.b, 0.4f);
		}
		
		GUI.DrawTexture(new Rect(x, y, _cardWidth, _cardHeight), texture);
		
		GUI.color = prev;
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
}
