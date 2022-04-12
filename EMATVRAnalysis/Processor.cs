using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EMATVRAnalysis
{
    public static class Processor
    {
        public static EMATVrObject ProcessFile(string path)
        {
            Dictionary<string, decimal> VREvents = ImportVrEventsToDictionary(path);

            string id = GetId(path);

            return ParseDictionaryToObject(id, VREvents);
        }

        static string GetId(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        /**
         * Creates a Dictionary out of the events in the csv file at the provided path
         */
        static Dictionary<string, decimal> ImportVrEventsToDictionary(string path)
        {
            Dictionary<string, decimal> VREvents = new Dictionary<string, decimal>();

            try
            {
                var reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    int extraKeyInfo = 1;

                    string line = reader.ReadLine();
                    
                    // Remove WhiteSpace
                    line = Regex.Replace(line, @" ", "");
                    string[] values = line.Split(',');

                    string key = values[1];

                    decimal value;
                    decimal.TryParse(values[0], out value);

                    //check if key already in dictionary, add it if not
                    if (!VREvents.ContainsKey(key))
                    {
                        VREvents.Add(key, value);
                    }
                    else
                    {
                        bool uniqueKeyFound = false;
                        while (!uniqueKeyFound)
                        {
                            string newKey = key + extraKeyInfo;
                            extraKeyInfo++;
                            if (!VREvents.ContainsKey(newKey))
                            {
                                uniqueKeyFound = true;
                                VREvents.Add(newKey, value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return VREvents;
        }

        static EMATVrObject ParseDictionaryToObject(string ID, Dictionary<string, decimal> d)
        {
            decimal simulation_totalTime = GetTimeDifference(d, "Start", "End");

            // Tutorial decimals
            decimal tutorial_totalTime = GetTimeDifference(d, "TutorialEnded", "TutorialStart");
            decimal tutorial_moveForwardTime = GetTimeDifference(d, "MoveForwardAudioStarted", "MoveForwardObjectiveReached");
            decimal tutorial_rotateTime = GetTimeDifference(d, "RotateAudioStarted", "Rotate3");
            decimal tutorial_teleportTime = GetTimeDifference(d, "TeleportAudioStarted", "TeleportForwardObjectiveReached");
            decimal tutorial_thumbstickTime = GetTimeDifference(d, "ChangeControllerAudioStarted", "ThumbstickPressed3");
            decimal tutorial_completeTime = GetTimeDifference(d, "CompleteTutorialAudioStarted", "FinalMarkerReached");
            
            // Tutorial bools
            bool tutorial_moveForward_completeEarly = !d.ContainsKey("TeleportStateStarted");
            bool tutorial_rotate_completeEarly = !d.ContainsKey("RotateStateStarted");
            bool tutorial_teleport_completeEarly = !d.ContainsKey("TeleportStateStarted");
            bool tutorial_thumbstick_completeEarly = !d.ContainsKey("ChangeControllerStateStarted");
            bool tutorial_complete_completeEarly = !d.ContainsKey("CompleteTutorialStateStarted");

            // Shower decimals
            decimal shower_totalTime = GetTimeDifference(d, "ShowerStageEnded", "ShowerStageStarted");
            decimal shower_lumpTime = GetTimeDifference(d, "LumpSearchStarted", "LumpFound");
            decimal shower_swellingTime = GetTimeDifference(d, "SwellingSearchStarted", "SwellingFound");
            decimal shower_throbbingTime = GetTimeDifference(d, "ThrobbingSearchStarted", "ThrobbingFound");

            return new EMATVrObject(
                ID,
                simulation_totalTime,
                tutorial_totalTime,
                tutorial_moveForwardTime,
                tutorial_moveForward_completeEarly,
                tutorial_rotateTime,
                tutorial_rotate_completeEarly,
                tutorial_teleportTime,
                tutorial_teleport_completeEarly,
                tutorial_thumbstickTime,
                tutorial_thumbstick_completeEarly,
                tutorial_completeTime,
                tutorial_complete_completeEarly

            );
        }

        static decimal GetTimeDifference(Dictionary<string, decimal> d, string key1, string key2)
        {
            if (!d.ContainsKey(key1) || !d.ContainsKey(key2))
            {
                return 0;
            }
            
            return Math.Abs(d[key1] - d[key2]);
        }
        
    }
}
