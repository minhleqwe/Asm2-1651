using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Test.Interface;

namespace Test
{
    public class Run
    {
        static void Main(string[] args)
        {
            IVehicleFactory factory = null;
            AbstractCar carProduct = null;
            AbstractShip shipProduct = null;
            List<AbstractCar> carList = new List<AbstractCar>();
            List<AbstractShip> shipList = new List<AbstractShip>();
            bool exit = false;
            int editing = 0;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|                    MENU                    |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 1. Create products                         |");
                Console.WriteLine("| 2. Show list product                       |");
                Console.WriteLine("| 3. Add product parameters                  |");
                Console.WriteLine("| 4. Delete product                          |");
                Console.WriteLine("| 5. Test product                            |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("");
                Console.WriteLine("Please choose one");
                int choiceMenu1;
                try
                {
                    choiceMenu1 = int.Parse(Console.ReadLine());

                    switch (choiceMenu1)
                    {
                        case 1:
                            bool backToLevel1 = false;
                            while (!backToLevel1)
                            {
                                Console.Clear();
                                Console.WriteLine("+--------------------------------------------+");
                                Console.WriteLine("|              CHOOSE YOUR FUEL              |");
                                Console.WriteLine("+--------------------------------------------+");
                                Console.WriteLine("| 1. Electric                                |");
                                Console.WriteLine("| 2. Gasoline                                |");
                                Console.WriteLine("| 3. Back                                    |");
                                Console.WriteLine("+--------------------------------------------+");
                                Console.WriteLine("");
                                Console.WriteLine("Choose a fuel you want to use");
                                string choiceMenu2;
                                choiceMenu2 = Console.ReadLine();
                                if (Regex.IsMatch(choiceMenu2, "[0-9]") && choiceMenu2 != "0")
                                {
                                    switch (choiceMenu2)
                                    {
                                        case "1":
                                            factory = new ElectricFactory();
                                            bool backToLevel2 = false;
                                            while (!backToLevel2)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("|             CHOOSE YOUR VEHICLE            |");
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("| 1. Car                                     |");
                                                Console.WriteLine("| 2. Ship                                    |");
                                                Console.WriteLine("| 3. Back                                    |");
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("");
                                                Console.WriteLine("Choose the vehicle you want to own");
                                                string choiceMenu3;
                                                choiceMenu3 = Console.ReadLine();
                                                if (Regex.IsMatch(choiceMenu3, "[0-9]") && choiceMenu3 != "0")
                                                {
                                                    switch (choiceMenu3)
                                                    {
                                                        case "1":
                                                            carProduct = factory.CreateCar();
                                                            carProduct.Name = "Car";
                                                            carProduct.Fuel = "Electric";
                                                            carList.Add(carProduct);
                                                            createNotification();
                                                            backToLevel2 = true;
                                                            backToLevel1 = true;
                                                            break;
                                                        case "2":
                                                            shipProduct = factory.CreateShip();
                                                            shipProduct.Name = "Ship";
                                                            shipProduct.Fuel = "Electric";
                                                            shipList.Add(shipProduct);
                                                            createNotification();
                                                            backToLevel2 = true;
                                                            backToLevel1 = true;
                                                            //
                                                            break;
                                                        case "3":
                                                            backToLevel2 = true;
                                                            break;
                                                        default:
                                                            invalidNotification();
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    invalidNotification();
                                                }
                                            }
                                            break;
                                        case "2":
                                            factory = new GasolineFactory();
                                            bool backToLevel2_1 = false;
                                            while (!backToLevel2_1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("|            CHOOSE YOUR VEHICLE             |");
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("| 1. Car                                     |");
                                                Console.WriteLine("| 2. Ship                                    |");
                                                Console.WriteLine("| 3. Back to menu                            |");
                                                Console.WriteLine("+--------------------------------------------+");
                                                Console.WriteLine("");
                                                Console.WriteLine("Choose the vehicle you want to own");
                                                string choiceMenu3;
                                                choiceMenu3 = Console.ReadLine();
                                                if (Regex.IsMatch(choiceMenu3, "[0-9]") && choiceMenu3 != "0")
                                                {
                                                    switch (choiceMenu3)
                                                    {
                                                        case "1":
                                                            carProduct = factory.CreateCar();
                                                            carProduct.Name = "Car";
                                                            carProduct.Fuel = "Gasoline";
                                                            carList.Add(carProduct);
                                                            createNotification();
                                                            backToLevel2_1 = true;
                                                            backToLevel1 = true;
                                                            break;
                                                        case "2":
                                                            shipProduct = factory.CreateShip();
                                                            shipProduct.Name = "Ship";
                                                            shipProduct.Fuel = "Gasoline";
                                                            shipList.Add(shipProduct);
                                                            createNotification();
                                                            backToLevel2_1 = true;
                                                            backToLevel1 = true;
                                                            break;
                                                        case "3":
                                                            backToLevel2_1 = true;
                                                            break;
                                                        default:
                                                            invalidNotification();
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    invalidNotification();
                                                }
                                            }
                                            break;
                                        case "3":
                                            backToLevel1 = true;
                                            break;
                                        default:
                                            invalidNotification();
                                            break;
                                    }
                                }
                                else
                                {
                                    invalidNotification();
                                }
                            }
                            break;
                        case 2:
                            productList();
                            Console.ReadLine();
                            break;
                        case 3:
                            productList();
                            Console.WriteLine("Select the product you want to add data for:");
                            int choiceEdit;
                            try
                            {
                                choiceEdit = int.Parse(Console.ReadLine());
                                bool CarChoice = false;
                                bool ShipChoice = false;
                                int choseEdit = (choiceEdit - 1);
                                if (choseEdit < carList.Count)
                                {
                                    for (int i = 0; i < carList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            CarChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    choseEdit = choseEdit - carList.Count;
                                    for (int i = 0; i < shipList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            ShipChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                if (CarChoice)
                                {
                                    bool edit_while = false;
                                    while (!edit_while)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("|                  EDIT - CAR                |");
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("| 1. Edit Engine Capacity                    |");
                                        Console.WriteLine("| 2. Edit Acceleration                       |");
                                        Console.WriteLine("| 3. Back                                    |");
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("");
                                        Console.WriteLine("Please choose one");
                                        int choiceEditItem;
                                        try
                                        {
                                            choiceEditItem = int.Parse(Console.ReadLine());
                                            switch (choiceEditItem)
                                            {
                                                case 1:
                                                    bool edit_size = false;
                                                    while (!edit_size)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("|      EDIT-CHOOSE YOUR ENGINE CAPACITY      |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("| 1. 800cc                                   |");
                                                        Console.WriteLine("| 2. 1500cc                                  |");
                                                        Console.WriteLine("| 3. 2500cc                                  |");
                                                        Console.WriteLine("| 4. Back                                    |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Please choose one");
                                                        int vehicleToolEdit = 0;
                                                        try
                                                        {
                                                            vehicleToolEdit = int.Parse(Console.ReadLine());
                                                            switch (vehicleToolEdit)
                                                            {
                                                                case 1:
                                                                    carList[editing].Enginecapacity = "800cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 2:
                                                                    carList[editing].Enginecapacity = "1500cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 3:
                                                                    carList[editing].Enginecapacity = "2500cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 4:
                                                                    edit_size = true;
                                                                    break;
                                                                default:
                                                                    invalidNotification();
                                                                    break;
                                                            }
                                                        }
                                                        catch (System.Exception e)
                                                        {
                                                            invalidNotification();
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    bool edit_status = false;
                                                    while (!edit_status)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("|             EDIT ACCELERATION              |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("| 1. 30km/h                                  |");
                                                        Console.WriteLine("| 2. 45km/h                                  |");
                                                        Console.WriteLine("| 3. 60km/h                                  |");
                                                        Console.WriteLine("| 4. Back                                    |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Please choose one");
                                                        int EditStatus;
                                                        try
                                                        {
                                                            EditStatus = int.Parse(Console.ReadLine());

                                                            switch (EditStatus)
                                                            {
                                                                case 1:
                                                                    carList[editing].Acceleration = 30;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 2:
                                                                    carList[editing].Acceleration = 45;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 3:
                                                                    carList[editing].Acceleration = 60;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 4:
                                                                    edit_status = true;
                                                                    break;
                                                                default:
                                                                    invalidNotification();
                                                                    break;
                                                            }
                                                        }
                                                        catch (System.Exception e)
                                                        {
                                                            invalidNotification();
                                                        }
                                                    }
                                                    break;
                                                case 3:
                                                    edit_while = true;
                                                    break;
                                                default:
                                                    invalidNotification();
                                                    break;
                                            }
                                        }
                                        catch (System.Exception e)
                                        {
                                            invalidNotification();
                                        }
                                    }
                                }
                                else if (ShipChoice)
                                {
                                    bool edit_while = false;
                                    while (!edit_while)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("|                    EDIT - SHIP             |");
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("| 1. Edit Engine Capacity                    |");
                                        Console.WriteLine("| 2. Edit Acceleration                       |");
                                        Console.WriteLine("| 3. Back                                    |");
                                        Console.WriteLine("+--------------------------------------------+");
                                        Console.WriteLine("");
                                        Console.WriteLine("Please choose one");
                                        int choiceEditItem;
                                        try
                                        {
                                            choiceEditItem = int.Parse(Console.ReadLine());

                                            switch (choiceEditItem)
                                            {
                                                case 1:
                                                    bool edit_size = false;
                                                    while (!edit_size)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("|      EDIT-CHOOSE YOUR ENGINE CAPACITY      |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("| 1. 800cc                                   |");
                                                        Console.WriteLine("| 2. 1500cc                                  |");
                                                        Console.WriteLine("| 3. 2500cc                                  |");
                                                        Console.WriteLine("| 4. Back                                    |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Please choose one");
                                                        int vehicleToolEdit;
                                                        try
                                                        {
                                                            vehicleToolEdit = int.Parse(Console.ReadLine());
                                                            switch (vehicleToolEdit)
                                                            {
                                                                case 1:
                                                                    shipList[editing].Enginecapacity = "800cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 2:
                                                                    shipList[editing].Enginecapacity = "1500cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 3:
                                                                    shipList[editing].Enginecapacity = "2500cc";
                                                                    edit_size = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 4:
                                                                    edit_size = true;
                                                                    break;
                                                                default:
                                                                    invalidNotification();
                                                                    break;
                                                            }
                                                        }
                                                        catch (System.Exception e)
                                                        {
                                                            invalidNotification();
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    bool edit_status = false;
                                                    while (!edit_status)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("|             EDIT ACCELERATION              |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("| 1. 30km/h                                   |");
                                                        Console.WriteLine("| 2. 45km/h                                   |");
                                                        Console.WriteLine("| 3. 60km/h                                   |");
                                                        Console.WriteLine("| 4. Back                                    |");
                                                        Console.WriteLine("+--------------------------------------------+");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Please choose one");
                                                        int EditStatus;
                                                        try
                                                        {
                                                            EditStatus = int.Parse(Console.ReadLine());
                                                            switch (EditStatus)
                                                            {
                                                                case 1:
                                                                    shipList[editing].Acceleration = 30;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    Console.Clear();
                                                                    editNotification();
                                                                    break;
                                                                case 2:
                                                                    shipList[editing].Acceleration = 45;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 3:
                                                                    shipList[editing].Acceleration = 60;
                                                                    edit_status = true;
                                                                    edit_while = true;
                                                                    editNotification();
                                                                    break;
                                                                case 4:
                                                                    edit_status = true;
                                                                    break;
                                                                default:
                                                                    invalidNotification();
                                                                    break;
                                                            }
                                                        }
                                                        catch (System.Exception e)
                                                        {
                                                            invalidNotification();
                                                        }
                                                    }
                                                    break;
                                                case 3:
                                                    edit_while = true;
                                                    break;
                                                default:
                                                    invalidNotification();
                                                    break;
                                            }
                                        }
                                        catch (System.Exception e)
                                        {
                                            invalidNotification();
                                        }
                                    }
                                }
                                else
                                {
                                    invalidNotification();
                                }
                            }
                            catch (System.Exception e)
                            {
                                invalidNotification();
                            }
                            break;
                        case 4:
                            productList();
                            Console.WriteLine("Choose the product you want to delete:");
                            int choiceDelete;
                            try
                            {
                                choiceDelete = int.Parse(Console.ReadLine());
                                bool CarChoice = false;
                                bool ShipChoice = false;
                                int choseEdit = (choiceDelete - 1);
                                if (choseEdit < carList.Count)
                                {
                                    for (int i = 0; i < carList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            CarChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    choseEdit = choseEdit - carList.Count;
                                    for (int i = 0; i < shipList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            ShipChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                if (CarChoice)
                                {
                                    carList.Remove(carList[editing]);
                                    deleteNotification();
                                }
                                if (ShipChoice)
                                {
                                    shipList.Remove(shipList[editing]);
                                    deleteNotification();
                                }
                            }
                            catch (System.Exception e)
                            {
                                invalidNotification();
                            }
                            break;
                        case 5:
                            productList();
                            Console.WriteLine("Choose the product you want to test:");
                            int choiceTest;
                            try
                            {
                                choiceTest = int.Parse(Console.ReadLine());

                                bool CarChoice = false;
                                bool ShipChoice = false;
                                int choseEdit = (choiceTest - 1);
                                if (choseEdit < carList.Count)
                                {
                                    for (int i = 0; i < carList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            CarChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    choseEdit = choseEdit - carList.Count;
                                    for (int i = 0; i < shipList.Count; i++)
                                    {
                                        if (choseEdit == i)
                                        {
                                            ShipChoice = true;
                                            editing = i;
                                            break;
                                        }
                                    }
                                }
                                if (CarChoice)
                                {
                                    if (!string.IsNullOrEmpty(carList[editing].Enginecapacity) && !string.IsNullOrEmpty(carList[editing].Acceleration.ToString())) 
                                    {
                                        bool carTest = false;
                                        while (!carTest)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("|                 TESTING CAR                |");
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("| 1. Speed up                                |");
                                            Console.WriteLine("| 2. Reduce speed                            |");
                                            Console.WriteLine("| 3. Move                                    |");
                                            Console.WriteLine("| 4. Back                                    |");
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("");
                                            Console.WriteLine("Please choose one");
                                            int testing;
                                            try
                                            {
                                                testing = int.Parse(Console.ReadLine());
                                                switch (testing)
                                                {
                                                    case 1:
                                                        double firstSpeed = 0;
                                                        double secondSpeed = 0;
                                                        double checkValid;
                                                        bool loop = false;
                                                        while (!loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|            Testing with Speed up           |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        while (loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Input your second speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                secondSpeed = checkValid;
                                                                loop = false;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("The acceleration time with the selected acceleration is: ");
                                                        Console.WriteLine(changeToMinute(Math.Round(carList[editing].speedup(firstSpeed, secondSpeed))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        loop = false;
                                                        firstSpeed = 0;
                                                        secondSpeed = 0;
                                                        while (!loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|          Testing with Reduce speed         |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        while (loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("");
                                                            Console.WriteLine("");
                                                            Console.WriteLine("Input your second speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());

                                                                secondSpeed = checkValid;
                                                                loop = false;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("The deceleration time with the selected acceleration is: ");
                                                        Console.WriteLine(changeToMinute(Math.Round(carList[editing].reducespeed(firstSpeed, secondSpeed))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        loop = false;
                                                        firstSpeed = 0;
                                                        double enginecapacity = 0;
                                                        while (!loop)
                                                        {
                                                            if (carList[editing].Enginecapacity == "800cc")
                                                            {
                                                                enginecapacity = 800.0;
                                                            }
                                                            if (carList[editing].Enginecapacity == "1500cc")
                                                            {
                                                                enginecapacity = 1500.0;
                                                            }
                                                            if (carList[editing].Enginecapacity == "2500cc")
                                                            {
                                                                enginecapacity = 2500.0;
                                                            }
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|                Testing move                |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed (Km/h): ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("100km travel time of car with " + firstSpeed + "Km/h with engine capacity car = " + carList[editing].Enginecapacity + " :");
                                                        Console.WriteLine(changeToMinute(Math.Round(carList[editing].move(firstSpeed, enginecapacity))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        carTest = true;
                                                        break;
                                                    default:
                                                        invalidNotification();
                                                        break;
                                                }
                                            }
                                            catch (System.Exception e)
                                            {
                                                invalidNotification();
                                            }
                                        }
                                    }
                                
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("+------------------------------------------------------+");
                                    Console.WriteLine("|  Your product must have full information to testing  |");
                                    Console.WriteLine("+------------------------------------------------------+");
                                    Console.ReadLine();
                                }
                                }
                                if (ShipChoice)
                                {
                                    if (!string.IsNullOrEmpty(shipList[editing].Enginecapacity) && !string.IsNullOrEmpty(shipList[editing].Acceleration.ToString())) 
                                    {
                                        bool shipTest = false;
                                        while (!shipTest)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("|                TESTING SHIP                |");
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("| 1. Speed up                                |");
                                            Console.WriteLine("| 2. Reduce speed                            |");
                                            Console.WriteLine("| 3. Downstream                              |");
                                            Console.WriteLine("| 4. Upstream                                |");
                                            Console.WriteLine("| 5. Back                                    |");
                                            Console.WriteLine("+--------------------------------------------+");
                                            Console.WriteLine("");
                                            Console.WriteLine("Please choose one");
                                            int testing;
                                            try
                                            {
                                                testing = int.Parse(Console.ReadLine());

                                                switch (testing)
                                                {
                                                    case 1:
                                                        double firstSpeed = 0;
                                                        double secondSpeed = 0;
                                                        double checkValid;
                                                        bool loop = false;
                                                        while (!loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|            Testing with Speed up           |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        while (loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Input your second speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());

                                                                secondSpeed = checkValid;
                                                                loop = false;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("The deceleration time with the selected acceleration is: ");
                                                        Console.WriteLine(changeToMinute(Math.Round(shipList[editing].speedup(firstSpeed, secondSpeed))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 2:
                                                        loop = false;
                                                        firstSpeed = 0;
                                                        secondSpeed = 0;
                                                        while (!loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|          Testing with Reduce speed         |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        while (loop)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("");
                                                            Console.WriteLine("Input your second speed: ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());

                                                                secondSpeed = checkValid;
                                                                loop = false;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("The deceleration time with the selected acceleration is: ");
                                                        Console.WriteLine(changeToMinute(Math.Round(shipList[editing].reducespeed(firstSpeed, secondSpeed))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 3:
                                                        loop = false;
                                                        firstSpeed = 0;
                                                        double enginecapacity = 0;
                                                        while (!loop)
                                                        {
                                                            if (shipList[editing].Enginecapacity == "800cc")
                                                            {
                                                                enginecapacity = 800.0;
                                                            }
                                                            if (shipList[editing].Enginecapacity == "1500cc")
                                                            {
                                                                enginecapacity = 1500.0;
                                                            }
                                                            if (shipList[editing].Enginecapacity == "2500cc")
                                                            {
                                                                enginecapacity = 2500.0;
                                                            }
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|             Testing Downstream             |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed (Km/h): ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("100km travel time of ship with " + firstSpeed + "Km/h with engine capacity car = " + shipList[editing].Enginecapacity + " :" );
                                                        Console.WriteLine(changeToMinute(Math.Round(shipList[editing].downstream(firstSpeed, enginecapacity))));
                                                        Console.ReadLine();
                                                        break;
                                                    case 4:
                                                        loop = false;
                                                        firstSpeed = 0;
                                                        enginecapacity = 0;
                                                        while (!loop)
                                                        {
                                                            if (shipList[editing].Enginecapacity == "800cc")
                                                            {
                                                                enginecapacity = 800.0;
                                                            }
                                                            if (shipList[editing].Enginecapacity == "1500cc")
                                                            {
                                                                enginecapacity = 1500.0;
                                                            }
                                                            if (shipList[editing].Enginecapacity == "2500cc")
                                                            {
                                                                enginecapacity = 2500.0;
                                                            }
                                                            Console.Clear();
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("|               Testing Upstream             |");
                                                            Console.WriteLine("+--------------------------------------------+");
                                                            Console.WriteLine("Input your first speed (Km/h): ");
                                                            try
                                                            {
                                                                checkValid = double.Parse(Console.ReadLine());
                                                                firstSpeed = checkValid;
                                                                loop = true;
                                                            }
                                                            catch (System.Exception e)
                                                            {
                                                                invalidNotification();
                                                            }
                                                        }
                                                        Console.WriteLine("100km travel time of ship with " + firstSpeed + "Km/h with engine capacity car = " + shipList[editing].Enginecapacity + " :");
                                                        Console.WriteLine(changeToMinute(Math.Round(shipList[editing].upstream(firstSpeed, enginecapacity))));
                                                        Console.ReadLine();
                                                        break;

                                                    case 5:
                                                        shipTest = true;
                                                        break;
                                                    default:
                                                        invalidNotification();
                                                        break;
                                                }
                                            }
                                            catch (System.Exception e)
                                            {
                                                invalidNotification();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                        Console.WriteLine("+------------------------------------------------------+");
                                        Console.WriteLine("|  Your product must have full information to testing  |");
                                        Console.WriteLine("+------------------------------------------------------+");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                invalidNotification();
                            }
                            break;
                        default:
                            invalidNotification();
                            break;
                    }
                }
                catch (System.Exception e)
                {
                    invalidNotification();
                }
            }
            void productList()
            {
                if (carList.Count == 0 && shipList.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("+------------------------------------------------------+");
                    Console.WriteLine("|      You must have at least one product to show      |");
                    Console.WriteLine("+------------------------------------------------------+");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------ Product List--------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("+-------------------------------------------------------------------------------+");
                    Console.WriteLine("|   Num   |   Product   |     Fuel     |   Enginecapacity   |    Acceleration   |");
                    Console.WriteLine("+-------------------------------------------------------------------------------+");
                    int numTest = 1;
                    for (int i = 0; i < carList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(carList[i].Name))
                        {
                            Console.WriteLine("|    " + (numTest) + "    |     " + carList[i].Name + "     |   " + carList[i].Fuel +
                            "   |       " + carList[i].Enginecapacity + whiteSpace(carList[i].Enginecapacity) + "       |       " + carList[i].Acceleration + whiteSpace(carList[i].Acceleration.ToString()) + "      |");
                            Console.WriteLine("+-------------------------------------------------------------------------------+");
                            numTest++;
                        }
                    }
                    for (int i = 0; i < shipList.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(shipList[i].Name))
                        {
                            Console.WriteLine("|    " + (numTest) + "    |     " + shipList[i].Name + "     |   " + shipList[i].Fuel +
                            "   |       " + shipList[i].Enginecapacity + whiteSpace(shipList[i].Enginecapacity) + "       |       " + shipList[i].Acceleration + whiteSpace(shipList[i].Acceleration.ToString()) + "      |");
                            Console.WriteLine("+-------------------------------------------------------------------------------+");
                            numTest++;
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            string whiteSpace(string value)
            {
                string space = "";
                if (value == null)
                {
                    space = space + "      ";
                }
                else
                {
                    return space;
                }
                return space;
            }
            void invalidNotification()
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|               INVALID CHOICE               |");
                Console.WriteLine("+--------------------------------------------+");
                Console.ReadLine();
            }
            void createNotification()
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|              Create successful             |");
                Console.WriteLine("+--------------------------------------------+");
                Console.ReadLine();
            }
            string changeToMinute(double value)
            {
                double minute = value / 60;
                double second = value % 60;
                return Math.Round(minute) + " minute + " + Math.Round(second) + " second";
            }
            void deleteNotification()
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|              DELETE SUCCESS                |");
                Console.WriteLine("+--------------------------------------------+");
                Console.ReadLine();
            }
            void editNotification()
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("|                 EDIT SUCCESS               |");
                Console.WriteLine("+--------------------------------------------+");
                Console.ReadLine();
            }
        }
    }
}
