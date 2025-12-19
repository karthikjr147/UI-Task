using UnityEngine;
using TMPro;
using System.IO;

public class TextLoader : MonoBehaviour
{
    public TMP_Text bodyText;
    public string jsonFileName;

    [System.Serializable]
    public class BodyData
    {
        public string body;
    }

    void Start()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, "Text", jsonFileName + ".json.txt");

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            BodyData data = JsonUtility.FromJson<BodyData>(json);

            bodyText.text = data.body;
        }
        else
        {
            bodyText.text = "FILE NOT FOUND!";
        }
    }
}
