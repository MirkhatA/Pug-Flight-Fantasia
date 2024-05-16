using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text usernameText;
    [SerializeField] private TMPro.TMP_Text scoreText;
    public void SetData(FirebaseWrapper.PlayerData player)
    {
        usernameText.text = player.playerName;
        scoreText.text = player.time;
    }

}
