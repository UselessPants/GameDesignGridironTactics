using UnityEngine;

namespace TbsFramework.Gui
{
    /// <summary>
    /// Simple movable camera implementation.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        public float ScrollSpeed = 15;
        public float ScrollEdge = 0.01f;
        [SerializeField] float upLimit;
        [SerializeField] float downLimit;
        [SerializeField] float leftLimit;
        [SerializeField] float rightLimit;

        void Update()
        {
            if (Input.GetKey("d"))// || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge))
            {
                if (transform.position.x < rightLimit)
                transform.Translate(transform.right * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.GetKey("a"))// || Input.mousePosition.x <= Screen.width * ScrollEdge)
            {
                if (transform.position.x >= leftLimit)
                transform.Translate(transform.right * Time.deltaTime * -ScrollSpeed, Space.World);
            }
            if (Input.GetKey("w"))// || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge))
            {
                if (transform.position.y <= upLimit)
                transform.Translate(transform.up * Time.deltaTime * ScrollSpeed, Space.World);
            }
            else if (Input.GetKey("s"))// || Input.mousePosition.y <= Screen.height * ScrollEdge)
            {
                if (transform.position.y > downLimit)
                transform.Translate(transform.up * Time.deltaTime * -ScrollSpeed, Space.World);
            }
        }
    }
}

