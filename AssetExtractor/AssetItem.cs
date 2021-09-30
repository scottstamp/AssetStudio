using AssetStudio;

namespace AssetExtractor
{
    internal class AssetItem
    {
        public AssetStudio.Object Asset;
        public SerializedFile SourceFile;
        public string Container = string.Empty;
        public string TypeString;
        public long m_PathID;
        public long FullSize;
        public ClassIDType Type;
        public string Text;
        public string InfoText;
        public string UniqueID;

        public AssetItem(AssetStudio.Object asset, string path)
        {
            Asset = asset;
            SourceFile = asset.assetsFile;
            Type = asset.type;
            TypeString = Type.ToString();
            m_PathID = asset.m_PathID;
            FullSize = asset.byteSize;
            Text = path.Split('/').Last();
        }
    }
}
