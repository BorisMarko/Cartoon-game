using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrapEntryPoint : MonoBehaviour
{
    private IEnumerator Start() 
    {
        //�������� ����� ��������.
        //��� ������ ���� ��������� �����.
        //����, UI, Input Service � �.�.

        var loadingDuration = 3f;
        while (loadingDuration > 0f) //������ ������������ �������� � ����� ������ ���� ��������� �����.
        {
            loadingDuration -= Time.deltaTime;
            Debug.Log("Loading....");
            yield return null;

        }

            SceneManager.LoadScene("EntryPointMainMenu");
    }
}
