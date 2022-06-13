using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class OpenFileExample : MonoBehaviour
{
    public AudioPlayer audioPlayer;
    public AudioClip cancion;
    string filePath = "";
    string cancionName = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Apply()
    {
        /*AudioClip texture = Selection.activeObject as Texture2D;
        if (texture == null)
        {
            EditorUtility.DisplayDialog("Select Texture", "You must select a texture first!", "OK");
            return;
        }*/

        string path = EditorUtility.OpenFilePanel("Songs Folder", "", "mp3");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            //texture.LoadImage(fileContent);
            //Create AudioClip from Texture datapath
            //cancion = AudioClip.Create("Cancion", fileContent.Length, 1, 44100, false);
            //AudioClip texture = AudioClip.Create("song", fileContent.Length, 1, 44100, false);
            //audioPlayer.PlayCustomSound(true, cancion);
            //Debug.Log(path);
            filePath = path;
            //Separate filePath to get the name of the file
            cancionName = filePath.Split('/')[filePath.Split('/').Length - 1];
            Debug.Log(cancionName);
        }
    }

    private IEnumerator LoadAudio()
    {
        WWW request = PlayAudioFromPath();
        yield return request;
        //if cancionName doesnt end with .mp3 dont play it
        if (cancionName.EndsWith(".mp3"))
        {
            cancion = request.GetAudioClip();
            cancion.name = cancionName;
            audioPlayer.PlayCustomSound(true, cancion);
        }else{
            Debug.Log("Cancion no valida");
        }
        
    }

    public void PlayAudioFromFile(){
        StartCoroutine(LoadAudio());
    }

    private WWW PlayAudioFromPath()
    {
        WWW www = new WWW("file://" + filePath);
        //string dato = "file://" + Application.streamingAssetsPath + "/";
        //string convertido = string.Format(dato + "{0}", cancionName);
        //WWW www = new WWW(convertido);
        //Debug.Log(Application.streamingAssetsPath);
        return www;
    }


}