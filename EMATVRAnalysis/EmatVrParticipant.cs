using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace EMATVRAnalysis
{
    public class EmatVrParticipant
    {
        private string ID { get; }
        public bool FlagInAnalysis { get; }
        public decimal SimulationTotalTime { get; }

        // Tutorial Variables

        public decimal TutorialTotalTime { get; }
        public decimal TutorialMoveForwardTime { get; }
        public bool TutorialMoveForwardCompleteEarly { get; }
        public decimal TutorialRotateTime { get; }
        public bool TutorialRotateCompleteEarly { get; }
        public decimal TutorialTeleportTime { get; }
        public bool TutorialTeleportCompleteEarly { get; }
        public decimal TutorialThumbstickTime { get; }
        public bool TutorialThumbstickCompleteEarly { get; }
        public decimal TutorialCompleteTime { get; }
        public bool TutorialCompleteCompleteEarly { get; }

        // Shower variables
        public decimal ShowerTotalTime { get; }
        public decimal ShowerLumpTime { get; }
        public decimal ShowerSwellingTime { get; }
        public decimal ShowerThrobbingTime { get; }
        
        // Bedroom variables
        public decimal BedroomTotalTime { get; }
        // The time it took the user to touch the book from the START of the level
        public decimal BedroomTouchBookTime { get; }
        public int BedroomCancerSelectionPosition { get; }
        public int BedroomEpididymisSelectionPosition { get; }
        public int BedroomSpermaticCordSelectionPosition { get; }

        // Recap variables
        public decimal RecapTotalTime { get; }
        public decimal RecapFingerprintTime { get; }
        public decimal RecapChecklistTime { get; }
        public decimal RecapMedkitTime { get; }


        public EmatVrParticipant(
            string ID, 
            decimal simulationTotalTime, 
            decimal tutorialTotalTime, 
            decimal tutorialMoveForwardTime,
            bool tutorialMoveForwardCompleteEarly,
            decimal tutorialRotateTime, 
            bool tutorialRotateCompleteEarly,
            decimal tutorialTeleportTime,
            bool tutorialTeleportCompleteEarly,
            decimal tutorialThumbstickTime,
            bool tutorialThumbstickCompleteEarly,
            decimal tutorialCompleteTime,
            bool tutorialCompleteCompleteEarly, 
            decimal showerTotalTime, 
            decimal showerLumpTime, 
            decimal showerSwellingTime, 
            decimal showerThrobbingTime, 
            decimal bedroomTotalTime, 
            decimal bedroomTouchBookTime, 
            int bedroomCancerSelectionPosition, 
            int bedroomEpididymisSelectionPosition, 
            int bedroomSpermaticCordSelectionPosition, 
            decimal recapTotalTime, 
            decimal recapFingerprintTime, 
            decimal recapChecklistTime, 
            decimal recapMedkitTime)
        {
            this.ID = ID;
            SimulationTotalTime = simulationTotalTime;
            
            TutorialTotalTime = tutorialTotalTime;
            TutorialMoveForwardTime = tutorialMoveForwardTime;
            TutorialRotateTime = tutorialRotateTime;
            TutorialTeleportTime = tutorialTeleportTime;
            TutorialThumbstickTime = tutorialThumbstickTime;
            TutorialCompleteTime = tutorialCompleteTime;
            
            TutorialMoveForwardCompleteEarly = tutorialMoveForwardCompleteEarly;
            TutorialRotateCompleteEarly = tutorialRotateCompleteEarly;
            TutorialTeleportCompleteEarly = tutorialTeleportCompleteEarly;
            TutorialThumbstickCompleteEarly = tutorialThumbstickCompleteEarly;
            TutorialCompleteCompleteEarly = tutorialCompleteCompleteEarly;
            ShowerTotalTime = showerTotalTime;
            ShowerLumpTime = showerLumpTime;
            ShowerSwellingTime = showerSwellingTime;
            ShowerThrobbingTime = showerThrobbingTime;
            BedroomTotalTime = bedroomTotalTime;
            BedroomTouchBookTime = bedroomTouchBookTime;
            BedroomCancerSelectionPosition = bedroomCancerSelectionPosition;
            BedroomEpididymisSelectionPosition = bedroomEpididymisSelectionPosition;
            BedroomSpermaticCordSelectionPosition = bedroomSpermaticCordSelectionPosition;
            RecapTotalTime = recapTotalTime;
            RecapFingerprintTime = recapFingerprintTime;
            RecapChecklistTime = recapChecklistTime;
            RecapMedkitTime = recapMedkitTime;

            // Set a flag that this file should be manually inspected.
            if (SimulationTotalTime <= 0 ||
                TutorialMoveForwardTime <= 0 ||
                TutorialTotalTime <= 0 || 
                TutorialRotateTime <= 0 || 
                TutorialTeleportTime <= 0 ||
                TutorialThumbstickTime <= 0 ||
                TutorialCompleteTime <= 0 ||
                ShowerTotalTime <= 0 ||
                ShowerLumpTime <= 0 ||
                ShowerSwellingTime <= 0 ||
                ShowerThrobbingTime <= 0 || 
                BedroomTotalTime <= 0 ||
                BedroomTouchBookTime <= 0 ||
                BedroomCancerSelectionPosition <= 0 ||
                BedroomEpididymisSelectionPosition <= 0 ||
                BedroomSpermaticCordSelectionPosition <= 0 ||
                RecapTotalTime <= 0 || 
                RecapFingerprintTime <= 0 ||
                RecapChecklistTime <= 0 || 
                RecapMedkitTime <= 0)
            {
                FlagInAnalysis = true;
            }
        }

        public void PrintData()
        {
            Console.WriteLine("\nID: " + ID +
                              "\nSimulation Total Time: " + SimulationTotalTime +
                              "\n\nTUTORIAL---------\n" +
                              "\nTotal Time: " + TutorialTotalTime +
                              "\nMove Forward Time: " + TutorialMoveForwardTime +
                              "\nMove Forward Completed Pre Audio: " + TutorialMoveForwardCompleteEarly +
                              "\nRotate Time: " + TutorialRotateTime +
                              "\nRotate Completed Pre Audio: " + TutorialRotateCompleteEarly +
                              "\nTeleport Time: " + TutorialTeleportTime +
                              "\nTeleport Completed Pre Audio: " + TutorialTeleportCompleteEarly +
                              "\nThumbstick Time: " + TutorialThumbstickTime +
                              "\nThumbstick Completed Pre Audio: " + TutorialThumbstickCompleteEarly +
                              "\nComplete Time: " + TutorialCompleteTime +
                              "\nComplete Completed Pre Audio: " + TutorialCompleteCompleteEarly +
                              "\n\nSHOWER----------\n" +
                              "\nShower Total Time: " + ShowerTotalTime +
                              "\nShower Lump Search Time: " + ShowerLumpTime + 
                              "\nShower Swelling Search Time: " + ShowerSwellingTime + 
                              "\nShower Throbbing Search Time: " + ShowerThrobbingTime + 
                              "\n\nBEDROOM---------\n" +
                              "\nBedroom Total Time: " + BedroomTotalTime +
                              "\nBedroom Touch Book Time: " + BedroomTouchBookTime +
                              "\nCancer Selection Position: " + BedroomCancerSelectionPosition +
                              "\nEpididymis Selection Position: " + BedroomEpididymisSelectionPosition + 
                              "\nBedroom Spermatic Cord Selection Position: " + BedroomSpermaticCordSelectionPosition +
                              "\n\nRECAP-----------\n" +
                              "\nRecap Total Time: " + RecapTotalTime + 
                              "\nRecap Fingerprint Time: " + RecapFingerprintTime + 
                              "\nRecap Checklist Time: " + RecapChecklistTime +
                              "\nRecap Medkit Time: " + RecapMedkitTime
            );
        }

    }
}
