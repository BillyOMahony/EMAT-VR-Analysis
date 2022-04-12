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
        public static EmatVrParticipant ProcessFile(string path)
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

        static EmatVrParticipant ParseDictionaryToObject(string ID, Dictionary<string, decimal> d)
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

            // Bedroom information
            decimal bedroom_totalTime = GetTimeDifference(d, "TesteStageStarted", "TesteStageEnded");
            decimal bedroom_touchBookTime = GetTimeDifference(d, "TesteStageStarted", "BookOpened");

            int bedroom_cancer_pos, bedroom_epididymis_pos, bedroom_spermaticCord_pos;
            GetTesteSelectOrder(d, out bedroom_cancer_pos, out bedroom_epididymis_pos, out bedroom_spermaticCord_pos);

            // Recap information
            decimal recap_totalTime = GetTimeDifference(d, "RecapStageStarted", "End");
            decimal recap_fingerprintTime = GetTimeDifference(d, "FingerprintSearchStarted", "FingerprintFound");
            decimal recap_checklistTime = GetTimeDifference(d, "ChecklistSearchStarted", "ChecklistFound");
            decimal recap_medkitTime = GetTimeDifference(d, "MedkitSearchStarted", "MedkitFound");

            return new EmatVrParticipant(
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
                tutorial_complete_completeEarly,
                shower_totalTime,
                shower_lumpTime,
                shower_swellingTime,
                shower_throbbingTime,
                bedroom_totalTime,
                bedroom_touchBookTime,
                bedroom_cancer_pos,
                bedroom_epididymis_pos,
                bedroom_spermaticCord_pos,
                recap_totalTime,
                recap_fingerprintTime,
                recap_checklistTime,
                recap_medkitTime
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

        static void GetTesteSelectOrder(Dictionary<string, decimal> d, out int Cancer, out int Epididymis,
            out int Spermatic)
        {
            Cancer = 0;
            Epididymis = 0;
            Spermatic = 0;

            if (!d.ContainsKey("CancerSelected") || !d.ContainsKey("SpermaticCordSelected") ||
                !d.ContainsKey("SpermaticCordSelected")) return;

            decimal CancerTime = d["CancerSelected"];
            decimal SpermaticTime = d["SpermaticCordSelected"];
            decimal EpididymisTime = d["SpermaticCordSelected"];

            if (CancerTime < SpermaticTime && SpermaticTime < EpididymisTime)
            {
                Cancer = 1;
                Spermatic = 2;
                Epididymis = 3;
            }
            else if (CancerTime < EpididymisTime && EpididymisTime < SpermaticTime)
            {
                Cancer = 1;
                Epididymis = 2;
                Spermatic = 3;
            }
            else if (SpermaticTime < CancerTime && CancerTime < EpididymisTime)
            {
                Spermatic = 1;
                Cancer = 2;
                Epididymis = 3;
            }
            else if (SpermaticTime < EpididymisTime && EpididymisTime < CancerTime)
            {
                Spermatic = 1;
                Cancer = 2;
                Epididymis = 3;
            }
            else if (EpididymisTime < CancerTime && CancerTime < SpermaticTime)
            {
                Epididymis = 1;
                Cancer = 2;
                Spermatic = 3;
            }
            else if (EpididymisTime < SpermaticTime && SpermaticTime < CancerTime)
            {
                Epididymis = 1;
                Spermatic = 2;
                Cancer = 3;
            }
        }
    }
}
