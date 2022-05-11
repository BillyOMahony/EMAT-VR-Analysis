using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMATVRAnalysis
{
    public static class Reporter
    {
        public static bool GenerateParticipantCSV(EmatVrParticipant[] participants, string path)
        {
            bool success = true;

            // Check for flag in analysis

            string header = "ID, SimulationTotalTime, TutorialTotalTime, TutorialMoveForwardTime, TutorialMoveForwardCompleteEarly, TutorialRotateTime, " +
                "TutorialRotateCompleteEarly, TutorialTeleportTime, TutorialTeleportCompleteEarly, TutorialThumbstickTime, TutorialThumbstickCompleteEarly, " +
                "TutorialCompleteTime, TutorialCompleteCompleteEarly, ShowerTotalTime, ShowerLumpTime, ShowerSwellingTime, ShowerThrobbingTime, BedroomTotalTime, " +
                "BedroomTouchBookTime, BedroomCancerSelectionPosition, BedroomEpididymisSelectionPosition, BedroomSpermaticCordSelectionPosition, " +
                "RecapTotalTime, RecapFingerprintTime, RecapChecklistTime, RecapMedkitTime";

            List<string> lines = new List<string>();
            lines.Add(header);

            foreach (EmatVrParticipant p in participants)
            {
                string line = p.ID + ", " + p.SimulationTotalTime + ", " + p.TutorialTotalTime + ", " + p.TutorialMoveForwardTime + ", " + p.TutorialMoveForwardCompleteEarly + ", " + p.TutorialRotateTime + ", " +
                p.TutorialRotateCompleteEarly + ", " + p.TutorialTeleportTime + ", " + p.TutorialTeleportCompleteEarly + ", " + p.TutorialThumbstickTime + ", " + p.TutorialThumbstickCompleteEarly + ", " +
                p.TutorialCompleteTime + ", " + p.TutorialCompleteCompleteEarly + ", " + p.ShowerTotalTime + ", " + p.ShowerLumpTime + ", " + p.ShowerSwellingTime + ", " + p.ShowerThrobbingTime + ", " + p.BedroomTotalTime + ", " +
                p.BedroomTouchBookTime + ", " + p.BedroomCancerSelectionPosition + ", " + p.BedroomEpididymisSelectionPosition + ", " + p.BedroomSpermaticCordSelectionPosition + ", " +
                p.RecapTotalTime + ", " + p.RecapFingerprintTime + ", " + p.RecapChecklistTime + ", " + p.RecapMedkitTime;

                lines.Add(line);
            }

            try
            {
                File.WriteAllLines(path, lines.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                success = false;
            }

            return success;
        }

    }
}
