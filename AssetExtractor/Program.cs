using AssetStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssetExtractor
{

    class Program
    {
        static async Task Main(string[] args)
        {
            var manager = new AssetsManager();
            manager.LoadFolder(@"Z:\unity\Content");

            foreach (var file in manager.assetsFileList)
            {
                var bundle = (AssetBundle)file.Objects.First(o => o.GetType() == typeof(AssetBundle));
                foreach (var (path, asset) in bundle.m_Container)
                {
                    var assetObject = file.Objects.First(o => o.m_PathID == asset.asset.m_PathID);
                    var fileName = path.Split('/').Last().Split('.').First();
                    var filePath = string.Join('/', path.Split('/')[..^1]);

                    Exporter.ExportConvertFile(new AssetItem(assetObject, fileName), "Z:/proper/" + filePath);
                }
            }
        }
    }
}
