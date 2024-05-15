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
        // Dokunmanýn UI üzerinde gerçekleþip gerçekleþmediðini kontrol et
        if (!IsPointerOverUIObject() && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            // Mouse pozisyonunu ekranýn ortasýna göre normalize et
            float normalizedMouseX = Input.mousePosition.x / Screen.width;

            // Ekranýn sað yarýsýnda dokunulduysa
            if (normalizedMouseX > 0.5f)
            {
                Jump(Vector3.right);
            }
            // Ekranýn sol yarýsýnda dokunulduysa
            else
            {
                Jump(Vector3.left);
            }
        }
    }

    void Jump(Vector3 direction)
    {
        // Yatay hýzý ver
        rb.velocity = new Vector3(direction.x * horizontalSpeed, jumpForce, rb.velocity.z);
    }

    //UI TEMASLARI
    bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null) return false;

        // Dokunma noktasýnýn üzerinde bir UI objesi olup olmadýðýný kontrol et
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}

