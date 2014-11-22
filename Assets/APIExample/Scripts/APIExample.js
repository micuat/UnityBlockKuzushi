public var guiSkin : GUISkin;

public var arcticCliffTexture : Texture2D;
public var arcticTexture1 : Texture2D;
public var arcticTexture2 : Texture2D;
public var arcticTexture3 : Texture2D;

public var temperateCliffTexture : Texture2D;
public var temperateTexture1 : Texture2D;
public var temperateTexture2 : Texture2D;
public var temperateTexture3 : Texture2D;

public var desertCliffTexture : Texture2D;
public var desertTexture1 : Texture2D;
public var desertTexture2 : Texture2D;
public var desertTexture3 : Texture2D;

private var buttonStyle : String = "button";

enum Action {None = 0, GenerateMountains = 1, GeneratePlains = 2, GenerateHellish = 3, ThermalErosion = 4, HydraulicErosion = 5, SmoothLight = 6, SmoothHeavy = 7, TextureArctic = 8, TextureTemperate = 9, TextureDesert = 10}

private var action : Action = Action.None;
private var drawGUI : boolean = false;

public function OnGUI() {
	GUI.skin = guiSkin;
	if (Event.current.type != EventType.Repaint) {
		if (action == Action.None) {
			buttonStyle = "button";
		} else {
			buttonStyle = "disabledButton";
		}
		if (action != Action.None && !drawGUI) {
			doAction();
		}
		if (drawGUI) {
			drawGUI = false;
		}
	}
	GUI.Box(Rect(0, Screen.height - 110, Screen.width, 110), "");
	if (buttonStyle == "disabledButton") {
		GUI.Label(Rect(Screen.width / 2 - 100, Screen.height / 2 - 67, 200, 25), "Working. Please wait...");
	}
	if (GUI.Button(Rect(5, Screen.height - 105, 180, 30), "Generate Terrain (Mountains)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.GenerateMountains;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(5, Screen.height - 70, 180, 30), "Generate Terrain (Plains)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.GeneratePlains;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(5, Screen.height - 35, 180, 30), "Generate Terrain (Hellish)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.GenerateHellish;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(190, Screen.height - 70, 180, 30), "Erode Terrain (Thermal)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.ThermalErosion;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(190, Screen.height - 35, 180, 30), "Erode Terrain (Hydraulic)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.HydraulicErosion;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(375, Screen.height - 70, 180, 30), "Smooth Terrain (Light)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.SmoothLight;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(375, Screen.height - 35, 180, 30), "Smooth Terrain (Heavy)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.SmoothHeavy;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(560, Screen.height - 105, 180, 30), "Texture Terrain (Arctic)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.TextureArctic;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(560, Screen.height - 70, 180, 30), "Texture Terrain (Temperate)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.TextureTemperate;
			drawGUI = true;
		}
	}
	if (GUI.Button(Rect(560, Screen.height - 35, 180, 30), "Texture Terrain (Desert)", buttonStyle)) {
		if (action == Action.None) {
			action = Action.TextureDesert;
			drawGUI = true;
		}
	}
}

public function doAction() : void {
	var go : GameObject = GameObject.Find("Terrain");
	var slopeStops : float[];
	var heightStops : float[];
	var textures : Texture2D[];
	switch (action) {
		case Action.GenerateMountains:
		go.GetComponent("TerrainToolkit").PerlinGenerator(4, 1.0, 8, 1);
		break;
		case Action.GeneratePlains:
		go.GetComponent("TerrainToolkit").PerlinGenerator(2, 0.5, 9, 1);
		break;
		case Action.GenerateHellish:
		go.GetComponent("TerrainToolkit").PerlinGenerator(11, 1, 7, 1);
		break;
		case Action.ThermalErosion:
		go.GetComponent("TerrainToolkit").FastThermalErosion(25, 10.0, 0.5);
		break;
		case Action.HydraulicErosion:
		go.GetComponent("TerrainToolkit").FastHydraulicErosion(25, 60.0, 1);
		break;
		case Action.SmoothLight:
		go.GetComponent("TerrainToolkit").SmoothTerrain(1, 0.25);
		break;
		case Action.SmoothHeavy:
		go.GetComponent("TerrainToolkit").SmoothTerrain(2, 0.5);
		break;
		case Action.TextureArctic:
		slopeStops = [20.0, 50.0];
		heightStops = [0.15, 0.3, 0.45, 0.6];
		textures = [arcticCliffTexture, arcticTexture1, arcticTexture2, arcticTexture3];
		go.GetComponent("TerrainToolkit").TextureTerrain(slopeStops, heightStops, textures);
		break;
		case Action.TextureTemperate:
		slopeStops = [20.0, 50.0];
		heightStops = [0.2, 0.4, 0.65, 0.9];
		textures = [temperateCliffTexture, temperateTexture1, temperateTexture2, temperateTexture3];
		go.GetComponent("TerrainToolkit").TextureTerrain(slopeStops, heightStops, textures);
		break;
		case Action.TextureDesert:
		slopeStops = [20.0, 50.0];
		heightStops = [0.2, 0.4, 0.6, 0.8];
		textures = [desertCliffTexture, desertTexture1, desertTexture2, desertTexture3];
		go.GetComponent("TerrainToolkit").TextureTerrain(slopeStops, heightStops, textures);
		break;
	}
	action = Action.None;
}

