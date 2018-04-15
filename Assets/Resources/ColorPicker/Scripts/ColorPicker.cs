using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorPicker : MonoBehaviour {

	//public references
	public static ColorPicker Instance { get; protected set; }
	//other vars
	public Color colorFinal = new Color(1f,0.855f,0.725f);
	public Color ColorFinal {
		get{
			return colorFinal;
		}
		set{
			colorFinal = value;
			isOn = !isOn;
		}	
	}
	Switch toggle;
	public bool menuOn;
	public bool isOn = false;
	Image preview;
	//RGB vars
	Slider rSlide;
	float rVal;
	Slider gSlide;
	float gVal;
	Slider bSlide;
	float bVal;
	//HSV vars
	Slider hSlide;
	float hVal;
	Slider sSlide;
	float sVal;
	Slider vSlide;
	float vVal;
	float C;
	float X;
	float M;

	void Start(){
		if (Instance != null) {
			Debug.LogError("ColorPicker: There should only ever be one ColorPicker.");
		}
		Instance = this;
		toggle = this.gameObject.GetComponentInChildren<Switch>();
		for(int i = 0;i < this.gameObject.transform.childCount;i++){
			switch(this.gameObject.transform.GetChild(i).name){
				case "RedSlider":
					rSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "GreenSlider":
					gSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "BlueSlider":
					bSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "HueSlider":
					hSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "SaturationSlider":
					sSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "ValueSlider":
					vSlide = this.gameObject.transform.GetChild(i).GetComponent<Slider>();
					break;
				case "Preview":
					preview = this.gameObject.transform.GetChild(i).GetComponent<Image>();
					break;
			}
		}
		if(toggle.isOn){
			if(!isOn){
				Vector3 hsv = RGBToHSV(colorFinal.r,colorFinal.g,colorFinal.b);
				hSlide.GetComponent<Slider> ().value = (hsv.x / 360);
				sSlide.GetComponent<Slider> ().value = hsv.y;
				vSlide.GetComponent<Slider> ().value = hsv.z;
				isOn = true;
			}
		} else {
			if(isOn){
				rSlide.GetComponent<Slider> ().value = colorFinal.r;
				gSlide.GetComponent<Slider> ().value = colorFinal.g;
				bSlide.GetComponent<Slider> ().value = colorFinal.b;
				isOn = false;
			}
		}
	}

	void Update(){
		if(toggle.isOn){
			if(!isOn){
				Vector3 hsv = RGBToHSV(colorFinal.r,colorFinal.g,colorFinal.b);
				hSlide.GetComponent<Slider> ().value = (hsv.x / 360);
				sSlide.GetComponent<Slider> ().value = hsv.y;
				vSlide.GetComponent<Slider> ().value = hsv.z;
				isOn = true;
			}
			toggle.transform.GetChild (2).GetComponent<Text> ().color = new Color (0.46666667f, 0.46666667f, 0.46666667f, 255);
			toggle.transform.GetChild (1).GetComponent<Text> ().color = new Color (0.8f, 0.8f, 0.8f, 255);
			rSlide.gameObject.SetActive (false);
			gSlide.gameObject.SetActive (false);
			bSlide.gameObject.SetActive (false);
			hSlide.gameObject.SetActive (true);
			sSlide.gameObject.SetActive (true);
			vSlide.gameObject.SetActive (true);
			hVal = hSlide.GetComponent<Slider> ().value * 360;
			sVal = sSlide.GetComponent<Slider> ().value;
			vVal = vSlide.GetComponent<Slider> ().value;
			Vector3 rgb = HSVToRGB(hVal,sVal,vVal);
			colorFinal = new Color ((rgb.x + M), (rgb.y + M), (rgb.z + M));
			sSlide.GetComponentInChildren<Image> ().color = colorFinal;
			vSlide.GetComponentInChildren<Image> ().color = colorFinal;
		} else {
			if(isOn){
				rSlide.GetComponent<Slider> ().value = colorFinal.r;
				gSlide.GetComponent<Slider> ().value = colorFinal.g;
				bSlide.GetComponent<Slider> ().value = colorFinal.b;
				isOn = false;
			}
			toggle.transform.GetChild (1).GetComponent<Text> ().color = new Color (0.46666667f, 0.46666667f, 0.46666667f, 255);
			toggle.transform.GetChild (2).GetComponent<Text> ().color = new Color (0.8f, 0.8f, 0.8f, 255);
			hSlide.gameObject.SetActive (false);
			sSlide.gameObject.SetActive (false);
			vSlide.gameObject.SetActive (false);
			rSlide.gameObject.SetActive (true);
			gSlide.gameObject.SetActive (true);
			bSlide.gameObject.SetActive (true);
			rVal = rSlide.GetComponent<Slider> ().value;
			gVal = gSlide.GetComponent<Slider> ().value;
			bVal = bSlide.GetComponent<Slider> ().value;
			colorFinal = new Color (rVal, gVal, bVal);
		}
		preview.color = colorFinal;
	}

	//X = R
	//Y = G
	//Z = B
	Vector3 HSVToRGB(float H, float S, float V){
		C = V * S;
		X = C * (1 - Mathf.Abs((H / 60) % 2 - 1));
		M = V - C;
		float R = 0;
		float G = 0;
		float B = 0;
		if (0 <= H && H < 60) {
			R = C;
			G = X;
			B = 0;
		} else if (60 <= H && H < 120) {
			R = X;
			G = C;
			B = 0;
		} else if (120 <= H && H < 180) {
			R = 0;
			G = C;
			B = X;
		} else if (180 <= H && H < 240) {
			R = 0;
			G = X;
			B = C;
		} else if (240 <= H && H < 300) {
			R = X;
			G = 0;
			B = C;
		} else if (300 <= H && H < 360) {
			R = C;
			G = 0;
			B = X;
		}
		return new Vector3(R,G,B);
	}

	//X = H
	//Y = S
	//Z = V
	Vector3 RGBToHSV(float R,float G,float B){
		float Cmax = Mathf.Max (R, G, B);
		float Cmin = Mathf.Min (R, G, B);
		C = Cmax - Cmin;
		float H = 0;
		float S = 0;
		float V = 0;
		if (C == 0) {
			H = 0;
		} else if(Cmax == R){
			H = 60 * (((G - B) / C) % 6);
		} else if(Cmax == G){
			H = 60 * (((B - R) / C) + 2);
		} else if(Cmax == B){
			H = 60 * (((R - G) / C) + 4);
		}
		if(Cmax == 0){
			S = 0;
		} else if(Cmax != 0){
			S = C / Cmax;
		}
		V = Cmax;
		return new Vector3(H,S,V);
	}
}
