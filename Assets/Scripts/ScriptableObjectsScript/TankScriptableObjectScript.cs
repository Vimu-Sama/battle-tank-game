using UnityEngine;

[CreateAssetMenu(fileName = "TankType", menuName = "ScriptableObjects/TankTypeScriptableObject")]
public class TankScriptableObjectScript : ScriptableObject
{
    public TankType tankType;
    public float tankSpeed ;
    public int tankHealth;
    public int damageOutput;
    public Material tankMaterial;
}
