using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject XSCanvas;
    public GameObject IphoneFourCanvas;
    public GameObject IphoneFiveToEightCanvas;
    public GameObject IpadCanvas;

    public GameObject mainCanvas;
    public GameObject guiCanvas;

    public bool iPadTest;

    public double screenRatio;

    [Header("Main Menu Scene")]
    public GameObject MainMManager;
    public GameObject VManager;
    public bool MainMenu;


    [Header("Garage Scene")]
    public GameObject equipmentController;
    public GameObject StoreM;
    public bool GarageMenu;
   

    void Start()
    {
        if (MainMenu)
        {
            VManager = GameObject.FindWithTag("VolumeManager");
        }
        screenRatio = (1.0 * Screen.height) / (1.0 * Screen.width);

        /*if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(7800, 900);
            if (guiCanvas)
            {
                guiCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(7800, 900);
                guiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            }
        }*/

            if (SystemInfo.deviceModel.Contains("iPad") || iPadTest)
        {
            //IpadCanvas.SetActive(true);
            mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(3050, 960);
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            if (guiCanvas)
            {
                guiCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(3050, 960);
                guiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            }
        }

        else if (screenRatio > 1.4 && screenRatio < 1.6f) //3:2 Iphones - models 4 and earlier
        {
            //IphoneFourCanvas.SetActive(true);
            //IphoneFiveToEightCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2()
            mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2700, 960);
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            if (guiCanvas)
            {
                guiCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2700, 960);
                guiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            }
        }

        else if (screenRatio > 1.7 && screenRatio < 1.8) // 16:9 Iphones - models 5, SE, up to 8+
        {
            //IphoneFiveToEightCanvas.SetActive(true);
            mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2300, 960);
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            if (guiCanvas)
            {
                guiCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2300, 960);
                guiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            }
        }

        else if (screenRatio > 2.1 && screenRatio < 2.2) //19.5:9 Iphones - models X, Xs, Xr, Xsmax
        {
            //XSCanvas.SetActive(true);
            mainCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2800, 960);
            mainCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            if (guiCanvas)
            {
                guiCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2800, 960);
                guiCanvas.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
            }
        }

        if (MainMenu)
        {
            //MainMManager.GetComponent<MainMenuManager>().FindCanvasElements();
            //VManager.GetComponent<VolumeManager>().OnCanvasActivation();
        }

        if (GarageMenu)
        {
            equipmentController.GetComponent<EquipmentController>().findCanvasElements();
            StoreM.GetComponent<StoreManager>().findCanvasElements();
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
