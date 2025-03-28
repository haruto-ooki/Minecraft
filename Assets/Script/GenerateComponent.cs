using UnityEngine;
using Unity.Entities;

public struct GenerateConfig : IComponentData
{
    public Entity GrassPrefab;
    public Entity DirtPrefab;
    public Entity StonePrefab;
    public int World_X_Size;
    public int World_Z_Size;
}

public class ConfigAuthoring : MonoBehaviour
{
    public GameObject GrassPrefab = null;
    public GameObject DirtPrefab = null;
    public GameObject StonePrefab = null;
    public int World_X_Size = 100;
    public int World_Z_Size = 100;

    class Baker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring src)
        {
            var data = new GenerateConfig()
            {
                GrassPrefab = GetEntity(src.GrassPrefab, TransformUsageFlags.Dynamic), 
                DirtPrefab = GetEntity(src.DirtPrefab, TransformUsageFlags.Dynamic), 
                StonePrefab = GetEntity(src.StonePrefab, TransformUsageFlags.Dynamic), 
                World_X_Size = src.World_X_Size, 
                World_Z_Size = src.World_Z_Size
            };
            AddComponent(GetEntity(TransformUsageFlags.None), data);
        }
    }
}
