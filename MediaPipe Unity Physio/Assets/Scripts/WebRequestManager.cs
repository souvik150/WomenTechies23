using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[Serializable]
public class LoginData
{
    public string email;
    public string password;
}
public class WebRequestManager : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    public void StartLogin()
    {
        StartCoroutine(Login(email.text, password.text));
    }

    IEnumerator Login(string email, string password)
    {
        //Create a new LoginData object with the email and password
        LoginData loginData = new LoginData();
        loginData.email = email;
        loginData.password = password;

        //Convert the LoginData object to a JSON string
        string jsonData = JsonUtility.ToJson(loginData);
        Debug.Log(jsonData);


        // Create a new UnityWebRequest object to send the POST request
        UnityWebRequest request = new UnityWebRequest("https://rcade-backend-production.up.railway.app/api/sessions", "POST");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        // Set the Content-Type header to application/json
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            yield break;
        }

        Debug.Log(request);

        // Extract the access token from the response body
        var responseJson = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
        string accessToken = responseJson.accessToken;

        // Store the access token in PlayerPrefs
        PlayerPrefs.SetString("access_token", accessToken);
        Debug.Log(accessToken);
    }

    private class LoginResponse
    {
        public string accessToken;
        public string refreshToken;
    }
}