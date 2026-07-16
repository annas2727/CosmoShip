using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlaceTile : MonoBehaviour
{
    public Tilemap targetTilemap;
    public TileBase replacementTile;

    [SerializeField]
    private float maxPlaceDistance = 2.5f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Mouse screen position
            Vector2 mouseScreen = Mouse.current.position.ReadValue();

            // Convert to world position
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
            mouseWorld.z = transform.position.z;

            // Check if mouse is close enough to player
            float distance = Vector2.Distance(transform.position, mouseWorld);

            if (distance <= maxPlaceDistance)
            {
                Vector3Int cellPosition = targetTilemap.WorldToCell(mouseWorld);
                targetTilemap.SetTile(cellPosition, replacementTile);
            }
        }
    }
}