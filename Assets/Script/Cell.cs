using UnityEngine;

public class Cell : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum eCollisonType {NONE = 0, PLAYER = 1, MONSTER = 2, ITEM =3};

    eCollisonType eType = eCollisonType.NONE;

    [Header("References")]
    public MeshRenderer meshRenderer;
    public BoxCollider2D boxCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            eType = eCollisonType.PLAYER;
        }
        else if(collision.gameObject.CompareTag("Monster"))
        {
            eType = eCollisonType.MONSTER;
        }

        SetOffset();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        eType = eCollisonType.NONE;
        SetOffset();
    }

    /// <summary>
    /// floor에서 쓸 것
    /// </summary>
    public void SetOffset()
    {
        switch (eType)
        {
            case eCollisonType.NONE:
                meshRenderer.material.mainTextureOffset = new Vector2(0, 0.67f);
                break;
            case eCollisonType.PLAYER:
                meshRenderer.material.mainTextureOffset = new Vector2(0, 0.33f);
                break;
            case eCollisonType.MONSTER:
                break;
            case eCollisonType.ITEM:
                break;
            default:
                break;
        }
    }


}
