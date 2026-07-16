using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTile : MonoBehaviour
{
    private float mouseDistance;
    public Tilemap targetTilemap;
    public TileBase replacementTile; // Assign the tile you want to place

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDistance = transform.GetComponent<RotateToMouse>().mouseDistanceFromPlayer;
            if (mouseDistance < 2.5)
            {
                // 1. Get world position from mouse click
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 2. Convert world position to grid cell coordinates
                Vector3Int cellPosition = targetTilemap.WorldToCell(worldPoint);

                // 3. Set the new tile at that position
                targetTilemap.SetTile(cellPosition, replacementTile);
            }
        }
    }
}