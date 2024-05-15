using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] boxes;

    private TrailRenderer playerTrailRenderer;
    private Renderer playerRenderer;
    private Color defaultTrailColor;
    private Color defaultPlayerColor;
    private MeshRenderer[] boxMeshRenderers;
    private Animator animator;

    private void Awake()
    {
        animator.GetComponent<Animator>();

    }

    void Start()
    {

        boxMeshRenderers = new MeshRenderer[boxes.Length];
        for (int i = 0; i < boxes.Length; i++)
        {
            boxMeshRenderers[i] = boxes[i].GetComponent<MeshRenderer>();
        }
        // Player objesinin TrailRenderer bile�enini al
        playerTrailRenderer = player.GetComponent<TrailRenderer>();
        // Player objesinin Renderer bile�enini al
        playerRenderer = player.GetComponent<Renderer>();
        // Oyuncunun varsay�lan iz rengini kaydet
        defaultTrailColor = playerTrailRenderer.material.color;
        // Oyuncunun varsay�lan karakter rengini kaydet
        defaultPlayerColor = playerRenderer.material.color;
    }


    void OnCollisionExit(Collision collision)
    {
        // Oyuncu temas etti�i kutunun �zerinden ayr�l�rsa, kutunun isTrigger �zelli�ini aktif hale getir
        foreach (GameObject box in boxes)
        {
            if (collision.gameObject == box)
            {
                Collider boxCollider = box.GetComponent<Collider>();
                if (boxCollider != null)
                {
                    boxCollider.isTrigger = true;
                }
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // Temas edilen objenin rengini al ve oyuncunun rengini de�i�tir
        if (collision.gameObject.CompareTag("Color"))
        {
            Renderer otherRenderer = collision.gameObject.GetComponent<Renderer>();
            if (otherRenderer != null)
            {
                // Temas edilen objenin rengini oyuncunun rengi olarak ata
                playerTrailRenderer.material.color = otherRenderer.material.color;
                playerRenderer.material.color = otherRenderer.material.color;

                foreach (MeshRenderer boxMeshRenderer in boxMeshRenderers)
                {
                    if (collision.gameObject == boxMeshRenderer.gameObject)
                    {
                        boxMeshRenderer.enabled = false;
                        break;
                    }
                }
            }
        }

        // E�er oyuncu zeminden d��erse, rengini varsay�lan renge geri al
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.Play("idle");
            playerTrailRenderer.material.color = defaultTrailColor;
            playerRenderer.material.color = defaultPlayerColor;
            foreach (MeshRenderer boxMeshRenderer in boxMeshRenderers)
            {
                boxMeshRenderer.enabled = true;
            }

            foreach (GameObject box in boxes)
            {
                Collider boxCollider = box.GetComponent<Collider>();
                if (boxCollider != null)
                {
                    boxCollider.isTrigger = false;
                }
            }

        }

    }
}
