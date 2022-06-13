using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Guest : MonoBehaviour
{
    public static string _playerID;

    public void PlayGuestOnClick()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()

        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
        },
        Result =>
        {
            Debug.Log("Misafir Girisi Basarili");
            _playerID = Result.PlayFabId;
            GuestDisplayName();
            
        },
        Error =>
        {
            Debug.Log("Misafir Girisi Basarisiz");
        });
    }


    public void GuestDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = "Guest" + Random.Range(1, 1000).ToString()
        },
        Result =>
        {
            SceneManager.LoadScene(1);
        },
        Error =>
        {
            Debug.Log("Hatali Giris");
        });
    }
}
