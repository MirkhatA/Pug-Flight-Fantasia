using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScoreController : MonoBehaviour
{
    [SerializeField] private Button _sendBtn;
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private FirebaseWrapper _firebaseWrapper;

    private void Start()
    {
        _scorePanel.SetActive(false);
    }

    public void SendData()
    {
        if (!string.IsNullOrEmpty(_username.text) && _username.text.Length > 3)
        {
            _firebaseWrapper.SaveData(_username.text, _score.text);
        }
    }

}
