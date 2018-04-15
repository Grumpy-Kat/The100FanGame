using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonGroup : MonoBehaviour {

	public List<Button> buttons;
	public Button currSelectedButton;

	public Color selectedColor;
	public Color defaultColor;

	void Start(){
		for(int i=0;i < buttons.Count;i++){
			Button button = buttons[i];
			buttons[i].onClick.AddListener(() => {currSelectedButton = button;});
		}
		if(currSelectedButton != null){
			currSelectedButton.onClick.Invoke();
		}
	}

	void Update(){
		ColorBlock cb;
		foreach(Button button in buttons){
			cb = button.colors;
			cb.normalColor = defaultColor;
			cb.highlightedColor = defaultColor;
			button.colors = cb;
		}
		if(currSelectedButton != null){
			cb = currSelectedButton.colors;
			cb.normalColor = selectedColor;
			cb.highlightedColor = selectedColor;
			currSelectedButton.colors = cb;
		}
	}

	public void AddToButtons(Button button){
		buttons.Add(button);
		button.onClick.AddListener(() => {currSelectedButton = button;});
	}

	public void SetCurrSelectedButton(Button button){
		currSelectedButton = button;
	}
}
