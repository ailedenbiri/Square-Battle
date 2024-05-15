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
        // Player objesinin TrailRenderer bileþenini al
        playerTrailRenderer = player.GetComponent<TrailRenderer>();
        // Player objesinin Renderer bileþenini al
        playerRenderer = player.GetComponent<Renderer>();
        // Oyuncunun varsayýlan iz rengini kaydet
        defaultTrailColor = playerTrailRenderer.material.color;
        // Oyuncunun varsayýlan karakter rengini kaydet
        defaultPlayerColor = playerRenderer.material.color;
    }


    void OnCollisionExit(Collision collision)
    {
        // Oyuncu temas ettiði kutunun üzerinden ayrýlýrsa, kutunun isTrigger özelliðini aktif hale getir
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
        // Temas edilen objenin rengini al ve oyuncunun rengini deðiþtir
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

        // Eðer oyuncu zeminden düþerse, rengini varsayýlan renge geri al
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
