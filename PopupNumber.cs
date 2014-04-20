using UnityEngine;
using System.Collections;

public class PopupNumber {
	private bool bOpen = false;
	private string customMessage = "";
	private int _minValue = 0;
	private int _maxValue = 0;
	private int _currentValue = 0;
	private GUIStyle BoxStyle;
	private GUIStyle TextStyle;
	private GUIStyle NumberStyle;
	
	public PopupNumber()
	{
		BoxStyle = new GUIStyle();
		BoxStyle.normal.background = Resources.Load ("ConfirmationWindow") as Texture2D;
		
		TextStyle = new GUIStyle();
		TextStyle.fontSize = 20;
		TextStyle.normal.textColor = Color.white;
		
		NumberStyle = new GUIStyle();
		NumberStyle.fontSize = 72;
		NumberStyle.normal.textColor = Color.white;
	}
	
	public void Open(string message, int minValue, int maxValue)
	{
		bOpen = true;
		customMessage = message;
		_minValue = minValue;
		_maxValue = maxValue;
		_currentValue = _minValue;
	}
	
	public void Close()
	{
		bOpen = false;	
	}
	
	public bool IsOpen()
	{
		return bOpen;	
	}
	
	public int GetCurrentValue()
	{
		return _currentValue;
	}
	
	public void Draw()
	{
		if(bOpen)
		{
			float leftIndent = Screen.width / 2 - 597.0f / 2 + 150;
			float topIndent = Screen.height / 2 - 145.0f / 2;
			Rect connectionWindowRect = new Rect(leftIndent, topIndent, 597.0f, 145.0f);
			GUI.Box (connectionWindowRect, "", BoxStyle);
			
			GUI.Label(new Rect(leftIndent + 60, topIndent + 45, 300, 280), customMessage, TextStyle);
			
			GUI.Label(new Rect(leftIndent + 460 + 20, topIndent + 20 + 20, 64, 64), _currentValue + "", TextStyle);
			
			if(GUI.Button(new Rect(leftIndent + 460 + 64, topIndent + 20, 32, 32), "+"))
			{
				if(_currentValue < _maxValue)
				{
					_currentValue++;
				}
			}
			
			if(GUI.Button(new Rect(leftIndent + 460 + 64, topIndent + 52, 32, 32), "-"))
			{
				if(_currentValue > _minValue)
				{
					_currentValue--;
				}
			}
			
			if(GUI.Button(new Rect(leftIndent + 460, topIndent + 84, 64 + 32, 40), "Accept"))
			{
				if(_currentValue > _maxValue)
				{
					_currentValue = _maxValue;	
				}
				else if(_currentValue < _minValue)
				{
					_currentValue = _minValue;	
				}
				
				Close(); 
			}			
		}	
	}
}
