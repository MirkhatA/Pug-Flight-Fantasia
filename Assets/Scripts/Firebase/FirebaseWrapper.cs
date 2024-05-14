using System;
using UnityEditor;
using UnityEngine;
using Firebase.Database;
using System.Collections.Generic;

public class FirebaseWrapper : MonoBehaviour
{

    private readonly string _firebasePlayerData = "users";

    public List<PlayerData> playerData;

    private void Start()
    {
#if UNITY_EDITOR
        FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(true);
#endif
    }

    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to load data from Firebase.");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.GetRawJsonValue());
            }
        });
    }

    public void SaveData(string username, string score)
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).GetValueAsync().ContinueWith(task =>
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

                    if (!playerData.Contains(player))
                    {
                        playerData.Add(player);
                    }
                }

            }
        });

        FirebaseDatabase.DefaultInstance.RootReference.Child(_firebasePlayerData).Child(username).SetRawJsonValueAsync(JsonUtility.ToJson(new PlayerData(score)));

    }

    [Serializable]
    public class PlayerData
    {
        public string time;

        public PlayerData(string time)
        {
            this.time = time;
        }
    }
}

[CustomEditor(typeof(FirebaseWrapper))]
public class FirebaseData : Editor
{
    FirebaseWrapper firebaseWrapper;

    private void OnEnable()
    {
        firebaseWrapper = (FirebaseWrapper)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Load Data"))
        {
            firebaseWrapper.LoadData();
        }

        if (GUILayout.Button("Save Data"))
        {
            //firebaseWrapper.SaveData();
        }
    }
}