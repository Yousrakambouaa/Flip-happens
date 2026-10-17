using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSO", menuName = "PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    [SerializeField]  string powerType;
    [SerializeField]  float ValueChange;
    [SerializeField]  float time;

    public string GetPowerType()
    {
        return powerType;
    }

    public float GetValueChange()
    {
        return ValueChange;
    }

    public float GetTime()
    {
        return time;
    }
}
