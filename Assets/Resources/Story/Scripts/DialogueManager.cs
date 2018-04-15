using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {
	public DialogueParser parser;

	public string dialogue;
	public string characterName;
	int lineNum;
	public int LineNum {
		get {
			return lineNum;
		}
		set {
			lineNum = value;
			if(parser.GetLine(lineNum) != "" && parser.GetName(LineNum) != "Player" && parser.GetLine(lineNum).ToCharArray()[0] == '|'){
				string[] conditionals = parser.GetLine(lineNum).Remove(0,1).Split('|')[0].Split('&');
				if(conditionals.Length >= 4){
					int amt = GameObject.Find(conditionals[0]).GetComponent<Character>().GetFriendship(conditionals[1]).amount;
					parser.ChangeLine(lineNum,parser.GetLine(lineNum).Remove(0,1).Split('|')[1]);
					if(conditionals[2] == "=" && !(amt == int.Parse(conditionals[3]))){
						LineNum++;
					} else if(conditionals[2] == ">" && !(amt > int.Parse(conditionals[3]))){
						LineNum++;
					} else if(conditionals[2] == "<" && !(amt < int.Parse(conditionals[3]))){
						LineNum++;
					} else if(conditionals[2] == ">=" && !(amt >= int.Parse(conditionals[3]))){
						LineNum++;
					} else if(conditionals[2] == "<=" && !(amt <= int.Parse(conditionals[3]))){
						LineNum++;
					}
				}
			}
		}
	}
	Vector3 position;
	string[] choices;

	public bool playerTalking;
	List<Button> buttons = new List<Button>();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceButton;

	GameObject canvas;

	public GameObject characterParent;

	void Start(){
		canvas = GameObject.FindObjectOfType<Canvas>().gameObject;
		dialogue = "";
		characterName = "";
		position = new Vector3(0,0,0);
		playerTalking = false;
		parser = GameObject.FindObjectOfType<DialogueParser>().GetComponent<DialogueParser>();
		LineNum = 0;
		ShowDialogue();
		LineNum++;
	}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			 if(!playerTalking){
				ShowDialogue();
				LineNum++;
				Debug.Log(LineNum);
			}
		}
		UpdateUI();
	}

	public void ShowDialogue(){
		ResetImages();
		ParseLine();
	}

	void ResetImages(){
		if(characterName != ""){
			GameObject character = GameObject.Find(characterName);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = null;
		}
	}

	void ParseLine(){
		Debug.Log(LineNum);
		if(parser.GetLine(LineNum).Contains("$")){
			string line = parser.GetLine(LineNum);
			Debug.Log("ParseLine - Before: " + line);
			string[] vars = line.Split('$');
			if(vars.Length >= 3){
				for(int i=1;i < vars.Length;i+=2){
					if(PlayerPrefs.HasKey(vars[i])){
						line = line.Replace(vars[i],PlayerPrefs.GetString(vars[i]));
					}
				}
				line = line.Replace("$","");
				Debug.Log("ParseLine - After: " + line);
				parser.ChangeLine(lineNum,line);
			}
		}
		if(parser.GetName(LineNum) == "PlayerLine"){
			playerTalking = false;
			characterName = "Player";
			dialogue = parser.GetLine(LineNum);
			position = parser.GetPosition(LineNum);
			Debug.Log(dialogue);
			return;
		} else if(parser.GetName(LineNum) != "Player"){
			playerTalking = false;
			characterName = parser.GetName(LineNum);
			dialogue = parser.GetLine(LineNum);
			position = parser.GetPosition(LineNum);
			DisplayImages();
		} else{
			playerTalking = true;
			characterName = "";
			dialogue = "";
			position = new Vector3(0,0,0);
			choices = parser.GetChoices(LineNum);
			CreateButtons();
		}
	}

	void DisplayImages(){
		if(characterName != ""){
			GameObject character = GameObject.Find(characterName);
			SetSpritePositions(character);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = character.GetComponent<Character>().characterSprite;
		}
	}

	void SetSpritePositions(GameObject spriteObj){
		spriteObj.transform.localPosition = new Vector3(position.x,position.y,0);
	}

	void CreateButtons(){
		for(int i=0;i < choices.Length-1;i++){
			GameObject buttonObj = (GameObject)Instantiate(choiceButton);
			Button button = buttonObj.GetComponent<Button>();
			ChoiceButton choiceBtn = buttonObj.GetComponent<ChoiceButton>();
			string[] choiceOptions = choices[i].Split(':');
			choiceBtn.SetText(choiceOptions[0]);
			choiceBtn.SetNextLine(choiceOptions[1]);
			string choiceText = "";
			for(int j=2;j < choiceOptions.Length;j++){
				choiceText += choiceOptions[j];
				if(j != choiceOptions.Length-1){
					choiceText += ":";
				}
			}
			choiceBtn.SetChoice(choiceText);
			choiceBtn.manager = this;
			button.transform.SetParent(canvas.transform,true);
			button.transform.localPosition = new Vector3(0,-25 + (i*50));
			button.transform.localScale = new Vector3(1,1,1);
			buttons.Add(button);
			if(choices[choices.Length-1] == "false"){
				choiceBtn.ParseChoice();
				break;
			}
		}
	}

	void UpdateUI(){
		if(!playerTalking){
			ClearButtons();
		}
		dialogueBox.text = dialogue;
		nameBox.text = characterName;
	}

	void ClearButtons(){
		for(int i=0;i < buttons.Count;i++){
			Button button = buttons[i];
			buttons.Remove(button);
			Destroy(button.gameObject);
		}
	}

	public void LoadScene(string sceneName){
		List<string> friendships = new List<string>();
		Character[] characters = characterParent.GetComponentsInChildren<Character>();
		for(int i=0;i < characters.Length;i++){
			for(int j=0;j < characters[i].friendships.Count();j++){
				Friendship friendship = characters[i].friendships.Get(j);
				friendships.Add(friendship.character1.name + ":" + friendship.character2.name + ":" + friendship.amount);
			}
		}
		PlayerPrefsAddOns.SetStringArray("Friendships",friendships.ToArray());
		PlayerPrefs.SetString("Arguments","");
		Application.LoadLevel(sceneName);
	}
}
