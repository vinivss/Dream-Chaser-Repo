using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeOfDay", menuName = "2.5D/New Time of day", order = 4)]
public class TimePeriod : ScriptableObject
{
    public enum TimeOfDay
    {
        Morning,
        Lunch,
        Afternoon
    }
    public List<GameObject> CharactersInScene;
    public TimeOfDay CurrentTimeofDay = TimeOfDay.Morning;
}
