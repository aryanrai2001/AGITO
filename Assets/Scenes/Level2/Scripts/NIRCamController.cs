using UnityEngine;

public class NIRCamController : MonoBehaviour
{
    private RectTransform rectTransfrom;

    public void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
    }

    public void FixedUpdate()
    {
        rectTransfrom.position = LevelHandler.instance.levelCamera.ScreenToWorldPoint(Input.mousePosition);
        foreach (EntityManager entity in ((Level2Handler)LevelHandler.instance).entities)
        {
            if (GetComponent<Collider2D>().bounds.Intersects(entity.GetComponent<Collider2D>().bounds))
            {
                entity.Revealed();
            }
        }    
    }
}
