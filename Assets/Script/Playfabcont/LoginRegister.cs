using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ServerModels;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LoginRegister : MonoBehaviour
{
    public static string _playerId;

    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
        },
        Result =>
        {
            Debug.Log("Misafir Girisi basarili");
            _playerId = Result.PlayFabId;
            GuestDisplayName();
        },
        Error =>
        {
            Debug.Log("Misafir Girisi basarisiz");
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
            Debug.Log("Hatalý Giris");
        }); ;
    }
}
