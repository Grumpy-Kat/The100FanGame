using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class DialogueParser : MonoBehaviour {

	struct DialogueLine{
		public string name;
		public string line;
		public Vector3 position;
		public string[] choices;
		
		public DialogueLine(string name,string line,Vector3 position) {
			this.name = name;
			this.line = line;
			this.position = position;
			choices = new string[0];
		}
	}

	List<DialogueLine> lines;

	void Start(){
		string file = "Assets/Resources/Story/Dialogue/" + Application.loadedLevelName;
		if(PlayerPrefs.HasKey("Arguments") && PlayerPrefs.GetString("Arguments") != ""){
			if(PlayerPrefs.GetString("Arguments").Contains(",")){
				string[] permutations = GetPermutation(PlayerPrefs.GetString("Arguments").Split(','));
				string listString = "Final: ";
				foreach(string s in permutations){
					listString += s + " ";
				}
				for(int i=0;i < permutations.Length;i++){
					if(File.Exists(file + " - " + permutations[i] + ".txt")){
						file += " - ";
						file += permutations[i];
						break;
					}
				}
			} else{
				file += " - ";
				file += PlayerPrefs.GetString("Arguments");
			}
		}
		file += ".txt";
		lines = new List<DialogueLine>();
		LoadDialogue(file);
	}
	
	protected void Swap(ref string a,ref string b){
		if(a == b){
			return;
		}
		string temp = a;
		a = b;
		b = temp;
	}
	
	public string[] GetPermutation(string[] list){
		int x = list.Length-1;
		return GetPermutation(list,0,x,new string[]{});
	}
	
	private string[] GetPermutation(string[] list,int k,int m,string[] finalList){
		if(k == m){
			string listString = list[0];
			for(int i=1;i < list.Length;i++){
				listString += list[i];
			}
			List<string> strings = new List<string>(finalList);
			strings.Add(listString);
			return strings.ToArray();
		} else{
			for(int i = k;i <= m;i++){
				Swap(ref list[k],ref list[i]);
				finalList = GetPermutation(list,k + 1,m,finalList);
				Swap(ref list[k],ref list[i]);
			}
		}
		return finalList;
	}
	
	void LoadDialogue(string filename) {
		string line;
		StreamReader r = new StreamReader(filename);
		using(r){
			do{
				line = r.ReadLine();
				if(line != null){
					if(line != ""){
						string[] lineData = line.Split(';');
						if(lineData[0] == "Player"){
							DialogueLine lineEntry = new DialogueLine(lineData[0],"",new Vector3(0,0,0));
							lineEntry.choices = new string[lineData.Length-1];
							for(int i = 1;i < lineData.Length;i++){
								lineEntry.choices[i-1] = lineData[i];
							}
							lines.Add(lineEntry);
						} else{
							string[] position = lineData[2].Split(',');
							DialogueLine lineEntry = new DialogueLine(lineData[0],lineData[1],new Vector3(float.Parse(position[0]),float.Parse(position[1]),float.Parse(position[2])));
							lines.Add(lineEntry);
						}
					} else{
						lines.Add(new DialogueLine("","",new Vector3(0,0,0)));
					}
				}
			} while (line != null);
			r.Close();
		}
	}

	public void AddLine(int index,string line){
		Debug.Log(index + " | " + line);
		if(line != null){
			if(line != ""){
				string[] lineData = line.Split(';');
				if(lineData[0] == "Player"){
					DialogueLine lineEntry = new DialogueLine(lineData[0],"",new Vector3(0,0,0));
					lineEntry.choices = new string[lineData.Length-1];
					for(int i = 1;i < lineData.Length;i++){
						lineEntry.choices[i-1] = lineData[i];
					}
					lines.Insert(index,lineEntry);
				} else{
					string[] position = lineData[2].Split(',');
					Debug.Log(lineData[0] + " | " + lineData[1] + " | " + lineData[2]);
					DialogueLine lineEntry = new DialogueLine(lineData[0],lineData[1],new Vector3(float.Parse(position[0]),float.Parse(position[1]),float.Parse(position[2])));
					lines.Insert(index,lineEntry);
				}
			} else{
				lines.Insert(index,new DialogueLine("","",new Vector3(0,0,0)));
			}
		}
	}

	public void ChangeLine(int index,string line){
		if(index > -1 && index < lines.Count){
			DialogueLine editLine = lines[index];
			editLine.line = line;
			lines[index] = editLine;
		}
	}

	public string GetName(int lineNum){
		if(lineNum < lines.Count){
			return lines[lineNum].name;
		}
		return "";
	}
	
	public string GetLine(int lineNum){
		Debug.Log("GetLine: " + lineNum + " | " + lines[lineNum].line);
		if(lineNum < lines.Count){
			return lines[lineNum].line;
		}
		return "";
	}
	
	public Vector3 GetPosition(int lineNum){
		if(lineNum < lines.Count){
			return lines[lineNum].position;
		}
		return new Vector3(0,0,0);
	}
	
	public string[] GetChoices(int lineNum){
		if(lineNum < lines.Count){
			return lines[lineNum].choices;
		}
		return new string[0];
	}
}
