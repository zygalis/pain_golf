using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//this is where the batmenu is created
public class DropdownMenu : MonoBehaviour { 

    public RectTransform container; //where the batMenuItems are

    public bool isOpen;

    private GameObject bat;
    public Sprite[] sprites; //list for bat sprites
    public Sprite[] batMenuButtons; //list for bat menu button sprites

    List<Bat> bats = new List<Bat>(); //list for bats
    private Button button, batMenuButton, batSelected, baseballBat, racket, sledgehammer; //all the needed buttons

    void Awake()
    {
        bat = GameObject.Find("Bat"); //finding bat before it is disabled
    }
        void Start()
    {
        init();
        batMenuButton.onClick.AddListener(batMenuButtonClick);
        sprites = Resources.LoadAll<Sprite>("bats"); //loading all bat sprites to list
        batMenuButtons = Resources.LoadAll<Sprite>("inGameSprites"); //loading batMenuButton sprites to list
        container = transform.Find("Container").GetComponent<RectTransform>(); //getting container in which the batMenuItems are
        baseballBat = GameObject.Find("Baseball Bat").GetComponent<Button>();
        baseballBat.gameObject.SetActive(false); //setting baseball bat button false because it is the starting bat and doesn't need to be on the menu at first
        racket = GameObject.Find("Racket").GetComponent<Button>();
        sledgehammer = GameObject.Find("Sledgehammer").GetComponent<Button>();
        isOpen = false;
    }
    private void init()
    {
        batMenuButton = GameObject.Find("BatMenuButton").GetComponent<Button>(); //getting batmenu button 
        fillList(); //bats list
    }
    void Update()
    {
        //if clicked/tapped
        if (Input.GetMouseButtonDown(0))
        {
            //event system chechs the current gameobject which the finger is on
            if (EventSystem.current.IsPointerOverGameObject())
            {
                batSelected = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>(); //selected bat is the name on the button that's been activated
                
                //looping through bats list
                for (int i = 0; i < bats.Count; i++) {

                    //checking if selected batMenuButton's name is found on the list
                    if (batSelected.name == bats[i].name) {

                        //getting all bat sprites on sprites list
                        foreach (Sprite sprite in sprites)
                        {
                            //if name of the sprite is same as selected bats name
                            if (sprite.name == batSelected.name) 
                            {
                                //looping through sprites list
                                for (int j = 0; j < sprites.Length; j++) {

                                    //if selected bat is found in sprites list
                                    if (batSelected.name == sprites[j].name) {
                                        bat.GetComponentInChildren<SpriteRenderer>().sprite = sprites[j]; //changing the bat sprite in to selected bat sprite                                       
                                    }
                                } 
                            }
                        }

                        //getting all batmenubutton sprites from batMenuButtons list
                        foreach (Sprite batButton in batMenuButtons)
                        {
                            //checking if selected batMenuButton's name is found on the list
                            if (batButton.name == batSelected.name)
                            {
                                //looping throught batMenuButtons list
                                for (int j = 0; j < batMenuButtons.Length; j++)
                                {
                                    //if selected bat is found in sprites list
                                    if (batSelected.name == batMenuButtons[j].name)
                                    {
                                        
                                        batMenuButton.GetComponent<Image>().sprite = batMenuButtons[j];

                                        //this is where clicket batmenubutton is disabled and old one is enabled
                                        if (batSelected.name == "Baseball Bat") {
                                            batSelected.gameObject.SetActive(false);
                                            sledgehammer.gameObject.SetActive(true); 
                                            racket.gameObject.SetActive(true);
                                            racket.gameObject.transform.position = new Vector3(baseballBat.gameObject.transform.position.x, baseballBat.gameObject.transform.position.y, baseballBat.gameObject.transform.position.z);
                                            
                                        }
                                        else if (batSelected.name == "Racket") { 
                                            batSelected.gameObject.SetActive(false);
                                            baseballBat.gameObject.SetActive(true);
                                            sledgehammer.gameObject.SetActive(true);
                                        }
                                        else if (batSelected.name == "Sledgehammer")
                                        {
                                            batSelected.gameObject.SetActive(false);
                                            racket.gameObject.SetActive(true);
                                            baseballBat.gameObject.SetActive(true);
                                            racket.gameObject.transform.position = new Vector3(sledgehammer.gameObject.transform.position.x, sledgehammer.gameObject.transform.position.y, sledgehammer.gameObject.transform.position.z);
                                        }
                                    }
                                }
                            }
                        }
                        isOpen = false;
                    }
                }
            }
        }
        Vector3 scale = container.localScale;
        scale.x = Mathf.Lerp(scale.x, isOpen ? 1 : 0, Time.deltaTime * 17); //speed in which the bat menu opens
        container.localScale = scale;

    }
    //checking if bat menu is open or not
    void batMenuButtonClick()
    {
        if (isOpen)
        {
            isOpen = false;
        }
        else if (!isOpen)
        {
            isOpen = true;
        }

    }

    //list of bats and their values
    public void fillList()
    {
        bats.Add(new Bat("Baseball Bat", "", 15, 2));
        bats.Add(new Bat("Racket", "", 10, 2));
        bats.Add(new Bat("Sledgehammer", "", 25, 5));
        
    }
}


