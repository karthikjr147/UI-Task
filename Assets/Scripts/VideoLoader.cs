using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;

public class VideoLoader : MonoBehaviour
{
    public RawImage display;
    public VideoPlayer player;

    private string[] videoPaths;
    private int index;

    void Start()
    {
        string folder = Path.Combine(Application.streamingAssetsPath, "Videos");
        videoPaths = Directory.GetFiles(folder, "*.mp4");

        if (videoPaths.Length == 0)
        {
            Debug.LogError("No videos found in StreamingAssets/Videos!");
            return;
        }

        LoadVideo();
    }

    void LoadVideo()
    {
        player.Stop();

        string url = "file:///" + videoPaths[index].Replace("\\", "/");

        player.url = url;

        player.prepareCompleted += VideoReady;
        player.Prepare();
    }

    void VideoReady(VideoPlayer vp)
    {
        display.texture = vp.texture;
        vp.prepareCompleted -= VideoReady;
        vp.Play();
    }

    public void NextVideo()
    {
        index++;
        if (index >= videoPaths.Length)
            index = 0;

        LoadVideo();
    }

    public void PrevVideo()
    {
        index--;
        if (index < 0)
            index = videoPaths.Length - 1;

        LoadVideo();
    }
}
