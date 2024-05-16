using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScoreController : MonoBehaviour
{
    [SerializeField] private ScoreItem scoreItem;
    [SerializeField] private RectTransform scoreList;
    [SerializeField] private FirebaseWrapper firebaseWrapper;

    private void Awake()
    {
        ShowScoreList();
        firebaseWrapper.OnDataLoaded += OnDataLoaded;
    }

    private void OnDataLoaded(List<FirebaseWrapper.PlayerData> list)
    {
        Debug.Log("Data loaded: " + list.Count);

        foreach (var item in list)
        {
            Debug.Log(item.playerName + " " + item.time);
            scoreItem.SetData(item);
            Instantiate(scoreItem, scoreList);
        }
    }

    public void ShowScoreList()
    {
        firebaseWrapper.LoadData();
    }
}
