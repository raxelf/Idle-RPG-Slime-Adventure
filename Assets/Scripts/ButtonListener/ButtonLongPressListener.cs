/*--------------------------------------
   Email  : hamza95herbou@gmail.com
   Github : https://github.com/herbou
----------------------------------------*/

using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

[RequireComponent (typeof(Button))]
public class ButtonLongPressListener : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

   [Tooltip ("Hold duration in seconds")]
   [Range (0.3f, 5f)] public float holdDuration = 0.5f ;
   public UnityEvent onLongPress ;

   private bool isPointerDown = false ;
   private bool isLongPressed = false ;
   private float elapsedTime = 0f ;

   private Button button ;

   private void Awake () {
      button = GetComponent<Button> () ;
   }

   public  void OnPointerDown (PointerEventData eventData) {
      isPointerDown = true ;
   }

   private void Update () {
      if (isPointerDown && !isLongPressed) {
         elapsedTime += Time.deltaTime ;
         if (elapsedTime >= holdDuration) {
            isLongPressed = true ;
            elapsedTime = 0f ;
            if (button.interactable && !object.ReferenceEquals (onLongPress, null))
               onLongPress.Invoke () ;
         }
      }
   }

   public  void OnPointerUp (PointerEventData eventData) {
      isPointerDown = false ;
      isLongPressed = false ;
      elapsedTime = 0f ;
   }
}
