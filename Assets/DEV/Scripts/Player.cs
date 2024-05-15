using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("MOVE")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float horizontalSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Dokunman�n UI �zerinde ger�ekle�ip ger�ekle�medi�ini kontrol et
        if (!IsPointerOverUIObject() && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            // Mouse pozisyonunu ekran�n ortas�na g�re normalize et
            float normalizedMouseX = Input.mousePosition.x / Screen.width;

            // Ekran�n sa� yar�s�nda dokunulduysa
            if (normalizedMouseX > 0.5f)
            {
                Jump(Vector3.right);
            }
            // Ekran�n sol yar�s�nda dokunulduysa
            else
            {
                Jump(Vector3.left);
            }
        }
    }

    void Jump(Vector3 direction)
    {
        // Yatay h�z� ver
        rb.velocity = new Vector3(direction.x * horizontalSpeed, jumpForce, rb.velocity.z);
    }

    //UI TEMASLARI
    bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null) return false;

        // Dokunma noktas�n�n �zerinde bir UI objesi olup olmad���n� kontrol et
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}

