using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boxes;  // Inspector'dan kutular�n�z� ekleyin.

    void Update()
    {
        if (AllBoxesDisabled())
        {
            LoadNextLevel();
        }
    }


    bool AllBoxesDisabled()
    {
        foreach (GameObject box in boxes)
        {
            MeshRenderer meshRenderer = box.GetComponent<MeshRenderer>();
            if (meshRenderer.enabled)  // E�er herhangi bir kutunun MeshRenderer'� hala aktifse
            {
                return false;  // T�m kutular kapal� de�il.
            }
        }
        return true;  // T�m kutular kapal�.
    }

    // Bir sonraki sahneye ge�i�i y�kler.
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)  // Sahne dizinlerinin d���na ��kmamak i�in kontrol.
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            LoadEndMenu(); // T�m leveller tamamland���nda ana men�ye d�n.
        }


        // Ana men� sahnesine ge�i�i y�kler.
        void LoadEndMenu()
        {
            SceneManager.LoadScene("EndMenu"); // Ana men� sahnesinin ad�n� buraya yaz�n.
        }
    }
}
