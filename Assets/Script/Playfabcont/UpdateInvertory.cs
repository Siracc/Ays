using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ServerModels;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class UpdateInvertory : MonoBehaviour
{
    Dictionary<string, string> Foods = new Dictionary<string, string>();
    Dictionary<string, string> Material = new Dictionary<string, string>();

    Dictionary<string, string> Items = new Dictionary<string, string>();


    string foodInstanceID, materialInstanceID;

    int _appleCount,_mantarCount ,_woodCount,_stoneCount;
    [SerializeField] Text _appleText,_mantarText,_woodText,_stoneText;
    public string _itemInstanceId;
    string food,material;

    void Start()
    {
        StartCoroutine(bekle());
    }


    private void FixedUpdate()
    {
        if(onTriggerApple._appleToplama==true)
        {
            food = "Apple";
            onTriggerApple._appleToplama = false;
            StartCoroutine(bekle2());
        }


        if (onTriggerMantar._mantarToplama == true)
        {
            food = "Mantar";
            onTriggerMantar._mantarToplama = false;
            StartCoroutine(bekle2());
        }
        if (onTriggerStone._stoneToplama == true)
        {
            material = "Stone";
            onTriggerStone._stoneToplama = false;
            StartCoroutine(bekle2());
        }


        if (onTriggerWood._woodToplama == true)
        {
            material = "Wood";
            onTriggerWood._woodToplama = false;
            StartCoroutine(bekle2());
        }

    }
   
    IEnumerator bekle2()
    {
        if(food=="Apple")
        {
            _appleCount++;
            Foods.Clear();
            Foods.Add("Apple", _appleCount.ToString());
            Foods.Add("Mantar", _mantarCount.ToString());
            Items = Foods;
            _itemInstanceId = foodInstanceID;
        }
      

        else if (food == "Mantar")
        {
            _mantarCount++;
            Foods.Clear();
            Foods.Add("Apple", _appleCount.ToString());
            Foods.Add("Mantar", _mantarCount.ToString());
            Items = Foods;
            _itemInstanceId = foodInstanceID;
        }
        else if (material == "Wood")
        {
            _woodCount++;
            Material.Clear();
            Material.Add("Wood", _woodCount.ToString());
            Material.Add("Stone", _stoneCount.ToString());
            Items = Material;
            _itemInstanceId = materialInstanceID;
        }
        else if (material == "Stone")
        {
            _stoneCount++;
            Material.Clear();
            Material.Add("Wood", _woodCount.ToString());
            Material.Add("Stone", _stoneCount.ToString());
            Items = Material;
            _itemInstanceId = materialInstanceID;
        }




        updateditems();
        yield return new WaitForSeconds(0.1f);
        envanterigetir();
        
    }



    IEnumerator bekle()
    {
        if (PlayerPrefs.GetInt("newgameFood6") == 0)
        {
            additem();
        }
        yield return new WaitForSeconds(0.5f);
        Foods.Add("Apple", _appleCount.ToString());
        Foods.Add("Mantar", _mantarCount.ToString());
        Material.Add("Wood", _woodCount.ToString());
        Material.Add("Stone", _stoneCount.ToString());
        envanterigetir();
        yield return new WaitForSeconds(0.5f);

      //  updateditems();

    }



    void envanterigetir()
    {

        PlayFabClientAPI.GetUserInventory(new PlayFab.ClientModels.GetUserInventoryRequest()
        {


        },
       Result =>
       {
           foreach (var item in Result.Inventory)
           {
               if (item.ItemId == "Foods")
               {
                   if (PlayerPrefs.GetInt("newgameFood6") ==1 )
                   {
                       foreach (var a in item.CustomData)
                       {
                           if (a.Key == "Apple")
                           {
                               _appleCount = int.Parse(a.Value);
                               Debug.Log(_appleCount);
                               Foods.Clear();
                               Foods.Add(a.Key, a.Value);
                               _appleText.text = a.Value;
                               
                           }
                           if (a.Key == "Mantar")
                           {
                               _mantarCount = int.Parse(a.Value);
                               Debug.Log(_mantarCount);
                               Foods.Clear();
                               Foods.Add(a.Key, a.Value);
                               _mantarText.text = a.Value;

                           }

   
                       }
                   }

                   if (PlayerPrefs.GetInt("newgameFood6") == 0)
                   {
                       foreach (KeyValuePair<string, string> entry in Foods)
                       {
                           if (entry.Key == "Apple")
                               _appleText.text = entry.Value;
                           if (entry.Key == "Mantar")
                               _mantarText.text = entry.Value;


                           PlayerPrefs.SetInt("newgameFood6", 1);

                         
                       }

                       _itemInstanceId = item.ItemInstanceId;
                       Items = Foods;
                       updateditems();
                   }
                   foodInstanceID = item.ItemInstanceId;
               }


               if (item.ItemId == "Materials")
               {
                   if (PlayerPrefs.GetInt("newgameMaterial5") == 1)
                   {
                       foreach (var a in item.CustomData)
                       {
                           if (a.Key == "Wood")
                           {
                               _woodCount = int.Parse(a.Value);
                               Debug.Log(_woodCount);
                               Material.Clear();
                               Material.Add(a.Key, a.Value);
                               _woodText.text = a.Value;

                           }
                           if (a.Key == "Stone")
                           {
                               _stoneCount = int.Parse(a.Value);
                               Debug.Log(_stoneCount);
                               Material.Clear();
                               Material.Add(a.Key, a.Value);
                               _stoneText.text = a.Value;

                           }
                         
                       }
                   }

                   if (PlayerPrefs.GetInt("newgameMaterial5") == 0)
                   {
                       foreach (KeyValuePair<string, string> entry in Foods)
                       {
                           if (entry.Key == "Wood")
                               _woodText.text = entry.Value;
                           if (entry.Key == "Stone")
                               _stoneText.text = entry.Value;

                           PlayerPrefs.SetInt("newgameMaterial5", 1);

                         
                       }
                       _itemInstanceId = item.ItemInstanceId;
                       Items = Material;
                       updateditems();
                   }
                   materialInstanceID = item.ItemInstanceId;
               }


           }
       },

       Error =>
       {
           Debug.Log("Hatalı Giris");
       }); ;
    }


    public void additem()
    {
        List<string> _item = new List<string>();
        _item.Add("Foods");
        _item.Add("Materials");
        PlayFabServerAPI.GrantItemsToUser(new GrantItemsToUserRequest()
        {
            PlayFabId = LoginRegister._playerId,
            CatalogVersion = "Items",
            ItemIds = _item


        },
      Result =>
      {
          Debug.Log("ItemlerEklendi");

      },
      Error =>
      {
          Debug.Log("ErrorADDItems");

      }); ;


    }

    public void updateditems()
    {

        PlayFabServerAPI.UpdateUserInventoryItemCustomData(new UpdateUserInventoryItemDataRequest()
        {
            PlayFabId = LoginRegister._playerId,
            ItemInstanceId = _itemInstanceId,
            Data= Items



        },
       Result =>
       {
         
           Debug.Log("Basarili");
           


       },
       Error =>
       {
           Debug.Log("ErrorUpdateItems");

       }); ;
    }

   
}
