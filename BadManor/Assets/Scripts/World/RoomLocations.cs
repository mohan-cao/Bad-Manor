using UnityEngine;

/// <summary>
/// List of door locations between rooms.</summary>
public class RoomLocations : MonoBehaviour
{
    /// <summary>
    /// The possible options (doors in rooms).</summary>
    public enum RoomsSpawns
    {
        GroundFoyerEntry,
        GroundFoyerFromHallway,
        GroundFoyerFromFirstFloor,

        GroundHallwayFromFoyer,
        GroundHallwayFromGamesRoom,
        GroundHallwayFromGrandHall,
        GroundHallwayFromToilet1,
        GroundHallwayFromToilet2,
        GroundHallwayFromKitchen,

        GroundToilet1,

        GroundToilet2,

        GroundGrandHall,

        GroundGamesRoom,

        GroundKitchenFromHallway,
        GroundKitchenFromPantry,

        GroundPantryFromKitchen,
        GroundPantryFromBasement,

        BasementCellarFromPantry,
        BasementCellarFromSecurity,

        BasementSecurity,

        FirstFloorHallwayFromFoyer,
        FirstFloorHallwayFromBathroom,
        FirstFloorHallwayFromCharles,
        FirstFloorHallwayFromMaster,
        FirstFloorHallwayFromRooftop,
        FirstFloorBathroom,
        FirstFloorCharles,
        FirstFloorMaster,
        RooftopFromFirstFloor,
        RooftopFromChimney,
        RooftopChimney
    }

    /// <summary>
    /// Coresponding vector co-ordinates for each door.</summary>
    static Vector3[] coords =
    {
        //Ground Foyer
        new Vector3(25.5f, -38.5f),
        new Vector3(25.6f, -6f),
        new Vector3(3.28f, -5.72f),
        //Ground Hallway
        new Vector3(23f, 14.4f),
        new Vector3(29.9f, 18.3f),
        new Vector3(21.4f, 21.8f),
        new Vector3(-31f, 14.4f),
        new Vector3(-51.32f, 21.58f),
        new Vector3(-54f, 14.4f),
        //Ground Toilet 1
        new Vector3(-33.9f, -1.58f),
        //Ground Toilet 2
        new Vector3(-57.42f, 37.93f),
        //Ground Grand Hall
        new Vector3(24.37f, 49.1f),
        //Ground Games Room
        new Vector3(77.27f, 19f),
        //Kitchen
        new Vector3(-77.19f, -0.7f),
        new Vector3(-52.5f, -30f),
        //Pantry
        new Vector3(-39f, -43.8f),
        new Vector3(-30.2f, -47.47f),
        //Basement Cellar
        new Vector3(-19.2f, -99.5f),
        new Vector3(-15.5f, -64.3f),
        //Basement Secroom
        new Vector3(-2.65f, -63.8f),
        //First Hallway
        new Vector3(0.54f, 147.3f),
        new Vector3(2.44f, 158.5f),
        new Vector3(35.4f, 158.5f),
        new Vector3(57.9f, 158.5f),
        new Vector3(70.9f, 149.7f),
        //Bathroom, Charles, Master
        new Vector3(0.897f, 172.2f),
        new Vector3(34.9f, 176.25f),
        new Vector3(88.4f, 176.75f),
        //Roof
        new Vector3(111.06f, 248f),
        new Vector3(14.4f, 266.94f),
        new Vector3(11.26f, 323.83f)
    };

    /// <summary>
    /// Maps the doors in rooms to the co-ordinates on the map the door will take them to.</summary>
    public static Vector3 getRoomCoords(RoomsSpawns room)
    {
        int enumAsInt = (int) room;
        return coords[enumAsInt];
    }
}