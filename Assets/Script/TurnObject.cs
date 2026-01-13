using UnityEngine;
using System.Collections;

public class TurnObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public SpriteRenderer SpriteRenderer;

    bool isFlip = false;

    // 몇번째 cell에 있는지
    protected int floorIdx = 2;

    [SerializeField] protected Floor floor;

    [Header("offset")]
    [SerializeField] protected bool useInspectorOffset;
    [SerializeField] protected float offset;


    public void FlipY()
    {
        Vector3 s = SpriteRenderer.transform.localScale;

        s.x *= -1;   // y축 반전

        SpriteRenderer.transform.localScale = s;
    }

    public void ChangePos()
    {
        Vector3 newPos = floor.GetCellPos(floorIdx);

        newPos.y += offset;

        transform.position = newPos;
    }

    protected IEnumerator MoveCorotine(Vector3 start, Vector3 end, float duration, float jumpHeight = 0)
    {


        float elapsed = 0f;

        while (elapsed < duration)
        {
            // 선형보간으로 일단

            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            
            Vector3 pos = Vector3.Lerp(start, end, t);

            // 포물선 점프 
            float yOffset = 4f * jumpHeight * t * (1f - t);

            pos.y += yOffset;

            transform.position = pos;
            yield return null;
        }

        // 정확한 위치 보정
        transform.position = end;
    }

}
