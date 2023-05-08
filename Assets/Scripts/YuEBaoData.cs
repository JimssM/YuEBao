using UnityEngine;

[CreateAssetMenu(menuName = "Data/YuEBaoData", fileName = "YuEBaoData_")]
public class YuEBaoData : ScriptableObject
{
    //包含一个YuEBaoStats对象
    [SerializeField] private YuEBaoStats yuEBaoStats;
    public YuEBaoStats YuEBaoStats => yuEBaoStats;
}