using System;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour {

  public static MenuManager Instance { get; private set; }

  public string DisplayedUsername {
    get => _displayedUsername;
    set {
      if (!string.IsNullOrWhiteSpace(value))
        _displayedUsername = value;
      else if (!string.IsNullOrWhiteSpace(LoadedUserData.Username))
        _displayedUsername = LoadedUserData.Username;
      else
        _displayedUsername = "Anonymous";
    }
  }
  public UserData LoadedUserData;

  private string _displayedUsername;
  private string _savePath;

  private void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    _savePath = Application.persistentDataPath + "/savefile.json";

    LoadData();

    DontDestroyOnLoad(gameObject);
  }

  public void SaveData(string username, int highScore) {
    UserData userData = new() { Username = username, HighScore = highScore };

    string json = JsonUtility.ToJson(userData);

    File.WriteAllText(_savePath, json);
  }

  public void LoadData() {
    if (!File.Exists(_savePath)) return;

    string json = File.ReadAllText(_savePath);
    LoadedUserData = JsonUtility.FromJson<UserData>(json);
  }

  [Serializable]
  public struct UserData {
    public string Username;
    public int HighScore;
  }

}
