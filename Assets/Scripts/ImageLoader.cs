using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ImageLoader : MonoBehaviour
{
    public RawImage display;
    private string[] paths;
    private int index;

    void Start()
    {
        string folder = Path.Combine(Application.streamingAssetsPath, "Images");

        paths = Directory.GetFiles(folder, "*.*")
            .Where(f => f.ToLower().EndsWith(".png") ||
                        f.ToLower().EndsWith(".jpg") ||
                        f.ToLower().EndsWith(".jpeg"))
            .ToArray();

        Debug.Log("Total images found = " + paths.Length);

        if (paths.Length > 0)
            LoadImage();
    }

    public void NextImage()
    {
        if (paths.Length < 2) return;

        index++;
        if (index >= paths.Length)
            index = 0;

        LoadImage();
    }

    public void PrevImage()
    {
        if (paths.Length < 2) return;

        index--;
        if (index < 0)
            index = paths.Length - 1;

        LoadImage();
    }

    void LoadImage()
    {
        byte[] data = File.ReadAllBytes(paths[index]);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(data);

        display.texture = tex;

        FitToPanel(tex);
    }

    void FitToPanel(Texture2D tex)
    {
        RectTransform rawRT = display.rectTransform;
        RectTransform parentRT = display.transform.parent.GetComponent<RectTransform>();

        float panelW = parentRT.rect.width;
        float panelH = parentRT.rect.height;

        float imgW = tex.width;
        float imgH = tex.height;

        float imgRatio = imgW / imgH;
        float panelRatio = panelW / panelH;

        if (imgRatio > panelRatio)
        {
            rawRT.sizeDelta = new Vector2(panelW, panelW / imgRatio);
        }
        else
        {
            rawRT.sizeDelta = new Vector2(panelH * imgRatio, panelH);
        }
    }
}
