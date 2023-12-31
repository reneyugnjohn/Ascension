using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public static class ProceduralGenAlgorithm
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0;i < walkLength;i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCaridinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCaridinalDirection();
        
        var currentPosition = startPosition;
        corridor.Add(currentPosition);

        for (int i = 0; i < corridorLength;i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);

        }
        return corridor;

    }

    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minWidth, int minHeight)
    {
        Queue<BoundsInt> roomsQueue  = new Queue<BoundsInt>();
        List<BoundsInt> roomsList = new List<BoundsInt>();
        roomsQueue.Enqueue(spaceToSplit);
        while (roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();
            if(room.size.y >= minHeight && room.size.x >= minWidth)
            {
                if(Random.value  < .5f)
                {
                    if(room.size.y >= minHeight * 2)
                    {
                        SplitHorizontal(minHeight, roomsQueue, room);
                    }else if(room.size.x >= minWidth * 2)
                    {
                        SplitVertical(minWidth, roomsQueue, room);
                    }else if(room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomsList.Add(room);    
                    }
                }
                else
                {

                    if (room.size.x >= minWidth * 2)
                    {
                        SplitVertical(minWidth, roomsQueue, room);
                    }
                    else if (room.size.y >= minHeight * 2)
                    {
                        SplitHorizontal(minHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth && room.size.y >= minHeight)
                    {
                        roomsList.Add(room);
                    }
                }
            }
        }
        return roomsList;
    }

    private static void SplitVertical(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit,room.size.y,room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z), new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
        
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }

    private static void SplitHorizontal( int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.size.z), new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));

        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);

    }

}




public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(1,0),
        new Vector2Int(0,-1),
        new Vector2Int(-1,0)
    };

    public static List<Vector2Int> diagonalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(1,1),
        new Vector2Int(1,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,1)
    };

    public static List<Vector2Int> eightDirectionList = new List<Vector2Int>{
        new Vector2Int(0,1),
        new Vector2Int(1,1),
        new Vector2Int(1,0),
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),
        new Vector2Int(-1,1)
    };
    public static Vector2Int GetRandomCaridinalDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }
}