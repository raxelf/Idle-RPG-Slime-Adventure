/*--------------------------------------
   Email  : hamza95herbou@gmail.com
   Github : https://github.com/herbou
----------------------------------------*/

using UnityEngine ;
using UnityEngine.Events ;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

[RequireComponent (typeof(Button))]
public class ButtonDoubleClickListener : MonoBehaviour,IPointerClickHandler {
   
   [Tooltip ("Max duration between 2 clicks in seconds")]
   [Range (0.01f, 0.5f)] public float doubleClickDuration = 0.4f ;
   public UnityEvent onDoubleClick ;

   private byte clicks = 0 ;
   private float elapsedTime = 0f ;

   private Button button ;

   private void Awake () {
      button = GetComponent<Button> () ;
   }

   private void Update () {
      if (clicks == 1) {
         elapsedTime += Time.deltaTime ;
         if (elapsedTime > doubleClickDuration) {
            clicks = 0 ;
            elapsedTime = 0f ;
         }
      }
   }

   public void OnPointerClick (PointerEventData eventData) {
      clicks++ ;

      if (clicks == 1)
         elapsedTime = 0f ;
      else if (clicks > 1) {
         if (elapsedTime <= doubleClickDuration) {
            clicks = 0 ;
            elapsedTime = 0f ;
            if (button.interactable && !object.ReferenceEquals (onDoubleClick, null))
               onDoubleClick.Invoke () ;
         }
      }
   }

}
