using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    public static class UtilsBase
    {
        public static int GetRandomNumberFromRange(int start, int end)
        {
            return Random.Range(start, end);
        }
        
        public static float GetRandomNumberFromRange(float start, float end)
        {
            return Random.Range(start, end);
        }
        
        public static Vector2 GetRandomCoordinatesFromRange(Vector2 start, Vector2 end)
        {
            var result = new Vector2(start.x, start.y);
            
            if (Math.Abs(start.x - end.x) > 2)
            {
                result.x = GetRandomNumberFromRange(start.x, end.x);
            }
            
            if (Math.Abs(start.y - end.y) > 2)
            {
                result.y = GetRandomNumberFromRange(start.y, end.y);
            }

            return result;
        }
        
        public static Vector2 GetDirection(Vector2 targetPos, Vector2 objectPosition)
        {
            var heading = targetPos - objectPosition;
            var distance = heading.magnitude;

            return heading / distance;
        }
    }
}