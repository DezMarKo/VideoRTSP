using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProvaTelecamere
{
    public static class CameraStorage
    {
        private static readonly string FilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "telecamere.json");

        public static List<CameraConfig> Load()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    Save(new List<CameraConfig>());
                    return new List<CameraConfig>();
                }

                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<CameraConfig>>(json)
                       ?? new List<CameraConfig>();
            }
            catch
            {
                return new List<CameraConfig>();
            }
        }

        public static void Save(List<CameraConfig> cams)
        {
            try
            {
                var json = JsonSerializer.Serialize(cams, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(FilePath, json);
            }
            catch { }
        }
    }
}
