using Unity.Entities;
public struct DataTest : IComponentData {
    public int count;
}

[System.Serializable]
public struct RangeData : ISharedComponentData{
    public int min, max;
}