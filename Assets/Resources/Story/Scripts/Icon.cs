using UnityEngine;
using System.Collections.Generic;

public class Icon : MonoBehaviour {
	public string characterName;
	public List<string> group = new List<string>();

	public int nextScene;

	void OnMouseDown(){
		string argument = characterName;
		if(group != null && group.Count != 0){
			for(int i=0;i < group.Count;i++){
				if(group[i] != characterName){
					argument += ",";
					argument += group[i];
				}
			}
		}
		PlayerPrefs.SetString("Arguments",argument);
		Application.LoadLevel("Dialogue" + nextScene);
		Debug.Log(PlayerPrefs.GetString("Arguments"));
	}
}
