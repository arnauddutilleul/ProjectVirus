using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerTech : MonoBehaviour
{
	[Header("What Menu Is Active?")]
	public bool advancedMenu = true;

	[Header("Simple Panels")]
	[Tooltip("The UI Panel holding the Home Screen elements")]
	public GameObject homeScreen;
	[Tooltip("The UI Panel holding the credits")]
	public GameObject creditsScreen;
	[Tooltip("The UI Panel holding the settings")]
	public GameObject systemScreen;
	[Tooltip("The UI Panel holding the CANCEL or ACCEPT Options for New Game")]
	public GameObject newGameScreen;
	[Tooltip("The UI Panel holding the YES or NO Options for Load Game")]
	public GameObject loadGameScreen;
	[Tooltip("The Loading Screen holding loading bar")]
	public GameObject loadingScreen;

	[Header("COLORS - Tint")]
	public Image[] panelGraphics;
	public Image[] blurs;
	public Color tint;

	[Header("ADVANCED - UI Elements & User Data")]
	[Tooltip("The Main Canvas Gameobject")]
	public CanvasScaler mainCanvas;
	[Tooltip("The dropdown menu containing all the resolutions that your game can adapt to")]
	public TMP_Dropdown ResolutionDropDown;
	private Resolution[] resolutions;
	[Tooltip("The text object in the Settings Panel displaying the current quality setting enabled")]
	public TMP_Text qualityText; // text displaying current selected quality
	[Tooltip("The icon showing the current quality selected in the Settings Panels")]
	public Animator qualityDisplay;
	private string[] qualityNames;
	private int tempQualityLevel;// store it for start up text update
	[Tooltip("The volume slider UI element in the Settings Screen")]
	public Slider audioSlider;

	[Tooltip("If a message is displaying indiciating FAILURE, this is the color of that error text")]
	public Color errorColor;
	[Tooltip("If a message is displaying indiciating SUCCESS, this is the color of that success text")]
	public Color successColor;
	public float messageDisplayLength = 2.0f;
	public Slider uiScaleSlider;
	float xScale = 0f;
	float yScale = 0f;

	[Header("Starting Options Values")]
	public int speakersDefault = 0;
	public int subtitleLanguageDefault = 0;


	[Header("Debug")]
	[Tooltip("If this is true, pressing 'R' will reload the scene.")]
	public bool reloadSceneButton = true;
	Transform tempParent;

	public void MoveToFront(GameObject currentObj){
		//tempParent = currentObj.transform.parent;
		tempParent = currentObj.transform;
		tempParent.SetAsLastSibling();
	}

	void Start(){
		// By default, starts on the home screen, disables others
		homeScreen.SetActive(true);
		if(creditsScreen != null)
		creditsScreen.SetActive(false);
		if(systemScreen != null)
		systemScreen.SetActive(false);
		if(loadingScreen != null)
		loadingScreen.SetActive(false);
		if(loadGameScreen != null)
		loadGameScreen.SetActive(false);
		if(newGameScreen != null)
		newGameScreen.SetActive(false);

		string m_Path;

		if(advancedMenu)
		{
			// Set Save Path to local
			m_Path = Application.dataPath;
		}

		// Set Colors if the user didn't before play
		for(int i = 0; i < panelGraphics.Length; i++)
        {
           panelGraphics[i].color = tint;
        }
		for(int i = 0; i < blurs.Length; i++)
        {
           blurs[i].material.SetColor("_Color",tint);
        }

		// Get quality settings names
		qualityNames = QualitySettings.names;

		// Get screens possible resolutions
		resolutions = Screen.resolutions;

		// Set Drop Down resolution options according to possible screen resolutions of your monitor
		if(ResolutionDropDown != null){
		for (int i = 0; i < resolutions.Length; i++){
				ResolutionDropDown.options.Add (new TMP_Dropdown.OptionData (ResToString (resolutions [i])));
	
				ResolutionDropDown.value = i;
	
				ResolutionDropDown.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions
				[ResolutionDropDown.value].width, resolutions[ResolutionDropDown.value].height, true);});
			}
		}
		 
		 // Check if first time so the volume can be set to MAX
		 if(PlayerPrefs.GetInt("firsttime")==0){
			 // it's the player's first time. Set to false now...
			 PlayerPrefs.SetInt("firsttime",1);
			 PlayerPrefs.SetFloat("volume",1);
		 }

		 // Check volume that was saved from last play
		 if(audioSlider != null)
		 audioSlider.value = PlayerPrefs.GetFloat("volume");
		 
	}

	public void UIScaler(){
		xScale = 1920 * uiScaleSlider.value;
		yScale = 1080 * uiScaleSlider.value;
		mainCanvas.referenceResolution = new Vector2 (xScale,yScale);
	}

	// Converts the resolution into a string form that is then used in the dropdown list as the options
	string ResToString(Resolution res)
	{
		return res.width + " x " + res.height;
	}

}
