using UnityEngine;
using System.Collections;

public class PlayerPrefsAddOns : MonoBehaviour {
	
	public static Color GetColor(string key,Color defaultValue = new Color()){
		if(PlayerPrefs.HasKey(key)){
			string value = PlayerPrefs.GetString(key);
			string[] subValues = value.Split(';');
			if(subValues.Length == 3){
				return new Color(float.Parse(subValues[0]),float.Parse(subValues[1]),float.Parse(subValues[2]));
			} else if(subValues.Length > 3){
				return new Color(float.Parse(subValues[0]),float.Parse(subValues[1]),float.Parse(subValues[2]),float.Parse(subValues[3]));
			}
		}
		return defaultValue;
	}

	public static void SetColor(string key,Color value){
		string finalValue = value.r.ToString() + ";" + value.g.ToString() + ";" + value.b.ToString() + ";" + value.a.ToString();
		PlayerPrefs.SetString(key,finalValue);
	}
	
	public static string[] GetStringArray(string key,string[] defaultValue = null){
		if(PlayerPrefs.HasKey(key)){
			string value = PlayerPrefs.GetString(key);
			string[] subValues = value.Split('~');
			return subValues;
		}
		return defaultValue==null ? new string[]{} : defaultValue;
	}
	
	public static void SetStringArray(string key,string[] value){
		string finalValue = "";
		for(int i=0;i < value.Length;i++){
			finalValue += value[i];
			if(i < value.Length-1){
				finalValue += "~";
			}
		}
		PlayerPrefs.SetString(key,finalValue);
	}
}
