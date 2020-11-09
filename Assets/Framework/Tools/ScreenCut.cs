using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenCut : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            string projectDir = System.IO.Directory.GetParent(Application.dataPath).ToString();
            string screenshotDir = Path.Combine(projectDir, "ScreenShot");
            if (!Directory.Exists(screenshotDir))
            {
                Directory.CreateDirectory(screenshotDir);
            }
            string imagePath = Path.Combine(screenshotDir, System.DateTime.Now.Ticks.ToString() + ".png");
            Debug.Log("ScreenImage=" + imagePath);
            ScreenCapture.CaptureScreenshot(imagePath);
        }
    }
}
