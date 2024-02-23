using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrapEntryPoint : MonoBehaviour
{
    private IEnumerator Start() 
    {
        //Показать экран загрузки.
        //Тут должны быть подгурзки всего.
        //Сцен, UI, Input Service и т.д.

        var loadingDuration = 3f;
        while (loadingDuration > 0f) //Вместо искуственной задержки в цикле должна быть подгрузка всего.
        {
            loadingDuration -= Time.deltaTime;
            Debug.Log("Loading....");
            yield return null;

        }

            SceneManager.LoadScene("EntryPointMainMenu");
    }
}
