using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleGameMenu : MonoBehaviour
{
    private bool _isLoading = false;

    public void OnNextSceneButtonClick() 
    {
        if (!_isLoading) 
        {
            _isLoading = true;

            SceneManager.LoadScene("EntryPointGameplay");
        }
    }
}
