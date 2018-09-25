using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using log4net;

namespace common.resources
{
    public class Resources : IDisposable
    {
        public string ResourcePath { get; }
        public AppSettings Settings { get; }
        public XmlData GameData { get; }
        public WorldData Worlds { get; }
        public ChangePassword ChangePass { get; }
        public MysteryBoxes MysteryBoxes { get; }
        public Packages Packages { get; }
        public Regex[] FilterList { get; }
        public IDictionary<string, byte[]> WebFiles { get; private set; }
        public IDictionary<string, byte[]> Textures { get; private set; }
        public byte[] ZippedTextures { get; private set; }
        public IList<string> MusicNames { get; private set; }
        public Ranks[] RoleRanks { get; }

        public Resources(string resourcePath, bool wServer = false)
        {
            ResourcePath = resourcePath;
            Settings = new AppSettings(resourcePath + "/data/init.xml");
            GameData = new XmlData(resourcePath + "/xmls");
            FilterList = File.ReadAllText(resourcePath + "/data/filterList.txt")
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(l => new Regex(l, RegexOptions.IgnoreCase)).ToArray();

            if (!wServer)
            {
                ChangePass = new ChangePassword(resourcePath + "/data/changePassword");

                MysteryBoxes = new MysteryBoxes();
                MysteryBoxes.Load(resourcePath + "/data/mysteryBoxes.xml");

                Packages = new Packages();
                Packages.Load(resourcePath + "/data/packages.xml");

                webFiles(resourcePath + "/web");
                textures(resourcePath + "/textures"); // needs to be loaded after GameData

                RoleRanks = Ranks.ReadFile(resourcePath + "/data/roles.json");
            }
            else
                Worlds = new WorldData(resourcePath + "/worlds", GameData);
            
            music(resourcePath);
        }

        private void webFiles(string dir)
        {
            Dictionary<string, byte[]> webFiles;

            WebFiles =
                new ReadOnlyDictionary<string, byte[]>(
                    webFiles = new Dictionary<string, byte[]>());

            var files = Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var webPath = file.Substring(dir.Length, file.Length - dir.Length)
                    .Replace("\\", "/");

                webFiles[webPath] = File.ReadAllBytes(file);
            }
        }

        private void music(string baseDir)
        {
            List<string> music;
            
            MusicNames = 
                new ReadOnlyCollection<string>(
                    music = new List<string>());

            music.AddRange(Directory
                .EnumerateFiles(baseDir + "/web/music", "*.mp3", SearchOption.AllDirectories)
                .Select(Path.GetFileNameWithoutExtension));
        }

        private void textures(string dir)
        {
            Dictionary<string, byte[]> textures;

            Textures = 
                new ReadOnlyDictionary<string, byte[]>(
                    textures = new Dictionary<string, byte[]>());

            // load up used remote textures
            foreach (var tex in GameData.UsedRemoteTextures)
            {
                try
                {
                    var texData = FetchTexture(dir, tex);
                    textures.Add(tex[1], texData);

                    var maskData = FetchMask(dir, tex);
                    if (maskData != null)
                        textures.Add(tex[1] + "_mask", maskData);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            // create zipped textures for app/getTextures post
            using (var ms = new MemoryStream())
            {
                var wtr = new NWriter(ms);
                wtr.Write(textures.Count);
                foreach (var tex in textures)
                {
                    wtr.WriteUTF(tex.Key);
                    wtr.Write(tex.Value.Length);
                    wtr.Write(tex.Value);
                }

                ZippedTextures = Utils.Deflate(ms.ToArray());
            }
        }

        private static byte[] FetchTexture(string dir, string[] texType)
        {
            // check for texture locally first
            string fLoc = dir + "/" + texType[1] + ".png";
            if (File.Exists(fLoc))
                return File.ReadAllBytes(fLoc);

            // check online
            string wLoc;
            if (texType[0].Equals("draw"))
                wLoc = "http://realmofthemadgod.appspot.com/picture/get?id=";
            else if (texType[0].Equals("tdraw"))
                wLoc = "http://rotmgtesting.appspot.com/picture/get?id=";
            else
                throw new FileNotFoundException("Invalid remote texture.");
            wLoc += texType[1];
            var pic = new WebClient().DownloadData(wLoc);

            // save texture locally
            File.WriteAllBytes(fLoc, pic);

            return pic;
        }

        private static byte[] FetchMask(string dir, string[] texType)
        {
            // check for texture locally first
            string fLoc = dir + "/" + texType[1] + "_mask.png";
            if (File.Exists(fLoc))
                return File.ReadAllBytes(fLoc);

            return null;
        }

        public void Dispose()
        {
            GameData.Dispose();
        }
    }
}
