using System;
using UnityEditor;
using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;
using Firebase.Extensions;

public class FirebaseWrapper : MonoBehaviour
{
    private readonly string _firebasePlayerData = "users";

    public Action<List<PlayerData>> OnDataLoaded;

    public List<PlayerData> playerDataList = new List<PlayerData>();

    public List<PlayerData> PlayerDataList => playerDataList;

    private void Start()
    {
#if UNITY_EDITOR
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(true);
#endif
    }

    public void LoadData()
    {
        playerDataList.Clear();

        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to load data from Firebase.");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (var child in snapshot.Children)
                {
                    var player = JsonUtility.FromJson<PlayerData>(child.GetRawJsonValue());
                    if (!playerDataList.Contains(player))
                    {
                        playerDataList.Add(player);
                    }
                }
            }

            OnDataLoaded?.Invoke(playerDataList);
        });
    }

    public void SaveData(string username, string score)
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to load data from Firebase.");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                
                foreach (var item in snapshot.Children)
                {
                    var player = JsonUtility.FromJson<PlayerData>(item.GetRawJsonValue());

                    if (!playerDataList.Contains(player))
                    {
                        playerDataList.Add(player);
                    }
                }

            }
        });

        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).Child(username).SetRawJsonValueAsync(JsonUtility.ToJson(new PlayerData(score, username)));

    }

    [Serializable]
    public class PlayerData
    {
        public string time;
        public string playerName;

        public PlayerData(string time, string playerName)
        {
            this.time = time;
            this.playerName = playerName;
        }
    }
}
