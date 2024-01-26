/*
 * Author: Grace Foo
 * Date: 21/1/2024
 * Description: Code for taking a picture and sending it into storage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


using UnityEngine.UI;
using UnityEngine.Networking;

using Firebase;
using Firebase.Storage;
using Firebase.Extensions;

using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class cam : MonoBehaviour
{
    WebCamTexture myWebCamTexture;
    string StorageURL = "gs://botanicgardensar.appspot.com";
    string CamFolderAlias = "cam"; //is to keep in an additional folder
    public Button btnPhoto;

    public void takepicture()
    {
        DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
        string filename = now.ToUnixTimeSeconds() + "-cam.png";
        StartCoroutine(TakePhoto(filename));
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        btnPhoto.onClick.AddListener(takepicture);
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("cam gound");
        }
        else
        {
            Debug.Log("no cam");
        }

        Renderer rend = this.GetComponentInChildren<Renderer>();

        myWebCamTexture = new WebCamTexture(devices[0].name);
        rend.material.mainTexture = myWebCamTexture;
        myWebCamTexture.Play();

    }
    public IEnumerator TakePhoto(string filename)
    {
        yield return new WaitForEndOfFrame();
        try
        {
            Texture2D photo = new Texture2D(myWebCamTexture.width, myWebCamTexture.height);
            photo.Apply();

            byte[] bytes = photo.EncodeToPNG();

            string path = Path.Combine(Application.persistentDataPath, CamFolderAlias);
            Debug.Log("path save: " + path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(Path.Combine(path, filename), bytes);
            StartCoroutine(UploadImage(2, filename));
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
    IEnumerator UploadImage(float delay, string fileName)
    {
        yield return new WaitForSeconds(delay);

        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef =
    storage.GetReferenceFromUrl(StorageURL);

        string localFile = Application.persistentDataPath + "/cam/" + fileName;
        StorageReference imgRef = storageRef.Child("appcontest/" + fileName);

        var newMetadata = new MetadataChange();
        newMetadata.ContentType = "image/png";

        imgRef.PutFileAsync(localFile, newMetadata).ContinueWithOnMainThread((Task<StorageMetadata> task) =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log(task.Exception.ToString());
                // Uh-oh, an error occurred!
            }
            else
            {
                // Metadata contains file metadata such as size, content-type, and download URL.
                StorageMetadata metadata = task.Result;
                string md5Hash = metadata.Md5Hash;
                Debug.Log("Finished uploading...");
                Debug.Log("md5 hash = " + md5Hash);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
            string filename = now.ToUnixTimeSeconds() + "-cam.png";
            StartCoroutine(TakePhoto(filename));

        }
    }
}
