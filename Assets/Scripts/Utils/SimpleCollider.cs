using UnityEngine;

public static class SimpleCollider 
{
    public static bool Overlaps(Vector2 firstPosition, Vector2 firstScale, Vector2 secondPosition, Vector2 secondScale)
    {
        var firstTopLeftCorner = new Vector2(firstPosition.x - firstScale.x / 2f, firstPosition.y + firstScale.y / 2f);
        var firstBottomRightCorner = new Vector2(firstPosition.x + firstScale.x / 2f, firstPosition.y - firstScale.y / 2f);

        var secondTopLeftCorner = new Vector2(secondPosition.x - secondScale.x / 2f, secondPosition.y + secondScale.y / 2f);
        var secondBottomRightCorner = new Vector2(secondPosition.x + secondScale.x / 2f, secondPosition.y - secondScale.y / 2f);
        
        if (firstTopLeftCorner.x >= secondBottomRightCorner.x || secondTopLeftCorner.x >= firstBottomRightCorner.x)
        {
            return false;
        }
 
        if (firstBottomRightCorner.y >= secondTopLeftCorner.y || secondBottomRightCorner.y >= firstTopLeftCorner.y)
        {
            return false;
        }
                
        return true;
    }
}
