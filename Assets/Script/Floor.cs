using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Floor : MonoBehaviour
{
    [Header("Prefab")]
    public Cell cellPrefab;

    private int width = 5;

    private List<Cell> cells = new List<Cell>();

    [Header("edit")]
    public float intervalX = 2.0f;
    public float intervalY = 0;

    private void Awake()
    {
        for (int i = 0; i < width; ++i)
        {
            Cell c = Instantiate(cellPrefab, transform);
            c.transform.localPosition = new Vector3(i * intervalX, -2.95f, 0);
            cells.Add(c);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
       
    }

    // Update is called once per frame
    void Update()
    {
        


        for (int i = 0; i < width; ++i)
        {
            if (cells[i] != null)
            {
                cells[i].transform.localPosition = new Vector3(i * intervalX, -2.95f, 0);
            }
        }
    }

    public Vector3 GetCellPos(int idx)
    {
        return cells[idx].transform.position;
    }

}
