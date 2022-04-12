using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMATVRAnalysis
{
    public class EMATVrObject
    {
        private string ID { get; }
        public bool flagInAnalysis { get; }
        public decimal simulation_totalTime { get; }
        public decimal tutorial_totalTime { get; }
        public decimal tutorial_moveForwardTime { get; }
        public bool tutorial_moveForward_completeEarly { get; }
        public decimal tutorial_rotateTime { get; }
        public bool tutorial_rotate_completeEarly { get; }
        public decimal tutorial_teleportTime { get; }
        public bool tutorial_teleport_completeEarly { get; }
        public decimal tutorial_thumbstickTime { get; }
        public bool tutorial_thumbstick_completeEarly { get; }
        public decimal tutorial_completeTime { get; }
        public bool tutorial_complete_completeEarly { get; }
        //public decimal 


        public EMATVrObject(
            string ID, 
            decimal simulationTotalTime, 
            decimal tutorialTotalTime, 
            decimal tutorialMoveForwardTime,
            bool tutorial_moveForwardCompleteEarly,
            decimal tutorialRotateTime, 
            bool tutorial_rotateCompleteEarly,
            decimal tutorialTeleportTime, 
            bool tutorial_thumbstickCompleteEarly,
            decimal tutorialThumbstickTime, 
            decimal tutorialCompleteTime,
            bool tutorial_completeCompleteEarly)
        {
            this.ID = ID;
            simulation_totalTime = simulationTotalTime;
            tutorial_totalTime = tutorialTotalTime;
            tutorial_moveForwardTime = tutorialMoveForwardTime;
            tutorial_rotateTime = tutorialRotateTime;
            tutorial_teleportTime = tutorialTeleportTime;
            tutorial_thumbstickTime = tutorialThumbstickTime;
            tutorial_completeTime = tutorialCompleteTime;
            tutorial_moveForward_completeEarly = tutorial_completeCompleteEarly;
            tutorial_rotate_completeEarly = tutorial_rotateCompleteEarly;
            tutorial_thumbstick_completeEarly = tutorial_thumbstickCompleteEarly;
            tutorial_complete_completeEarly = tutorial_completeCompleteEarly;

            printData();

            if (simulation_totalTime <= 0 ||
                tutorial_moveForwardTime <= 0 ||
                tutorial_totalTime <= 0 || 
                tutorial_rotateTime <= 0 || 
                tutorial_teleportTime <= 0 ||
                tutorial_thumbstickTime <= 0 ||
                tutorial_completeTime <= 0)
            {
                flagInAnalysis = true;
            }
        }

        public void printData()
        {
            Console.WriteLine();
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Simulation Total Time: " + simulation_totalTime);
            Console.WriteLine("\nTUTORIAL---------\n");
            Console.WriteLine("Total Time: " + tutorial_totalTime);
            Console.WriteLine("Move Forward Time " + tutorial_moveForwardTime);
            Console.WriteLine("Teleport Time: " + tutorial_teleportTime);
            Console.WriteLine("Thumbstick Time: " + tutorial_thumbstickTime);
            Console.WriteLine("Complete Time: " + tutorial_completeTime);

        }

    }
}
