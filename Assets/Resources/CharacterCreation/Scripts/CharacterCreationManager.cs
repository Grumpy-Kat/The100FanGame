using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

public class CharacterCreationManager : MonoBehaviour {

	public GameObject canvas;

	//character
	public Image bodyObj;
	public Image hairObj;
	public Image eyesObj;
	public Image innerEyesObj;
	public Image mouthObj;
	public Image topObj;
	public Image bottomsObj;
	public Image shoesObj;

	//panels
	GameObject informationPanel;
	GameObject appearancePanel;

	//menus
	GameObject colorPicker;
	GameObject hairMenu;
	GameObject topMenu;
	GameObject bottomsMenu;
	GameObject shoesMenu;

	//information values
	string charName = "";
	string gender = "Female";
	int crime;
	int station;

	//appearance values
	Color skinTone = new Color(1f,0.855f,0.725f);
	int hair = 0;
	Color hairColor = new Color(0.235f,0.149f,0.122f);
	Color eyeColor = new Color(0.2f,0.478f,0.173f);
	int top = 0;
	Color topColor = new Color(1f,1f,1f);
	int bottoms = 0;
	Color bottomsColor = new Color(0f,0f,0f);
	int shoes = 0;
	Color shoesColor = new Color(0.7f,0.7f,0.7f);

	//prefabs
	public GameObject buttonPrefab;

	string activeObj = "";
	
	void Start(){
		informationPanel = canvas.transform.Find("Tabs/Information/InformationPanel").gameObject;
		appearancePanel = canvas.transform.Find("Tabs/Appearance/AppearancePanel").gameObject;
		colorPicker = appearancePanel.transform.Find("ColorPicker").gameObject;
		hairMenu = appearancePanel.transform.Find("HairMenu").gameObject;
		topMenu = appearancePanel.transform.Find("TopMenu").gameObject;
		bottomsMenu = appearancePanel.transform.Find("BottomsMenu").gameObject;
		shoesMenu = appearancePanel.transform.Find("ShoesMenu").gameObject;
		bodyObj.color = skinTone;
		hairObj.color = hairColor;
		innerEyesObj.color = eyeColor;
		topObj.color = topColor;
		bottomsObj.color = bottomsColor;
		shoesObj.color = shoesColor;
	}

	void Update(){
		switch(activeObj){
			case "SkinTone":
				if(colorPicker != null){
					skinTone = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					bodyObj.color = skinTone;
				}
				break;
			case "Hair":
				if(hairMenu != null){
					hair = int.Parse(hairMenu.GetComponent<ButtonGroup>().currSelectedButton.name);
					Texture2D hairTex;
					if(gender == "Female"){
						hairTex = ItemInformation.GetFemaleHair(hair).tex;
						hairObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleHair(hair).x,ItemInformation.GetFemaleHair(hair).y,0);
					} else{
						hairTex = ItemInformation.GetMaleHair(hair).tex;
						hairObj.transform.localPosition = new Vector3(ItemInformation.GetMaleHair(hair).x,ItemInformation.GetMaleHair(hair).y,0);
					}
					hairObj.sprite = Sprite.Create(hairTex,new Rect(0,0,hairTex.width,hairTex.height),new Vector2(0.5f,0.5f));
				}
				break;
			case "HairColor":
				if(colorPicker != null){
					hairColor = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					hairObj.color = hairColor;
				}
				break;
			case "EyeColor":
				if(colorPicker != null){
					eyeColor = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					innerEyesObj.color = eyeColor;
				}
				break;
			case "Top":
				if(topMenu != null){
					top = int.Parse(topMenu.GetComponent<ButtonGroup>().currSelectedButton.name);
					Texture2D topTex;
					if(gender == "Female"){
						topTex = ItemInformation.GetFemaleTop(top).tex;
						topObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleTop(top).x,ItemInformation.GetFemaleTop(top).y,0);
					} else{
						topTex = ItemInformation.GetMaleTop(top).tex;
						topObj.transform.localPosition = new Vector3(ItemInformation.GetMaleTop(top).x,ItemInformation.GetMaleTop(top).y,0);
					}
					topObj.sprite = Sprite.Create(topTex,new Rect(0,0,topTex.width,topTex.height),new Vector2(0.5f,0.5f));
				}
				break;
			case "TopColor":
				if(colorPicker != null){
					topColor = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					topObj.color = topColor;
				}
				break;
			case "Bottoms":
				if(bottomsMenu != null){
					bottoms = int.Parse(bottomsMenu.GetComponent<ButtonGroup>().currSelectedButton.name);
					Texture2D bottomsTex;
					if(gender == "Female"){
						bottomsTex = ItemInformation.GetFemaleBottoms(bottoms).tex;
						bottomsObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleBottoms(bottoms).x,ItemInformation.GetFemaleBottoms(bottoms).y,0);
					} else{
						bottomsTex = ItemInformation.GetMaleBottoms(bottoms).tex;
						bottomsObj.transform.localPosition = new Vector3(ItemInformation.GetMaleBottoms(bottoms).x,ItemInformation.GetMaleBottoms(bottoms).y,0);
					}
					bottomsObj.sprite = Sprite.Create(bottomsTex,new Rect(0,0,bottomsTex.width,bottomsTex.height),new Vector2(0.5f,0.5f));
				}
				break;
			case "BottomsColor":
				if(colorPicker != null){
					bottomsColor = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					bottomsObj.color = bottomsColor;
				}
				break;
			case "Shoes":
				if(shoesMenu != null){
					shoes = int.Parse(shoesMenu.GetComponent<ButtonGroup>().currSelectedButton.name);
					Texture2D shoesTex;
					if(gender == "Female"){
						shoesTex = ItemInformation.GetFemaleShoes(shoes).tex;
						shoesObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleShoes(shoes).x,ItemInformation.GetFemaleShoes(shoes).y,0);
					} else{
						shoesTex = ItemInformation.GetMaleShoes(shoes).tex;
						shoesObj.transform.localPosition = new Vector3(ItemInformation.GetMaleShoes(shoes).x,ItemInformation.GetMaleShoes(shoes).y,0);
					}
					shoesObj.sprite = Sprite.Create(shoesTex,new Rect(0,0,shoesTex.width,shoesTex.height),new Vector2(0.5f,0.5f));
				}
				break;
			case "ShoesColor":
				if(colorPicker != null){
					shoesColor = colorPicker.GetComponent<ColorPicker>().ColorFinal;
					shoesObj.color = shoesColor;
				}
				break;
			default:
				break;
		}
	}

	public void OpenSkinToneMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = skinTone;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "SkinTone";
	}

	public void OpenHairMenu(){
		if(colorPicker != null){
			colorPicker.SetActive(false);
		}
		if(hairMenu != null){
			hairMenu.SetActive(true);
		}
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		float x = -33.5f;
		float y = 160f;
		ButtonGroup buttons = hairMenu.GetComponent<ButtonGroup>();
		int count = 0;
		if(gender == "Female"){
			count = ItemInformation.GetFemaleHairCount();
		} else{
			count = ItemInformation.GetMaleHairCount();
		}
		for(int i = 0;i < count;i++){
			GameObject option = (GameObject)GameObject.Instantiate(buttonPrefab,new Vector3(x,y,0),Quaternion.identity);
			option.transform.SetParent(hairMenu.transform,false);
			option.name = i.ToString();
			Texture2D hairTex;
			if(gender == "Female"){
				hairTex = ItemInformation.GetFemaleHair(i).tex;
			} else{
				hairTex = ItemInformation.GetMaleHair(i).tex;
			}
			option.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(hairTex,new Rect(0,0,hairTex.width,hairTex.height),new Vector2(0.5f,0.5f));
			option.transform.GetChild(0).GetComponent<Image>().color = hairColor;
			buttons.AddToButtons(option.GetComponent<Button>());
			if(i == hair){
				buttons.currSelectedButton = option.GetComponent<Button>();
			}
			if(i%2 == 0){
				x = 33.5f;
			} else{
				x = -33.5f;
				y -= 60;
			}
		}
		activeObj = "Hair";
	}

	public void OpenHairColorMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = hairColor;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "HairColor";
	}

	public void OpenEyeColorMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = eyeColor;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "EyeColor";
	}

	public void OpenTopMenu(){
		if(colorPicker != null){
			colorPicker.SetActive(false);
		}
		if(topMenu != null){
			topMenu.SetActive(true);
		}
		CloseHairMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		float x = -33.5f;
		float y = 160f;
		ButtonGroup buttons = topMenu.GetComponent<ButtonGroup>();
		int count = 0;
		if(gender == "Female"){
			count = ItemInformation.GetFemaleTopCount();
		} else{
			count = ItemInformation.GetMaleTopCount();
		}
		for(int i = 0;i < count;i++){
			GameObject option = (GameObject)GameObject.Instantiate(buttonPrefab,new Vector3(x,y,0),Quaternion.identity);
			option.transform.SetParent(topMenu.transform,false);
			option.name = i.ToString();
			Texture2D topTex;
			if(gender == "Female"){
				topTex = ItemInformation.GetFemaleTop(i).tex;
			} else{
				topTex = ItemInformation.GetMaleTop(i).tex;
			}
			option.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(topTex,new Rect(0,0,topTex.width,topTex.height),new Vector2(0.5f,0.5f));
			option.transform.GetChild(0).GetComponent<Image>().color = topColor;
			buttons.AddToButtons(option.GetComponent<Button>());
			if(i == top){
				buttons.currSelectedButton = option.GetComponent<Button>();
			}
			if(i%2 == 0){
				x = 33.5f;
			} else{
				x = -33.5f;
				y -= 60;
			}
		}
		activeObj = "Top";
	}
	
	public void OpenTopColorMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = topColor;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "TopColor";
	}

	public void OpenBottomsMenu(){
		if(colorPicker != null){
			colorPicker.SetActive(false);
		}
		if(bottomsMenu != null){
			bottomsMenu.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseShoesMenu();
		float x = -33.5f;
		float y = 160f;
		ButtonGroup buttons = bottomsMenu.GetComponent<ButtonGroup>();
		int count = 0;
		if(gender == "Female"){
			count = ItemInformation.GetFemaleBottomsCount();
		} else{
			count = ItemInformation.GetMaleBottomsCount();
		}
		for(int i = 0;i < count;i++){
			GameObject option = (GameObject)GameObject.Instantiate(buttonPrefab,new Vector3(x,y,0),Quaternion.identity);
			option.transform.SetParent(bottomsMenu.transform,false);
			option.name = i.ToString();
			Texture2D bottomsTex;
			if(gender == "Female"){
				bottomsTex = ItemInformation.GetFemaleBottoms(i).tex;
			} else{
				bottomsTex = ItemInformation.GetMaleBottoms(i).tex;
			}
			option.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(bottomsTex,new Rect(0,0,bottomsTex.width,bottomsTex.height),new Vector2(0.5f,0.5f));
			option.transform.GetChild(0).GetComponent<Image>().color = bottomsColor;
			buttons.AddToButtons(option.GetComponent<Button>());
			if(i == bottoms){
				buttons.currSelectedButton = option.GetComponent<Button>();
			}
			if(i%2 == 0){
				x = 33.5f;
			} else{
				x = -33.5f;
				y -= 60;
			}
		}
		activeObj = "Bottoms";
	}
	
	public void OpenBottomsColorMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = bottomsColor;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "BottomsColor";
	}
	
	public void OpenShoesMenu(){
		if(colorPicker != null){
			colorPicker.SetActive(false);
		}
		if(shoesMenu != null){
			shoesMenu.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		float x = -33.5f;
		float y = 160f;
		ButtonGroup buttons = shoesMenu.GetComponent<ButtonGroup>();
		int count = 0;
		if(gender == "Female"){
			count = ItemInformation.GetFemaleShoesCount();
		} else{
			count = ItemInformation.GetMaleShoesCount();
		}
		for(int i = 0;i < count;i++){
			GameObject option = (GameObject)GameObject.Instantiate(buttonPrefab,new Vector3(x,y,0),Quaternion.identity);
			option.transform.SetParent(shoesMenu.transform,false);
			option.name = i.ToString();
			Texture2D shoesTex;
			if(gender == "Female"){
				shoesTex = ItemInformation.GetFemaleShoes(shoes).tex;
			} else{
				shoesTex = ItemInformation.GetMaleShoes(shoes).tex;
			}
			option.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(shoesTex,new Rect(0,0,shoesTex.width,shoesTex.height),new Vector2(0.5f,0.5f));
			option.transform.GetChild(0).GetComponent<Image>().color = bottomsColor;
			buttons.AddToButtons(option.GetComponent<Button>());
			if(i == shoes){
				buttons.currSelectedButton = option.GetComponent<Button>();
			}
			if(i%2 == 0){
				x = 33.5f;
			} else{
				x = -33.5f;
				y -= 60;
			}
		}
		activeObj = "Shoes";
	}
	
	public void OpenShoesColorMenu(){
		if(colorPicker != null){
			colorPicker.GetComponent<ColorPicker>().ColorFinal = shoesColor;
			colorPicker.SetActive(true);
		}
		CloseHairMenu();
		CloseTopMenu();
		CloseBottomsMenu();
		CloseShoesMenu();
		activeObj = "ShoesColor";
	}
	
	public void CloseHairMenu(){
		if(hairMenu != null && hairMenu.activeSelf){
			hairMenu.SetActive(false);
			for(int i = 0;i < hairMenu.transform.childCount;i++){
				GameObject.Destroy(hairMenu.transform.GetChild(i).gameObject);
			}
			hairMenu.GetComponent<ButtonGroup>().buttons.Clear();
			hairMenu.GetComponent<ButtonGroup>().currSelectedButton = null;
		}
	}
	
	public void CloseTopMenu(){
		if(topMenu != null && topMenu.activeSelf){
			topMenu.SetActive(false);
			for(int i = 0;i < topMenu.transform.childCount;i++){
				GameObject.Destroy(topMenu.transform.GetChild(i).gameObject);
			}
			topMenu.GetComponent<ButtonGroup>().buttons.Clear();
			topMenu.GetComponent<ButtonGroup>().currSelectedButton = null;
		}
	}
	
	public void CloseBottomsMenu(){
		if(bottomsMenu != null && bottomsMenu.activeSelf){
			bottomsMenu.SetActive(false);
			for(int i = 0;i < bottomsMenu.transform.childCount;i++){
				GameObject.Destroy(bottomsMenu.transform.GetChild(i).gameObject);
			}
			bottomsMenu.GetComponent<ButtonGroup>().buttons.Clear();
			bottomsMenu.GetComponent<ButtonGroup>().currSelectedButton = null;
		}
	}
	
	public void CloseShoesMenu(){
		if(shoesMenu != null && shoesMenu.activeSelf){
			shoesMenu.SetActive(false);
			for(int i = 0;i < shoesMenu.transform.childCount;i++){
				GameObject.Destroy(shoesMenu.transform.GetChild(i).gameObject);
			}
			shoesMenu.GetComponent<ButtonGroup>().buttons.Clear();
			shoesMenu.GetComponent<ButtonGroup>().currSelectedButton = null;
		}
	}
	
	public void SetName(){
		Transform transform = informationPanel.transform.FindChild("Name") ;
		charName = transform.GetComponent<InputField>().text;
	}

	public void SetGender(bool female){
		if(female){
			gender = "Female";
			hair = 0;
			top = 0;
			bottoms = 0;
			shoes = 0;
			eyesObj.transform.localPosition = new Vector3(-17.3f,259f,0f);
			innerEyesObj.transform.localPosition = new Vector3(-17.3f,259f,0f);
			mouthObj.transform.localPosition = new Vector3(-17.3f,230.7f,0f);
		} else{
			gender = "Male";
			hair = 0;
			top = 0;
			bottoms = 0;
			shoes = 0;
			eyesObj.transform.localPosition = new Vector3(8.6f,279f,0f);
			innerEyesObj.transform.localPosition = new Vector3(8.6f,279f,0f);
			mouthObj.transform.localPosition = new Vector3(8.6f,250.3f,0f);
		}
		Texture2D bodyTex;
		bodyTex = Resources.Load("CharacterCreation/" + gender + "/" + gender) as Texture2D;
		bodyObj.sprite = Sprite.Create(bodyTex,new Rect(0,0,bodyTex.width,bodyTex.height),new Vector2(0.5f,0.5f));
		Texture2D hairTex,topTex,bottomsTex,shoesTex;
		if(gender == "Female"){
			hairTex = ItemInformation.GetFemaleHair(hair).tex;
			hairObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleHair(hair).x,ItemInformation.GetFemaleHair(hair).y,0);
			topTex = ItemInformation.GetFemaleTop(top).tex;
			topObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleTop(top).x,ItemInformation.GetFemaleTop(top).y,0);
			bottomsTex = ItemInformation.GetFemaleBottoms(bottoms).tex;
			bottomsObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleBottoms(bottoms).x,ItemInformation.GetFemaleBottoms(bottoms).y,0);
			shoesTex = ItemInformation.GetFemaleShoes(shoes).tex;
			shoesObj.transform.localPosition = new Vector3(ItemInformation.GetFemaleShoes(shoes).x,ItemInformation.GetFemaleShoes(shoes).y,0);
		} else{
			hairTex = ItemInformation.GetMaleHair(hair).tex;
			hairObj.transform.localPosition = new Vector3(ItemInformation.GetMaleHair(hair).x,ItemInformation.GetMaleHair(hair).y,0);
			topTex = ItemInformation.GetMaleTop(top).tex;
			topObj.transform.localPosition = new Vector3(ItemInformation.GetMaleTop(top).x,ItemInformation.GetMaleTop(top).y,0);
			bottomsTex = ItemInformation.GetMaleBottoms(bottoms).tex;
			bottomsObj.transform.localPosition = new Vector3(ItemInformation.GetMaleBottoms(bottoms).x,ItemInformation.GetMaleBottoms(bottoms).y,0);
			shoesTex = ItemInformation.GetMaleShoes(shoes).tex;
			shoesObj.transform.localPosition = new Vector3(ItemInformation.GetMaleShoes(shoes).x,ItemInformation.GetMaleShoes(shoes).y,0);
		}
		hairObj.sprite = Sprite.Create(hairTex,new Rect(0,0,hairTex.width,hairTex.height),new Vector2(0.5f,0.5f));
		topObj.sprite = Sprite.Create(topTex,new Rect(0,0,topTex.width,topTex.height),new Vector2(0.5f,0.5f));
		bottomsObj.sprite = Sprite.Create(bottomsTex,new Rect(0,0,bottomsTex.width,bottomsTex.height),new Vector3(0.5f,0.5f));
		shoesObj.sprite = Sprite.Create(shoesTex,new Rect(0,0,shoesTex.width,shoesTex.height),new Vector3(0.5f,0.5f));
		Texture2D eyesTex;
		eyesTex = Resources.Load("CharacterCreation/" + gender + "/" + gender + "Eyes") as Texture2D;
		eyesObj.sprite = Sprite.Create(eyesTex,new Rect(0,0,eyesTex.width,eyesTex.height),new Vector2(0.5f,0.5f));
		Texture2D innerEyesTex;
		innerEyesTex = Resources.Load("CharacterCreation/" + gender + "/" + gender + "InnerEyes") as Texture2D;
		innerEyesObj.sprite = Sprite.Create(innerEyesTex,new Rect(0,0,innerEyesTex.width,innerEyesTex.height),new Vector2(0.5f,0.5f));
		Texture2D mouthTex;
		mouthTex = Resources.Load("CharacterCreation/" + gender + "/" + gender + "Mouth") as Texture2D;
		mouthObj.sprite = Sprite.Create(mouthTex,new Rect(0,0,mouthTex.width,mouthTex.height),new Vector2(0.5f,0.5f));
	}
	
	public void SetCrime(){
		Transform transform = informationPanel.transform.FindChild("Crime") ;
		crime = transform.GetComponent<Dropdown>().value;
	}
	
	public void SetStation(){
		Transform transform = informationPanel.transform.FindChild("Station") ;
		station = transform.GetComponent<Dropdown>().value;
	}

	public void Enter(){
		PlayerPrefs.SetString("Name",charName);
		PlayerPrefs.SetString("Gender",gender);
		if(gender == "Female"){
			PlayerPrefs.SetString("GenderSvHCapital","She");
			PlayerPrefs.SetString("GenderSvH","she");
			PlayerPrefs.SetString("GenderHvHCapital","Her");
			PlayerPrefs.SetString("GenderHvH","her");
		} else{
			PlayerPrefs.SetString("GenderSvHCapital","He");
			PlayerPrefs.SetString("GenderSvH","he");
			PlayerPrefs.SetString("GenderHvhCapital","Him");
			PlayerPrefs.SetString("GenderHvh","him");
		}
		PlayerPrefs.SetString("Crime",ItemInformation.GetCrimesMap(crime));
		PlayerPrefs.SetString("Station",ItemInformation.GetStationsMap(station));
		PlayerPrefsAddOns.SetColor("SkinTone",skinTone);
		PlayerPrefs.SetString("Hair",hair.ToString());
		PlayerPrefsAddOns.SetColor("HairColor",hairColor);
		PlayerPrefsAddOns.SetColor("EyeColor",eyeColor);
		PlayerPrefs.SetString("Top",top.ToString());
		PlayerPrefsAddOns.SetColor("TopColor",topColor);
		PlayerPrefs.SetString("Bottoms",bottoms.ToString());
		PlayerPrefsAddOns.SetColor("BottomsColor",bottomsColor);
		PlayerPrefs.SetString("Shoes",shoes.ToString());
		PlayerPrefsAddOns.SetColor("ShoesColor",shoesColor);
	}
}
