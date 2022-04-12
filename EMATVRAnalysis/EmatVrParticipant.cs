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
            decimal showerThrobbingTime
            )
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


            printData();

            if (SimulationTotalTime <= 0 ||
                TutorialMoveForwardTime <= 0 ||
                TutorialTotalTime <= 0 || 
                TutorialRotateTime <= 0 || 
                TutorialTeleportTime <= 0 ||
                TutorialThumbstickTime <= 0 ||
                TutorialCompleteTime <= 0)
            {
                FlagInAnalysis = true;
            }
        }

        public void printData()
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Simulation Total Time: " + SimulationTotalTime);
            Console.WriteLine("\nTUTORIAL---------\n");
            Console.WriteLine("Total Time: " + TutorialTotalTime);
            Console.WriteLine("Move Forward Time: " + TutorialMoveForwardTime);
            Console.WriteLine("Move Forward Completed Pre Audio: " + TutorialMoveForwardCompleteEarly);
            Console.WriteLine("Rotate Time: " + TutorialRotateTime);
            Console.WriteLine("Rotate Completed Pre Audio: " + TutorialRotateCompleteEarly);
            Console.WriteLine("Teleport Time: " + TutorialTeleportTime);
            Console.WriteLine("Teleport Completed Pre Audio: " + TutorialTeleportCompleteEarly);
            Console.WriteLine("Thumbstick Time: " + TutorialThumbstickTime);
            Console.WriteLine("Thumbstick Completed Pre Audio: " + TutorialThumbstickCompleteEarly);
            Console.WriteLine("Complete Time: " + TutorialCompleteTime);
            Console.WriteLine("Complete Completed Pre Audio: " + TutorialCompleteCompleteEarly);


        }

    }
}
