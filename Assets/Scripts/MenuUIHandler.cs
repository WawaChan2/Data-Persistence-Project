using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour {

  [SerializeField] private TMP_InputField _usernameInput;
  [SerializeField] private TextMeshProUGUI _usernameText;
  [SerializeField] private TextMeshProUGUI _highScoreText;

  private MenuManager _menuManager;

  private void Start() {
    _menuManager = MenuManager.Instance;

    Initialize();
  }

  private void Initialize() {
    _usernameText.text = $"Username: {_menuManager.LoadedUserData.Username}";
    _highScoreText.text = $"High Score: {_menuManager.LoadedUserData.HighScore}";
  }

  public void StartGame() {
    SetUsername();

    SceneManager.LoadScene(1);
  }

  public void QuitGame() {
#if UNITY_EDITOR
    EditorApplication.Exit(0);
#else
    Application.Quit();
#endif
  }

  private void SetUsername() {
    _menuManager.DisplayedUsername = _usernameInput.text;
  }

}
