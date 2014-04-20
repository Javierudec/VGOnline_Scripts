using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionListWindow {
	Card owner;
	Card source;
	List<string> options;
	string caption;
	int xPos, yPos;
	int buttonWidth = 200;
	int buttonHeight = 20;
	bool bIsActive = false;
	
	public SelectionListWindow(int _xPos, int _yPos)
	{
		xPos = _xPos;
		yPos = _yPos;
		caption = "No title";
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
					source.unitAbilities.SelectionWindowOnClose(owner, options[i]);
				}
			}
		}
	}
	
	public void Set(Card _source, Card _owner, List<string> _options)
	{
		source = _source;
		owner = _owner;
		options = _options;
		bIsActive = true;
	}
	
	public void SetCaption(string _caption)
	{
		caption = _caption;	
	}
}
