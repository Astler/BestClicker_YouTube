namespace AnimatedLight.Data
{
    public struct LightPatternData
    {
        public readonly LightType TypeName;
        public readonly string Pattern;
        
        public LightPatternData(LightType typeName, string pattern)
        {
            TypeName = typeName;
            Pattern = pattern;
        }
    }
}