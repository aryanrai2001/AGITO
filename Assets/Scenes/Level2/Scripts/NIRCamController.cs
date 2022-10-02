using UnityEngine;

public class NIRCamController : MonoBehaviour
{
    private RectTransform rectTransfrom;
    private Vector3 offset;

    public void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
        //offset = new Vector3(LevelHandler.instance.levelCamera.pixelWidth / 2, LevelHandler.instance.levelCamera.pixelHeight / 2, 0);
    }

    public void FixedUpdate()
    {
        rectTransfrom.position = LevelHandler.instance.levelCamera.ScreenToWorldPoint(Input.mousePosition);// - offset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag.Equals("Entity"))
        {
            Debug.Log("Found");
        }
    }
}
