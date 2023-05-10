using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RateGameCanvasScaler : MonoBehaviour
{
    public bool iPadTest;
    public double screenRatio;
    // Start is called before the first frame update
    void Start()
    {
        screenRatio = (1.0 * Screen.height) / (1.0 * Screen.width);

       /* if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            this.gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(7800, 900);
            this.gameObject.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
        }*/

        if (SystemInfo.deviceModel.Contains("iPad") || iPadTest)
        {
            //IpadCanvas.SetActive(true);
            this.gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(3050, 960);
            this.gameObject.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;
  
        }

        else if (screenRatio > 1.4 && screenRatio < 1.6f) //3:2 Iphones - models 4 and earlier
        {
            //IphoneFourCanvas.SetActive(true);
            //IphoneFiveToEightCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2()
            this.gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2700, 960);
            this.gameObject.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;

        }

        else if (screenRatio > 1.7 && screenRatio < 1.8) // 16:9 Iphones - models 5, SE, up to 8+
        {
            //IphoneFiveToEightCanvas.SetActive(true);
            this.gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2300, 960);
            this.gameObject.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;

        }

        else if (screenRatio > 2.1 && screenRatio < 2.2) //19.5:9 Iphones - models X, Xs, Xr, Xsmax
        {
            //XSCanvas.SetActive(true);
            this.gameObject.GetComponent<CanvasScaler>().referenceResolution = new Vector2(2800, 960);
            this.gameObject.GetComponent<CanvasScaler>().matchWidthOrHeight = 0.5f;

        }
    }


}
