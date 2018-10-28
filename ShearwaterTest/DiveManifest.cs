using System;
using System.Collections.Generic;
using System.Linq;

namespace ShearwaterTest
{
    public class DiveManifest
    {
        private Dictionary<int, string> HexByteBlocks { get; }
        public string ManifestUnits { get; }
        public bool ValidManifest { get; }

        public DiveManifest(string hexBytes, int unitsBlockOffset)
        {
            HexByteBlocks = GetHexByteBlocks(hexBytes);
            ManifestUnits = GetManifestUnits(unitsBlockOffset);
            ValidManifest = IsValidManifest();
        }

        private bool IsValidManifest()
        {
            //Checking for valid manifest. Anything else is invalid
            return HexByteBlocks.Count == 32;
        }

        private Dictionary<int, string> GetHexByteBlocks(string hexBytes)
        {
            //Splitting string into Dictionary for easy access, could have also used array returned but I like dictionaries
            var hexByteDict = new Dictionary<int, string>();
            var blockOffset = 0;
            foreach (var block in hexBytes.Split('-'))
            {
                hexByteDict.Add(blockOffset++, block);
            }

            return hexByteDict;
        }

        private string GetManifestUnits(int blockOffset)
        {
            //Getting the units for the manifest, Units in example maybe wrong as well
            //UnitSystem: 1, Depth units (0 = meters, 1=feet) of this manifest record and its corresponding log.
            return Convert.ToInt32(HexByteBlocks[blockOffset], 16) == 0 ? "m" : "ft";
        }

        public void GetDiveDetails()
        {
            if (ValidManifest)
            {
                //Getting blocks for data to be displayed and converting them.
                var diveNoHex = string.Join("", HexByteBlocks.Where(x => Enumerable.Range(2, 2).Contains(x.Key)).Select(x => x.Value));
                var maxDepthHex = string.Join("", HexByteBlocks.Where(x => Enumerable.Range(16, 2).Contains(x.Key)).Select(x => x.Value));
                var startTimeHexEpoch = string.Join("", HexByteBlocks.Where(x => Enumerable.Range(4, 4).Contains(x.Key)).Select(x => x.Value));

                //Converting to Epoch, the DiveTime in the example maybe incorrect.
                //1528452447 = Friday, June 8, 2018 10:07:27 AM
                var startTimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToInt32(startTimeHexEpoch, 16));

                //String interpolation not showing correctly here but this would work in c# 6 or later
                Console.WriteLine($"Dive Number '{Convert.ToInt32(diveNoHex, 16)}', Max Depth: '{(double)Convert.ToInt32(maxDepthHex, 16) / 10}{ManifestUnits}', DiveTime: '{startTimeStamp:yyyy/MM/dd h:mm:ss tt}'");
            }
        }
    }
}