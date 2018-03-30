using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added
using System.Web.Script.Serialization;
using System.IO;


namespace ConsoleApp9
{
    //main class
    class Program
    {
        static void Main(string[] args)
        {
            //Objects
            Car Car1 = new Car("Car 1", "NF123456", 147, 200, "green", true);
            Car Car2 = new Car("Car 2", "NF654321", 150, 195, "blue", true);
            Plane Plane1 = new Plane("Plane 1", "LN1234", 1000, 30, 3, 10, "Jet plane");
            Boat Boat1 = new Boat("Boat 1", "ABC123", 100, 30, 50);
            Console.WriteLine();

            //Methods
            Car1.CarCompare(Car2.carID, Car2.licPlate, Car2.engPower, Car2.maxSpeed, Car2.carColour, Car2.personalCar);
            Console.WriteLine();

            Car1.Drive(1, 90);
            Car1.Drive(2, 70);
            Car1.Drive(1.2, 50);
            Car1.Drive(0.5, 30);
            Console.WriteLine();

            Plane1.Fly(1000, 2000, 2.5);
            Plane1.Fly(5000, 4000, 5);
            Plane1.Fly(9000, 6000, 6);
            Plane1.Fly(10000, 9900, 7);
            Plane1.Fly(10000, 10000, 7);
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Press any key to exit ");
            Console.Read();

        }
    }

    //Class Car
    class Car
    {
        // Given variables, atributes
        public string carID;
        public string licPlate;
        public int engPower;
        public int maxSpeed;
        public string carColour;
        public bool personalCar;
        public double cDist;

        //Constructor
        public Car(string carID, string licPlate, int engPower, int maxSpeed, string carColour, bool personalCar)
        {
            this.carID = carID;
            this.licPlate = licPlate;
            this.engPower = engPower;
            this.maxSpeed = maxSpeed;
            this.carColour = carColour;
            this.personalCar = personalCar;
        }

        // Methods
        public void Drive(double cTime, int cSpeed)
        {
            if (cSpeed == 0)
                Console.WriteLine("{0} is stopped", carID);
            else if (cSpeed > 200)
            {
                Console.WriteLine("{0} cannot travel at this speed", carID);
                cSpeed = 0;
            }
            else
                cDist = cTime * cSpeed + cDist;
            if (cDist > 300 && cDist < 340)
                Console.WriteLine("{0} arrived to its destiny!", carID);
            else if (cDist >= 340)
                Console.WriteLine("{0} traveled for {1} km, maybe it got lost.", carID, cDist);
            else
                Console.WriteLine("Distance traveled: {0} km", cDist);
        }

        public void CarCompare(string carID, string licPlate, int engPower, int maxSpeed, string carColour, bool personalCar)
        {
            if (this.licPlate == licPlate && this.engPower == engPower && this.maxSpeed == maxSpeed && this.carColour == carColour && this.personalCar == personalCar)
                Console.WriteLine("{0} and {1} are the same car", this.carID, carID);
            else
                Console.WriteLine("{0} and {1} are not the same car", this.carID, carID);
        }


    }

    //Class Plane
    class Plane
    {
        // Variables, atributes
        private string planeID;
        public string planeReg;
        public int engPower;
        public int wingspan;
        public int loadCap;
        public int netWeight;
        public string flyingClass;

        public double pDist;
        public double pSpeed;
        public int pX;
        public int pY;
        public double pTime;

        //Constructor
        public Plane(string planeID, string planeReg, int engPower, int wingspan, int loadCap, int netWeight, string flyingClass)
        {
            this.planeID = planeID;
            this.planeReg = planeReg;
            this.engPower = engPower;
            this.wingspan = wingspan;
            this.loadCap = loadCap;
            this.netWeight = netWeight;
            this.flyingClass = flyingClass;
        }

        // Methods
        public void Fly(int pX, int pY, double pTime)
        {
            pTime = this.pTime + pTime;
            pDist = Math.Sqrt((pX - this.pX) * (pX - this.pX) + (pY - this.pY) * (pY - this.pY));
            pDist = Math.Round(pDist);
            pSpeed = pDist / (pTime - this.pTime);
            pSpeed = Math.Round(pSpeed);
            this.pX = pX;
            this.pY = pY;
            this.pTime = pTime;

            if (pX == 10000 && pY == 10000)
                Console.WriteLine("The Plane {0} has just landed.", planeReg);
            else if (pX < 10500 && pX > 9500 && pY < 10500 && pY > 9500)
            {
                Console.WriteLine("After {0} hours, Location: ({1},{2}), Average speed: {3} km/h", pTime, pX, pY, pSpeed);
                Console.WriteLine("The plane {0} asks a permission to land.", planeReg);
            }
            else if (pX > 10500 && pY > 10500)
            {
                Console.WriteLine("After {0} hours, Location: ({1},{2}), Average speed: {3} km/h", pTime, pX, pY, pSpeed);
                Console.WriteLine("The plane {0} has changed its route!", planeReg);
            }
            else
                Console.WriteLine("After {0} hours, Location: ({1},{2}), Average speed: {3} km/h", pTime, pX, pY, pSpeed);
        }
    }

    //Class Boat
    class Boat
    {
        // Variables, atributes
        public string BoatID;
        public string BoatReg;
        public int EngPower;
        public double MaxSpeed;
        public int GrossTon;

        //Constructor
        public Boat(string BoatID, string BoatReg, int EngPower, double MaxSpeedknot, int GrossTon)
        {
            this.BoatID = BoatID;
            this.BoatReg = BoatReg;
            this.EngPower = EngPower;
            this.MaxSpeed = MaxSpeedknot;
            this.GrossTon = GrossTon;
        }
    }
}
