using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class Item{
	public Texture2D tex;
	public float x;
	public float y;
	
	public Item(Texture2D tex,float x,float y){
		this.tex = tex;
		this.x = x;
		this.y = y;
	}
}

public class ItemInformation : MonoBehaviour {

	//maps
	static List<string> crimesMap;
	static List<string> stationsMap;

	//hair options
	static List<Item> femaleHair;
	static List<Item> maleHair;
	
	//top options
	static List<Item> femaleTop;
	static List<Item> maleTop;
	
	//bottom options
	static List<Item> femaleBottoms;
	static List<Item> maleBottoms;
	
	//shoes options
	static List<Item> femaleShoes;
	static List<Item> maleShoes;

	public static string GetCrimesMap(int i){
		if(crimesMap == null || crimesMap.Count <= 1){
			crimesMap = new List<string>();
			crimesMap.Add("Stealing");
			crimesMap.Add("Murder");
			crimesMap.Add("Arson");
			crimesMap.Add("Drug Use");
			crimesMap.Add("Attacking Someone");
		}
		if(i < 0 || i >= crimesMap.Count){
			return "";
		}
		return crimesMap[i];
	}

	public static int GetCrimesMapCount(){
		if(crimesMap == null || crimesMap.Count <= 1){
			crimesMap = new List<string>();
			crimesMap.Add("Stealing");
			crimesMap.Add("Murder");
			crimesMap.Add("Arson");
			crimesMap.Add("Drug Use");
			crimesMap.Add("Attacking Someone");
		}
		return crimesMap.Count;
	}
	
	public static string GetStationsMap(int i){
		if(stationsMap == null || stationsMap.Count <= 1){
			stationsMap = new List<string>();
			stationsMap.Add("Alpha Station");
			stationsMap.Add("Arrow Station");
			stationsMap.Add("Factory Station");
			stationsMap.Add("Farm Station");
			stationsMap.Add("Hydra Station");
			stationsMap.Add("Mecha Station");
			stationsMap.Add("Tesla Station");
		}
		if(i < 0 || i >= stationsMap.Count){
			return "";
		}
		return stationsMap[i];
	}

	public static int GetStationsMapCount(){
		if(stationsMap == null || stationsMap.Count <= 1){
			stationsMap = new List<string>();
			stationsMap.Add("Alpha Station");
			stationsMap.Add("Arrow Station");
			stationsMap.Add("Factory Station");
			stationsMap.Add("Farm Station");
			stationsMap.Add("Hydra Station");
			stationsMap.Add("Mecha Station");
			stationsMap.Add("Tesla Station");
		}
		return stationsMap.Count;
	}
	
	public static Item GetFemaleHair(int i){
		if(femaleHair == null || femaleHair.Count <= 1){
			Texture2D tex;
			femaleHair = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Hair/Hair.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Hair/" + node.Attributes[0].Value) as Texture2D;
				femaleHair.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= femaleHair.Count){
			return null;
		}
		return femaleHair[i];
	}
	
	public static int GetFemaleHairCount(){
		if(femaleHair == null || femaleHair.Count <= 1){
			Texture2D tex;
			femaleHair = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Hair/Hair.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Hair/" + node.Attributes[0].Value) as Texture2D;
				femaleHair.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return femaleHair.Count;
	}
	
	public static Item GetMaleHair(int i){
		if(maleHair == null || maleHair.Count <= 1){
			Texture2D tex;
			maleHair = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Hair/Hair.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Hair/" + node.Attributes[0].Value) as Texture2D;
				maleHair.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= maleHair.Count){
			return null;
		}
		return maleHair[i];
	}
	
	public static int GetMaleHairCount(){
		if(maleHair == null || maleHair.Count <= 1){
			Texture2D tex;
			maleHair = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Hair/Hair.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Hair/" + node.Attributes[0].Value) as Texture2D;
				maleHair.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return maleHair.Count;
	}
	
	public static Item GetFemaleTop(int i){
		if(femaleTop == null || femaleTop.Count <= 1){
			Texture2D tex;
			femaleTop = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Top/Top.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Top/" + node.Attributes[0].Value) as Texture2D;
				femaleTop.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= femaleTop.Count){
			return null;
		}
		return femaleTop[i];
	}
	
	public static int GetFemaleTopCount(){
		if(femaleTop == null || femaleTop.Count <= 1){
			Texture2D tex;
			femaleTop = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Top/Top.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Top/" + node.Attributes[0].Value) as Texture2D;
				femaleTop.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return femaleTop.Count;
	}
	
	public static Item GetMaleTop(int i){
		if(maleTop == null || maleTop.Count <= 1){
			Texture2D tex;
			maleTop = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Top/Top.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Top/" + node.Attributes[0].Value) as Texture2D;
				maleTop.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= maleTop.Count){
			return null;
		}
		return maleTop[i];
	}
	
	public static int GetMaleTopCount(){
		if(maleTop == null || maleTop.Count <= 1){
			Texture2D tex;
			maleTop = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Top/Top.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Top/" + node.Attributes[0].Value) as Texture2D;
				maleTop.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return maleTop.Count;
	}
	
	public static Item GetFemaleBottoms(int i){
		if(femaleBottoms == null || femaleBottoms.Count <= 1){
			Texture2D tex;
			femaleBottoms = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Bottoms/Bottoms.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Bottoms/" + node.Attributes[0].Value) as Texture2D;
				femaleBottoms.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= femaleBottoms.Count){
			return null;
		}
		return femaleBottoms[i];
	}
	
	public static int GetFemaleBottomsCount(){
		if(femaleBottoms == null || femaleBottoms.Count <= 1){
			Texture2D tex;
			femaleBottoms = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Bottoms/Bottoms.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Bottoms/" + node.Attributes[0].Value) as Texture2D;
				femaleBottoms.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return femaleBottoms.Count;
	}
	
	public static Item GetMaleBottoms(int i){
		if(maleBottoms == null || maleBottoms.Count <= 1){
			Texture2D tex;
			maleBottoms = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Bottoms/Bottoms.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Bottoms/" + node.Attributes[0].Value) as Texture2D;
				maleBottoms.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= maleBottoms.Count){
			return null;
		}
		return maleBottoms[i];
	}
	
	public static int GetMaleBottomsCount(){
		if(maleBottoms == null || maleBottoms.Count <= 1){
			Texture2D tex;
			maleBottoms = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Bottoms/Bottoms.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Bottoms/" + node.Attributes[0].Value) as Texture2D;
				maleBottoms.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return maleBottoms.Count;
	}
	
	public static Item GetFemaleShoes(int i){
		if(femaleShoes == null || femaleShoes.Count <= 1){
			Texture2D tex;
			femaleShoes = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Shoes/Shoes.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Shoes/" + node.Attributes[0].Value) as Texture2D;
				femaleShoes.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= femaleShoes.Count){
			return null;
		}
		return femaleShoes[i];
	}
	
	public static int GetFemaleShoesCount(){
		if(femaleShoes == null || femaleShoes.Count <= 1){
			Texture2D tex;
			femaleShoes = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Female/Shoes/Shoes.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Female/Shoes/" + node.Attributes[0].Value) as Texture2D;
				femaleShoes.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return femaleShoes.Count;
	}
	
	public static Item GetMaleShoes(int i){
		if(maleShoes == null || maleShoes.Count <= 1){
			Texture2D tex;
			maleShoes = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Shoes/Shoes.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Shoes/" + node.Attributes[0].Value) as Texture2D;
				maleShoes.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		if(i < 0 || i >= maleShoes.Count){
			return null;
		}
		return maleShoes[i];
	}
	
	public static int GetMaleShoesCount(){
		if(maleShoes == null || maleShoes.Count <= 1){
			Texture2D tex;
			maleShoes = new List<Item>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(Application.dataPath + "/Resources/CharacterCreation/Male/Shoes/Shoes.xml");
			XmlNode root = xmlDoc.DocumentElement;
			XmlNodeList nodeList = root.ChildNodes;
			foreach(XmlNode node in nodeList){
				tex = Resources.Load("CharacterCreation/Male/Shoes/" + node.Attributes[0].Value) as Texture2D;
				maleShoes.Add(new Item(tex,float.Parse(node.Attributes[1].Value),float.Parse(node.Attributes[2].Value)));
			}
		}
		return maleShoes.Count;
	}
}
