using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boxes;  // Inspector'dan kutularýnýzý ekleyin.

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
            if (meshRenderer.enabled)  // Eðer herhangi bir kutunun MeshRenderer'ý hala aktifse
            {
                return false;  // Tüm kutular kapalý deðil.
            }
        }
        return true;  // Tüm kutular kapalý.
    }

    // Bir sonraki sahneye geçiþi yükler.
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)  // Sahne dizinlerinin dýþýna çýkmamak için kontrol.
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            LoadEndMenu(); // Tüm leveller tamamlandýðýnda ana menüye dön.
        }


        // Ana menü sahnesine geçiþi yükler.
        void LoadEndMenu()
        {
            SceneManager.LoadScene("EndMenu"); // Ana menü sahnesinin adýný buraya yazýn.
        }
    }
}
