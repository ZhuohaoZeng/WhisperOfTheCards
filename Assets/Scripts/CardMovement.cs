using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 orginalLocalPointerPosition;
    private Vector3 originalPanelPosition;
    private Vector3 originalScale;
    private int currentState = 0;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    [SerializeField] private float selectScale = 1.1f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private Vector3 playPosition;
    [SerializeField] private GameObject glowEffect;
    [SerializeField] private GameObject playArrow;
    private Vector3 bottomPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;
        originalRotation = rectTransform.localRotation;
    }
    void Update()
    {
        switch(currentState)
        {
            case 1:
                HandleHoverState();
                break;
            case 2:
                HandleDrageState();
                if (!Input.GetMouseButton(0))// check if mouse button is released
                {
                    TransitionToState0();
                }
                break;
            case 3:
                HandlePlayState();
                if (!Input.GetMouseButton(0))// check if mouse button is released
                {
                    TransitionToState0();
                }
                break;
        }    

    }

    private void TransitionToState0()
    {
        currentState = 0;
        rectTransform.localScale = originalScale; //reset scale
        rectTransform.localRotation = originalRotation;//reset rotation
        rectTransform.localPosition = originalPosition; //reset position
        glowEffect.SetActive(false); //disable flow effect
        playArrow.SetActive(false); //disable play arrow
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentState == 0)
        {
            originalPosition = rectTransform.localPosition;
            originalRotation = rectTransform.localRotation;
            originalScale = rectTransform.localScale;
            currentState = 1;

        }
        return;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentState == 1)
        {
            TransitionToState0();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentState == 1)
        {
            currentState = 2;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), 
                eventData.position, eventData.pressEventCamera, out orginalLocalPointerPosition);
            orginalLocalPointerPosition = rectTransform.localPosition;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (currentState == 2)
        {
            Vector2 localPointerPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(),
                eventData.position, eventData.pressEventCamera, out localPointerPosition))
            {
                rectTransform.position = Input.mousePosition;
                if (rectTransform.localPosition.y < cardPlay.y)
                {
                    currentState = 3;
                    playArrow.SetActive(true);
                    rectTransform.localPosition = playPosition;
                }
            }
        }
    }

    private void HandleHoverState()
    {
        glowEffect.SetActive(true);
        rectTransform.localScale = originalScale * selectScale;
        rectTransform.localPosition = new Vector3(originalPosition.x, bottomPosition.y + 175, originalPosition.z);
        rectTransform.localRotation = Quaternion.identity;

    }
    private void HandleDrageState()
    {
        //set the cards rotation to 0
        rectTransform.localRotation = Quaternion.identity;
    }
    private void HandlePlayState()
    {
        rectTransform.localPosition = playPosition;
        rectTransform.localRotation = Quaternion.identity;
        if (Input.mousePosition.y > cardPlay.y)
        {
            currentState = 2;
            playArrow.SetActive(false);
        }
    }
    
}
