using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;

    public GameObject cardPanelPrefab;
    public GameObject scrollArea;
    public Text coinCountText;
    public GameObject notEnoughCoinsPanel;

    public GameObject GoldEquipmentUnlockInfo;
    public GameObject AntiqueEquipmentUnlockInfo;
    public GameObject GoldAntiqueEquipmentUnlockInfo;

    public GameObject ChromeEquipmentInfo;
    public GameObject GoldEquipmentInfo;
    public GameObject AntiqueEquipmentInfo;
    public GameObject GoldAntiqueEquipmentInfo;


    public GameObject GoldEquipmentUnlocked;
    public GameObject AntiqueEquipmentUnlocked;
    public GameObject GoldAntiqueEquipmentUnlocked;

    public GameObject aYSPanelSM;
    public Button aYSbuttonSM;

 


    public void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    void Awake()
    {
        MakeInstance();
        if (cardPanelPrefab && GameManager.instance)
        {
            //MakeCardPanelRail();
        }
       
    }

    public void Start()
    {
        //findCanvasElements();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void findCanvasElements()
    {
        scrollArea = GameObject.FindWithTag("ScrollAreaOBJ");
        coinCountText = GameObject.FindWithTag("coinCountText").GetComponent<Text>();
        notEnoughCoinsPanel = GameObject.FindWithTag("notEnoughCoinsPanel");

        GoldEquipmentUnlockInfo = GameObject.FindWithTag("GoldEquipmentUnlockInfo");
        AntiqueEquipmentUnlockInfo = GameObject.FindWithTag("AntiqueEquipmentUnlockInfo");
        GoldAntiqueEquipmentUnlockInfo = GameObject.FindWithTag("GoldAntiqueEquipmentUnlockInfo");

        ChromeEquipmentInfo = GameObject.FindWithTag("ChromeEquipmentInfo");
        GoldEquipmentInfo = GameObject.FindWithTag("GoldEquipmentInfo");
        AntiqueEquipmentInfo = GameObject.FindWithTag("AntiqueEquipmentInfo");
        GoldAntiqueEquipmentInfo = GameObject.FindWithTag("GoldAntiqueEquipmentInfo");

        GoldEquipmentUnlocked = GameObject.FindWithTag("GoldEquipmentUnlocked");
        AntiqueEquipmentUnlocked = GameObject.FindWithTag("AntiqueEquipmentUnlocked");
        GoldAntiqueEquipmentUnlocked = GameObject.FindWithTag("GoldAntiqueEquipmentUnlocked");

        aYSPanelSM = GameObject.FindWithTag("AYSPanel");
        //aYSbuttonSM = GameObject.FindWithTag("AYSButton").GetComponent<Button>();

        deActivateCanvasElements();

    }

    public void deActivateCanvasElements()
    {
        notEnoughCoinsPanel.SetActive(false);
        GoldEquipmentUnlockInfo.SetActive(false);
        AntiqueEquipmentUnlockInfo.SetActive(false);
        GoldAntiqueEquipmentUnlockInfo.SetActive(false);

        ChromeEquipmentInfo.SetActive(false);
        GoldEquipmentInfo.SetActive(false);
        AntiqueEquipmentInfo.SetActive(false);
        GoldAntiqueEquipmentInfo.SetActive(false);

        GoldEquipmentUnlocked.SetActive(false);
        AntiqueEquipmentUnlocked.SetActive(false);
        GoldAntiqueEquipmentUnlocked.SetActive(false);
    }


    void AddScrollAbilities(int prefabsLength)
    {
        scrollArea.AddComponent<ScrollRect>();
        scrollArea.GetComponent<ScrollRect>().vertical = false;
        scrollArea.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;

        RectTransform scrollTransform = GameObject.Find("Card Holder").GetComponent<RectTransform>();
        float scrollLength = 25 * prefabsLength;
        scrollTransform.sizeDelta = new Vector2(scrollLength, 0);
        scrollArea.GetComponent<ScrollRect>().content = scrollTransform;
        scrollTransform.localPosition = new Vector3(2000f, 0, 0);
    }


    public void MakeCardPanelRail()
    {

        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().railPrefabs.Length; i++ )
        {
            GameObject rail = Instantiate(cardPanelPrefab);

            rail.gameObject.name = GameManager.instance.GetComponent<ItemArray>().railPrefabs[i].gameObject.name + " Panel";

            rail.transform.SetParent(CardHolder.transform);

            rail.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            rail.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().railPrefabs[i].gameObject.name;

            rail.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().railImages[i];

            rail.GetComponent<CardPanel>().itemImage.SetNativeSize();

            rail.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            rail.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().railPrefabs[i].GetComponent<Item>().cost.ToString(); 


            switch ("" + GameManager.instance.GetComponent<ItemArray>().railPrefabs[i].gameObject.name)
            {
                case "Chrome Rail":
                    rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    rail.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Rail":
                    if (GameManager.GOLDRAILCHECK == 0)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDRAILCHECK == 1)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        rail.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Rail":
                    if (GameManager.ANTIQUERAILCHECK == 0)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUERAILCHECK == 1)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        rail.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Rail":
                    if (GameManager.GOLDANTIQUERAILCHECK == 0)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUERAILCHECK == 1)
                    {
                        rail.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        rail.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().railPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelGear()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().gearPrefabs.Length; i++)
        {
            GameObject gearCard = Instantiate(cardPanelPrefab);

            gearCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().gearPrefabs[i].gameObject.name + " Panel";

            gearCard.transform.SetParent(CardHolder.transform);

            gearCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            gearCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().gearPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            gearCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().gearImages[i];

            gearCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            gearCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            gearCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().gearPrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().gearPrefabs[i].gameObject.name)
            {
                case "Chrome Gear":
                    gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    gearCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Gear":
                    if (GameManager.GOLDGEARCHECK == 0)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDGEARCHECK == 1)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        gearCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Gear":
                    if (GameManager.ANTIQUEGEARCHECK == 0)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEGEARCHECK == 1)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        gearCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Gear":
                    if (GameManager.GOLDANTIQUEGEARCHECK == 0)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEGEARCHECK == 1)
                    {
                        gearCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        gearCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().gearPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelHead()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().headPrefabs.Length; i++)
        {
            GameObject headCard = Instantiate(cardPanelPrefab);

            headCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().headPrefabs[i].gameObject.name + " Panel";

            headCard.transform.SetParent(CardHolder.transform);

            headCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            headCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().headPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            headCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().headImages[i];

            headCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            headCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            headCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().headPrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().headPrefabs[i].gameObject.name)
            {
                case "Chrome Head":
                    headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    headCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Head":
                    if (GameManager.GOLDHEADCHECK == 0)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDHEADCHECK == 1)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Head":
                    if (GameManager.ANTIQUEHEADCHECK == 0)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEHEADCHECK == 1)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Head":
                    if (GameManager.GOLDANTIQUEHEADCHECK == 0)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEHEADCHECK == 1)
                    {
                        headCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().headPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }

    public void MakeCardPanelBase()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().basePrefabs.Length; i++)
        {
            GameObject baseCard = Instantiate(cardPanelPrefab);

            baseCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().basePrefabs[i].gameObject.name + " Panel";

            baseCard.transform.SetParent(CardHolder.transform);

            baseCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            baseCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().basePrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            baseCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().baseImages[i];

            baseCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            baseCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            baseCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().basePrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().basePrefabs[i].gameObject.name)
            {
                case "Chrome Base":
                    baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    baseCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Base":
                    if (GameManager.GOLDBASECHECK == 0)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDBASECHECK == 1)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        baseCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Base":
                    if (GameManager.ANTIQUEBASECHECK == 0)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEBASECHECK == 1)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        baseCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Base":
                    if (GameManager.GOLDANTIQUEBASECHECK == 0)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEBASECHECK == 1)
                    {
                        baseCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        baseCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().basePrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelHeadset()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().headsetPrefabs.Length; i++)
        {
            GameObject headsetCard = Instantiate(cardPanelPrefab);

            headsetCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[i].gameObject.name + " Panel";

            headsetCard.transform.SetParent(CardHolder.transform);

            headsetCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            headsetCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            headsetCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().headsetImages[i];

            headsetCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            headsetCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            headsetCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().headsetPrefabs[i].gameObject.name)
            {
                case "Chrome Headset":
                    headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    headsetCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Headset":
                    if (GameManager.GOLDHEADSETCHECK == 0)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDHEADSETCHECK == 1)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headsetCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Headset":
                    if (GameManager.ANTIQUEHEADSETCHECK == 0)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEHEADSETCHECK == 1)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headsetCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Headset":
                    if (GameManager.GOLDANTIQUEHEADSETCHECK == 0)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEHEADSETCHECK == 1)
                    {
                        headsetCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        headsetCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().headsetPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }

    public void MakeCardPanelPole()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().headsetPrefabs.Length; i++)
        {
            GameObject poleCard = Instantiate(cardPanelPrefab);

            poleCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().polePrefabs[i].gameObject.name + " Panel";

            poleCard.transform.SetParent(CardHolder.transform);

            poleCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            poleCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().polePrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            poleCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().poleImages[i];

            poleCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            poleCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            poleCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().polePrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().polePrefabs[i].gameObject.name)
            {
                case "Chrome Pole":
                    poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    poleCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Pole":
                    if (GameManager.GOLDPOLECHECK == 0)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDPOLECHECK == 1)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        poleCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Pole":
                    if (GameManager.ANTIQUEPOLECHECK == 0)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEPOLECHECK == 1)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        poleCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Pole":
                    if (GameManager.GOLDANTIQUEPOLECHECK == 0)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEPOLECHECK == 1)
                    {
                        poleCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        poleCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().polePrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelSpeaker()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().headsetPrefabs.Length; i++)
        {
            GameObject speakerCard = Instantiate(cardPanelPrefab);

            speakerCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[i].gameObject.name + " Panel";

            speakerCard.transform.SetParent(CardHolder.transform);

            speakerCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            speakerCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            speakerCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().speakerImages[i];

            speakerCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            speakerCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            speakerCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().speakerPrefabs[i].gameObject.name)
            {
                case "Chrome Speaker":
                    speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    speakerCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Speaker":
                    if (GameManager.GOLDSPEAKERCHECK == 0)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDSPEAKERCHECK == 1)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        speakerCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Speaker":
                    if (GameManager.ANTIQUESPEAKERCHECK == 0)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUESPEAKERCHECK == 1)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        speakerCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Speaker":
                    if (GameManager.GOLDANTIQUESPEAKERCHECK == 0)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUESPEAKERCHECK == 1)
                    {
                        speakerCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        speakerCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().speakerPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelArmrod()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().armrodPrefabs.Length; i++)
        {
            GameObject armrodCard = Instantiate(cardPanelPrefab);

            armrodCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[i].gameObject.name + " Panel";

            armrodCard.transform.SetParent(CardHolder.transform);

            armrodCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            armrodCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            armrodCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().armrodImages[i];

            armrodCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            armrodCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = cardPanelPrefab.GetComponent<CardPanel>().itemImage.rectTransform.localScale;

            armrodCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[i].GetComponent<Item>().cost.ToString();


            switch ("" + GameManager.instance.GetComponent<ItemArray>().armrodPrefabs[i].gameObject.name)
            {
                case "Chrome Armrod":
                    armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    armrodCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    break;
                case "Gold Armrod":
                    if (GameManager.GOLDARMRODCHECK == 0)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDARMRODCHECK == 1)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        armrodCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Antique Armrod":
                    if (GameManager.ANTIQUEARMRODCHECK == 0)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.ANTIQUEARMRODCHECK == 1)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        armrodCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
                case "Gold Antique Armrod":
                    if (GameManager.GOLDANTIQUEARMRODCHECK == 0)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Buy";
                    }
                    else if (GameManager.GOLDANTIQUEARMRODCHECK == 1)
                    {
                        armrodCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                        armrodCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().armrodPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }



    public void MakeCardPanelEquipment()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs.Length; i++)
        {
            GameObject equipmentCard = Instantiate(cardPanelPrefab);

            equipmentCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs[i].gameObject.name + " Panel";

            equipmentCard.transform.SetParent(CardHolder.transform);

            equipmentCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            equipmentCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            equipmentCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().equipmentImages[i];

            equipmentCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            equipmentCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);

            //equipmentCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs[i].GetComponent<Item>().cost.ToString();
            //equipmentCard.GetComponent<CardPanel>().itemPrice.gameObject.SetActive(false);
            equipmentCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);

            switch ("" + GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs[i].gameObject.name)
            {
                case "Chrome Equipment":
                    equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;
                case "Gold Equipment":
                    if (GameManager.GOLDEQUIPMENTCHECK == 0)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Unlock";
                    }
                    else if (GameManager.GOLDEQUIPMENTCHECK == 1)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    }
                    break;
                case "Antique Equipment":
                    if (GameManager.ANTIQUEEQUIPMENTCHECK == 0)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Unlock";
                    }
                    else if (GameManager.ANTIQUEEQUIPMENTCHECK == 1)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    }
                    break;
                case "Gold Antique Equipment":
                    if (GameManager.GOLDANTIQUEEQUIPMENTCHECK == 0)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Unlock";
                    }
                    else if (GameManager.GOLDANTIQUEEQUIPMENTCHECK == 1)
                    {
                        equipmentCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    }
                    break;
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().equipmentPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }


    public void MakeCardPanelMusic()
    {
        GameObject CardHolder = GameObject.Find("Card Holder").transform.gameObject;

        foreach (Transform child in CardHolder.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < GameManager.instance.GetComponent<ItemArray>().musicPrefabs.Length; i++)
        {
            GameObject musicCard = Instantiate(cardPanelPrefab);

            musicCard.gameObject.name = GameManager.instance.GetComponent<ItemArray>().musicPrefabs[i].gameObject.name + " Panel";

            musicCard.transform.SetParent(CardHolder.transform);

            musicCard.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);

            musicCard.GetComponent<CardPanel>().itemName.text = GameManager.instance.GetComponent<ItemArray>().musicPrefabs[i].gameObject.name;  //sets the name of the card to the prefabs name *important for buyAndUseCard*

            musicCard.GetComponent<CardPanel>().itemImage.sprite = GameManager.instance.GetComponent<ItemArray>().musicImages[i];

            musicCard.GetComponent<CardPanel>().itemImage.SetNativeSize();

            musicCard.GetComponent<CardPanel>().itemImage.rectTransform.localScale = new Vector3(1, 1, 1);

            //musicCard.GetComponent<CardPanel>().itemPrice.text = GameManager.instance.GetComponent<ItemArray>().musicPrefabs[i].GetComponent<Item>().cost.ToString();
            musicCard.GetComponent<CardPanel>().coinImage.gameObject.SetActive(false);

            switch ("" + GameManager.instance.GetComponent<ItemArray>().musicPrefabs[i].gameObject.name)
            {
                case "Chrome Music":
                    musicCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    break;
 
                case "Antique Music":
                    if (GameManager.ANTIQUEMUSICCHECK == 0)
                    {
                        musicCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Unlock";
                    }
                    else if (GameManager.ANTIQUEMUSICCHECK == 1)
                    {
                        musicCard.GetComponent<CardPanel>().buyAndUseButton.GetComponentInChildren<Text>().text = "Use";
                    }
                    break;
                
            }

        }
        int arrayLength = GameManager.instance.GetComponent<ItemArray>().musicPrefabs.Length;
        AddScrollAbilities(arrayLength);
    }

    

    void Update()
    {
        coinCountText.text = SIS.DBManager.GetFunds("beats").ToString();
    }

    public void CloseNotEnoughCoinsPanel()
    {
        StoreManager.instance.notEnoughCoinsPanel.gameObject.SetActive(false);
    }

    public void closeGoldEquipmentUnlockInfoPanel()
    {
        StoreManager.instance.GoldEquipmentUnlockInfo.gameObject.SetActive(false);

    }
    public void closeAntiqueEquipmentUnlockInfoPanel()
    {
        StoreManager.instance.AntiqueEquipmentUnlockInfo.gameObject.SetActive(false);

    }

    public void closeGoldAntiqueEquipmentUnlockInfoPanel()
    {
        StoreManager.instance.GoldAntiqueEquipmentUnlockInfo.gameObject.SetActive(false);

    }

    public void closeChromeEquipmentInfoPanel()
    {
        StoreManager.instance.ChromeEquipmentInfo.gameObject.SetActive(false);

    }

    public void closeGoldEquipmentInfoPanel()
    {
        StoreManager.instance.GoldEquipmentInfo.gameObject.SetActive(false);

    }
    public void closeAntiqueEquipmentInfoPanel()
    {
        StoreManager.instance.AntiqueEquipmentInfo.gameObject.SetActive(false);

    }

    public void closeGoldAntiqueEquipmentInfoPanel()
    {
        StoreManager.instance.GoldAntiqueEquipmentInfo.gameObject.SetActive(false);

    }

    public void openGoldEquipmentUnlockedPanel() //instance can only be used to modify objects thare already exist and have already been set active
    {
        StoreManager.instance.GoldEquipmentUnlocked.gameObject.SetActive(true);
    }

    public void openAntiqueEquipmentUnlockedPanel()
    {
        StoreManager.instance.AntiqueEquipmentUnlocked.gameObject.SetActive(true);
        print("Activating antique");
    }

    public void openGoldAntiqueEquipmentUnlockedPanel()
    {
        StoreManager.instance.GoldAntiqueEquipmentUnlocked.gameObject.SetActive(true);
        print("Activating gold antique");
    }




}
