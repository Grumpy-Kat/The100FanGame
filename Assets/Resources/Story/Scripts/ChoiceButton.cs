using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoiceButton : MonoBehaviour {
	public string nextLine;
	public string choice;
	public DialogueManager manager;

	public void SetText(string text){
		this.GetComponentInChildren<Text>().text = text;
	}

	public void SetNextLine(string nextLine){
		this.nextLine = nextLine;
	}

	public void SetChoice(string choice){
		this.choice = choice;
	}

	public void ParseChoice(){
		int index = -1;
		if(choice.Contains(":")){
			string[] commands = choice.Split(':');
			for(int i=0;i < commands.Length;i++){
				string command = commands[i].Split(',')[0];
				string mod = commands[i].Split(',')[1];
				if(command == "line"){
					Debug.Log(mod);
					index = int.Parse(mod);
				}
				EnterCommand(command,mod);
			}
			if(index == -1){
				index = manager.LineNum+2;
			}
		} else{
			string command = choice.Split(',')[0];
			string mod = choice.Split(',')[1];
			if(command != "line"){
				index = manager.LineNum+2;
			} else{
				index = int.Parse(mod);
			}
			EnterCommand(command,mod);
		}
		Debug.Log(index);
		manager.parser.AddLine(index,"PlayerLine;" + nextLine + ";0,0,0");
		manager.playerTalking = false;
		manager.LineNum++;
		manager.ShowDialogue();
		manager.LineNum++;
	}

	void EnterCommand(string command,string mod){
		if(command == "line"){
			manager.LineNum = int.Parse(mod)-1;
			manager.ShowDialogue();
		} else if(command == "scene"){
			manager.LoadScene(mod);
		} else if(command == "character"){
			Character character1 = GameObject.Find(mod.Split('|')[0]).GetComponent<Character>();
			character1.AddFriendshipAmount(character1.GetFriendship(mod.Split('|')[1]),int.Parse(mod.Split('|')[2]));
		}
	}
}
