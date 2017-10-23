using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Achievements : MonoBehaviour {

	public GameObject[] slots;
    public Journalizer jnr;
    public GameObject popUp;

    public static readonly string ACH_JOURNAL = "journal";
	public static readonly string ACH_TALK = "talk";
    public static readonly string ACH_SECURITY = "security";
	public static readonly string ACH_IWO = "iwo";
	public static readonly string ACH_KEYS = "keys";
	public static readonly string ACH_SOLVED = "solved";
	public static readonly string ACH_CHIMNEY = "chimney";
	public static readonly string ACH_BERTHA = "bertha";
	public static readonly string ACH_SOFTWARE_ARCHITECTURE = "sa";
	public static readonly string ACH_RED_HERRING = "red";
    public List<string> all_achs = new List<string>();

    public static string[] achievements = new string[]
    {
        ACH_JOURNAL, ACH_TALK, ACH_SECURITY, ACH_IWO,
        ACH_KEYS, ACH_SOLVED, ACH_CHIMNEY, ACH_BERTHA,
        ACH_SOFTWARE_ARCHITECTURE, ACH_RED_HERRING
    };

    public static bool[] isDisplayed = new bool[]
    {
        false, false, false, false,
        false, false, false, false,
        false, false
    };

    public int getAchievementId(string achieve)
    {
        int i = 0;
        foreach (string s in achievements)
        {
            if (s.Equals(achieve))
            {
                return i;
            }
            i++;
        }
        return 0; //basic;
    }
   
    


	private Dictionary<string, string[]> achievementStuff = new Dictionary<string, string[]> ();
	private Dictionary<string, GameObject> achievementBadges = new Dictionary<string, GameObject> ();
	private RectTransform contentPos;

	public void AddAchievement(string name) {

        int achievementId = getAchievementId(name);
        Debug.Log("achievement:" + achievementId);
        isDisplayed[achievementId] = true;
        Debug.Log("hey yo" + isDisplayed[achievementId]);
    //    itemImage.SetActive(true);
      //  isDisplayed[name] = true;
    }


    // Use this for initialization
    void Start () {

        achievementStuff[ACH_JOURNAL] = new string[] { "Restricted books allowed", "You have opened the Journal for the first time." };
        achievementStuff[ACH_TALK] = new string[] { "I would like to add you to my professional network", "You have talked to everyone in the manor." };
        achievementStuff[ACH_SECURITY] = new string[] { "Cracking the puzzle interview", "You have solved security room puzzle." };
        achievementStuff[ACH_IWO] = new string[] { "It depends", "You have talked to Iwo Tempo." };
        achievementStuff[ACH_KEYS] = new string[] { "Found private keys", "You have found all the keys." };
        achievementStuff[ACH_SOLVED] = new string[] { "Solved the murder", "You have correctly accused the murderer and solved the case." };
        achievementStuff[ACH_CHIMNEY] = new string[] { "It's getting hot in here", "You have escaped the chimney." };
        achievementStuff[ACH_BERTHA] = new string[] { "She's dead, Brange", "You have found Bertha's lifeless body." };
        achievementStuff[ACH_SOFTWARE_ARCHITECTURE] = new string[] { "Software Architect", "You have read the Software Architecture in Practice 3rd Edition by Bass, Clements and Kazman." };
        achievementStuff[ACH_RED_HERRING] = new string[] { "Red Herring", "You found the test fish. Please ignore." };

        achievementBadges[ACH_JOURNAL] = slots[0];
        achievementBadges[ACH_TALK] = slots[1];
        achievementBadges[ACH_SECURITY] = slots[2];
        achievementBadges[ACH_IWO] = slots[3];
        achievementBadges[ACH_KEYS] = slots[4];
        achievementBadges[ACH_SOLVED] = slots[5];
        achievementBadges[ACH_CHIMNEY] = slots[6];
        achievementBadges[ACH_BERTHA] = slots[7];
        achievementBadges[ACH_SOFTWARE_ARCHITECTURE] = slots[8];
        achievementBadges[ACH_RED_HERRING] = slots[9];

        updateAchs();


        

    }

    public void updateAchs()
    {

        for (int i = 0; i < 10; i++)
        {
            if (isDisplayed[i])
            {
                GameObject slot = achievementBadges[achievements[i]];
                Debug.Log("slot:"+slot);
                GameObject itemImage = slot.transform.GetChild(1).gameObject;
                Debug.Log(itemImage);
                itemImage.SetActive(true);
            }
            
        }
    }

    public void showPopUp(string name)
    {
        if (true)
        {
            foreach (GameObject obj in slots)
            {
                Button btn = obj.GetComponent<Button>();
                btn.interactable = false;
            }
            Text[] texts = popUp.GetComponentsInChildren<Text>();
            texts[0].text = achievementStuff[name][0];
            texts[1].text = achievementStuff[name][1];
            popUp.SetActive(true);
        }
    }

    public void closePopUp()
    {
        foreach (GameObject obj in slots)
        {
            Button btn = obj.GetComponent<Button>();
            btn.interactable = true;
        }
        popUp.SetActive(false);
    }
}
