using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionListGenericWindow {
	public delegate void OnButtonClicked(string optionName, int index);

	OnButtonClicked onButtonClicked;

	Card owner;
	Card source;
	List<string> options;
	string caption;
	int xPos, yPos;
	int buttonWidth = 200;
	int buttonHeight = 20;
	bool bIsActive = false;
	
	public SelectionListGenericWindow(int _xPos, int _yPos)
	{
		xPos = _xPos;
		yPos = _yPos;
		caption = "No title";
	}

	public bool IsActive()
	{
		return bIsActive;
	}

	public void Render()
	{
		if(bIsActive)
		{
			GUI.TextArea(new Rect(xPos, yPos, 200, 20), caption);
			for(int i = 0; i < options.Count; i++)
			{
				if(GUI.Button(new Rect(xPos, yPos + buttonHeight * (i + 1), buttonWidth, buttonHeight), options[i]))
				{
					bIsActive = false;	
					onButtonClicked(options[i], i);
				}
			}
		}
	}

	public void OnButtonClickedCallback(OnButtonClicked fnc)
	{
		onButtonClicked = fnc;
	}

	public void Set(List<string> _options)
	{
		options = _options;
		bIsActive = true;
	}
	
	public void SetCaption(string _caption)
	{
		caption = _caption;	
	}
}
