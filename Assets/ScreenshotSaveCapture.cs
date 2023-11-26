using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotSaveCapture : MonoBehaviour {
    public GameObject menu;

    public void Capture(int saveSlot, Image image) {
        StartCoroutine(CaptureScreenshot(saveSlot, image));
    }
    public IEnumerator CaptureScreenshot(int saveSlot, Image image) {
        menu.SetActive(false);

        yield return new WaitForEndOfFrame();
        menu.SetActive(true);

        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();


        SaveScreenshotToFile(screenshot, saveSlot);

        DisplayScreenshot(screenshot,image);
        

    }

    void SaveScreenshotToFile(Texture2D screenshot, int saveSlot) {
        byte[] bytes = screenshot.EncodeToPNG();
        string fileName = "SaveSlot" + saveSlot + ".png";
        System.IO.File.WriteAllBytes(fileName, bytes);
    }

    void DisplayScreenshot( Texture2D screenshot, Image image)    {
        float scale = screenshot.height/image.rectTransform.rect.height;
        var rectWidth = screenshot.width-image.rectTransform.rect.width*scale;
        

        Rect centerRect = new Rect(rectWidth/2f, 0, screenshot.width-rectWidth, screenshot.height);

        // Create the sprite using the center rectangle
        image.sprite = Sprite.Create(screenshot, centerRect, new Vector2(0.5f, 0.5f));
    }
}
