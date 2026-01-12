using UnityEngine;

public class TurnObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public SpriteRenderer SpriteRenderer;

    bool isFlip = false;

    // 몇번째 cell에 있는지
    protected int floorIdx = 2;

    [SerializeField] private Floor floor;

    [Header("offset")]
    [SerializeField] protected bool useInspectorOffset;
    [SerializeField] protected float offset;


    public void FlipY()
    {
        Vector3 s = SpriteRenderer.transform.localScale;

        s.x *= -1;   // y축 반전

        SpriteRenderer.transform.localScale = s;
    }

    public void MovePos()
    {
        Vector3 newPos = floor.GetCellPos(floorIdx);

        newPos.y += offset;

        transform.position = newPos;
    }

    public void MovePos(int startIdx, int endIdx, float duration)
    {
        if (startIdx == endIdx)
            return;

        Vector3 dir = floor.GetCellPos(endIdx) - floor.GetCellPos(startIdx);
        

        

    }

}
