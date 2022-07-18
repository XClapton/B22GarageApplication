using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.enums;
using Ex03.GarageLogic.classes;

namespace Ex03.ConsoleUI
{
    public class GarageConsoleUI
    {
        private readonly GarageShop m_GarageShop;
        private eGarageMenu m_chosenAction;
        private bool m_IsProgramOn;

        public GarageConsoleUI()
        {
            m_GarageShop = new GarageShop();
            m_chosenAction = eGarageMenu.AddNewVehicle;
            m_IsProgramOn = true;
        }

        public void         Start()
        {
            while (m_IsProgramOn)
            {
                try
                {
                    Console.Clear();
                    m_chosenAction = getActionFromUser();
                    executeAction();
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    Console.Write("Error: ");
                    Console.WriteLine(exception.Message);
                }

                if (m_IsProgramOn)
                {
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                }
            }
        }

        private void        executeAction()
        {
            switch (m_chosenAction)
            {
                case eGarageMenu.AddNewVehicle:
                    {
                        addNewVehicleExe();
                        break;
                    }

                case eGarageMenu.PresentAllLicenseNumbers:
                    {
                        presentAllLicenseNumbersExe();
                        break;
                    }

                case eGarageMenu.ModifyVehicleStatus:
                    {
                        modifyVehicleStatusExe();
                        break;
                    }

                case eGarageMenu.InflateWheelsToMax:
                    {
                        inflateWheelsToMaxExe();
                        break;
                    }

                case eGarageMenu.RefuelVehicle:
                    {
                        refuelVehicleExe();
                        break;
                    }

                case eGarageMenu.RechargeVehicle:
                    {
                        rechargeVehicle();
                        break;
                    }

                case eGarageMenu.PresentAllVehicleData:
                    {
                        presentAllVehicleDataExe();
                        break;
                    }

                case eGarageMenu.Exit:
                    {
                        m_IsProgramOn = false;
                        break;
                    }
            }
        }    

        private void        addNewVehicleExe()
        {
            string licenseNumberMessage = "Please enter the license number vehicle: ";
            string licenseNumber = getInputFromUser(licenseNumberMessage);

            Console.Clear();

            if (m_GarageShop.CheckIfVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("This vehicle is already in the garage.");
                m_GarageShop.ModifyVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
            }
            else
            {
                eVehicleType vehicleType = getEnumValueFromUser<eVehicleType>(eVehicleType.RegularCar);

                Console.Clear();
                string ownerNameMessage = "Please enter the vehicle owner name: ";
                string ownerName = getInputFromUser(ownerNameMessage);

                Console.Clear();
                string ownerPhoneNumberMessage = "Please enter the vehicle owner phone: ";
                string ownerPhoneNumber = getInputFromUser(ownerPhoneNumberMessage);

                Vehicle vehicle = VehicleBuilder.BuildVehicle(licenseNumber, vehicleType);

                Console.Clear();
                string carModelMessage = "Please enter the model of the car: ";
                string carModel = getInputFromUser(carModelMessage);
                vehicle.Model = carModel;

                Console.Clear();
                string manufacturerNameMessege = "Please enter the wheels manufacturer: ";
                string wheelManufacturer = getInputFromUser(manufacturerNameMessege);

                try
                {
                    Console.Clear();
                    List<Wheel> wheels = vehicle.Wheels;
                    string currAirPressureMessage = "Enter the current air pressure of the wheels: ";
                    float currAirPressure = getCurrVehiclesDetailsFromUser(wheels[0].MaxAirPressure, currAirPressureMessage);
                    vehicle.SetAllWheels(wheelManufacturer, currAirPressure);

                    Console.Clear();
                    string currAmountOfEnergyMessage = "Enter the current amount of energy in the vehicle: ";
                    float currAmountOfEnergy = getCurrVehiclesDetailsFromUser(vehicle.Engine.MaxAmountOfEnergy, currAmountOfEnergyMessage);
                    vehicle.Engine.CurrAmountOfEnergy = currAmountOfEnergy;
                }
                catch(ArgumentException ae)
                {
                    throw ae;
                }
                List<string> exclusiveAttributesInputList = new List<string>();

                string input = null;
                Console.Clear();

                foreach (string builtInDetail in Vehicle.s_ExclusiveAtrributeStrings)
                {
                    Console.WriteLine("{0}", builtInDetail);
                    input = Console.ReadLine();
                    exclusiveAttributesInputList.Add(input);
                    Console.Clear();
                }

                try
                {
                    vehicle.SetUniqAttribute(exclusiveAttributesInputList);
                }
                catch(ArgumentException ae)
                {
                    throw ae;
                }

                VehicleRecord newVehicleRecord = new VehicleRecord(ownerName, ownerPhoneNumber, vehicle, eVehicleStatus.InRepair);
                m_GarageShop.AddNewCarToGarrage(licenseNumber, newVehicleRecord);
                Console.WriteLine("Vehicle was add seccessfully");
            }
        }
                            
        private void        presentAllLicenseNumbersExe()
        {
            if (m_GarageShop.GarageIsEmpty())
            {
                Console.WriteLine("The garage is empty from vehicles");
            }
            else
            {
                bool filterOn = ifUsingFilter();
                eVehicleStatus chosenFilter = eVehicleStatus.InRepair;
                List<string> licenseNumbersList = null;

                if (filterOn)
                {
                    chosenFilter = getEnumValueFromUser<eVehicleStatus>(eVehicleStatus.InRepair);
                }

                licenseNumbersList = m_GarageShop.GetLicenseNumbersByStatus(chosenFilter, filterOn);

                if (licenseNumbersList.Count == 0)
                {
                    Console.WriteLine("There are currently no vehicles matching in the garage");
                }
                else
                {
                    Console.Clear();
                    licenseNumbersList.ForEach(Console.WriteLine);
                }
            }
        }
                            
        private void        modifyVehicleStatusExe()
        {
            string message = "Please enter the license number vehicle: ";
            string licenseNumber = getInputFromUser(message);
            eVehicleStatus chosenStatus;

            if (m_GarageShop.CheckIfVehicleInGarage(licenseNumber) == false)
            {
                throw new Exception("Vehicle not found");
            }

            Console.Clear();
            chosenStatus = getEnumValueFromUser<eVehicleStatus>(eVehicleStatus.InRepair);
            m_GarageShop.ModifyVehicleStatus(licenseNumber, chosenStatus);
            Console.Clear();
            Console.WriteLine("Vehicle status changed seccessfully");
        }
                            
        private void        inflateWheelsToMaxExe()
        {
            string message = "Please enter the license number vehicle: ";
            string licenseNumber = getInputFromUser(message);

            if (m_GarageShop.CheckIfVehicleInGarage(licenseNumber) == false)
            {
                throw new Exception("Vehicle not found");
            }

            m_GarageShop.InflateWheelsToMax(licenseNumber);

            Console.Clear();
            Console.WriteLine("Wheel's inflation was executed");
        }
                            
        private void        refuelVehicleExe()
        {
            string message = "Please enter the license number vehicle: ";
            string licenseNumber = getInputFromUser(message);

            if (!m_GarageShop.CheckIfVehicleInGarage(licenseNumber))
            {
                throw new Exception("Vehicle not found");
            }

            eTypeOfFuel TypeOfFuelInput = getEnumValueFromUser<eTypeOfFuel>(eTypeOfFuel.Octan95);

            Console.Clear();
            Console.WriteLine("Enter Amount of fuel to fill: ");

            float AmountOfFuelInput = getAmountOfEnergySourceFromUser();
            try
            {
                m_GarageShop.RefuelVehicle(licenseNumber, TypeOfFuelInput, AmountOfFuelInput);
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch(ValueOutOfRangeException voore)
            {
                throw voore;
            }

            Console.Clear();
            Console.WriteLine("Vehicle refuled seccessfully");
        }
                            
        private void        rechargeVehicle()
        {
            string message = "Please enter the license number vehicle: ";
            string licenseNumber = getInputFromUser(message);

            if (!m_GarageShop.CheckIfVehicleInGarage(licenseNumber))
            {
                throw new Exception("Vehicle not found");
            }

            Console.WriteLine("Enter amount of driving minutes to fill: ");
            float amountOfChargingMinutesInput = getAmountOfEnergySourceFromUser();

            try
            {
                m_GarageShop.RechargeVehicle(licenseNumber, amountOfChargingMinutesInput);
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            
            Console.Clear();
            Console.WriteLine("Vehicle recharged seccessfully");
        }
                            
        private void        presentAllVehicleDataExe()
        {
            if (m_GarageShop.GarageIsEmpty())
            {
                throw new Exception("The garage is empty from vehicles");
            }
            else
            {
                string message = "Please enter the license number vehicle: ";
                string licenseNumber = getInputFromUser(message);
                Console.Clear();

                if (!m_GarageShop.CheckIfVehicleInGarage(licenseNumber))
                {
                    throw new Exception("The vehicle was not found");
                }

                Console.WriteLine(m_GarageShop.GetVehicleRecordData(licenseNumber));
            }
        }

        private float       getAmountOfEnergySourceFromUser()
        {
            float AmountOfFuel = 0, parsedInput;
            string input;
            bool isValid = false;

            while (!isValid)
            {
                input = Console.ReadLine();

                try
                {
                    parsedInput = int.Parse(input);
                    if (parsedInput > 0)
                    {
                        AmountOfFuel = parsedInput;
                        isValid = true;
                    }

                    if (!isValid)
                    {
                        Console.WriteLine("Wrong input, try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a numerical value");
                }
            }

            return AmountOfFuel;
        }

        private T           getEnumValueFromUser<T>(T i_defaultValue) where T : Enum
        {
            T enumValueFromUser = i_defaultValue;
            bool isValid = false;
            StringBuilder output = new StringBuilder();
            string input = null;
            int counter = 1;

            foreach (string nameValue in Enum.GetNames(typeof(T)))
            {
                output.AppendFormat("For {0} press {1}\n", nameValue, counter);
                counter++;
            }

            Console.WriteLine(output);

            while (!isValid)
            {
                input = Console.ReadLine();
                T enumValueInput;
                try
                {
                    enumValueInput = (T)Enum.Parse(typeof(T), input);
                    if (Enum.IsDefined(typeof(T), enumValueInput))
                    {
                        enumValueFromUser = enumValueInput;
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("You chose number out of range, try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Enter a number in the range");
                }
            }

            return enumValueFromUser;
        }

        private eGarageMenu getActionFromUser()
        {
            eGarageMenu chosenKey = eGarageMenu.Exit;
            bool validKey = false;

            while (!validKey)
            {
                Console.WriteLine("(1) Insert New Vehicle");
                Console.WriteLine("(2) Print All Vehicles");
                Console.WriteLine("(3) Change Vehicle State");
                Console.WriteLine("(4) Inflate Vehicle Wheels To Max");
                Console.WriteLine("(5) Fuel Vehicle");
                Console.WriteLine("(6) Charge Vehicle");
                Console.WriteLine("(7) Print Full Vehicle Details");
                Console.WriteLine("(8) Exit");

                string strInput = Console.ReadLine();
                Console.Clear();

                try
                {
                    eGarageMenu input = (eGarageMenu)Enum.Parse(typeof(eGarageMenu), strInput);

                    if (Enum.IsDefined(typeof(eGarageMenu), input))
                    {
                        chosenKey = input;
                        validKey = true;
                    }

                    if (!validKey)
                    {
                        Console.WriteLine("Wrong choise, choose between 1-8");
                    }
                }
                catch
                {
                    throw new Exception("Input menu was not valid.");
                    continue;
                }
            }

            return chosenKey;
        }

        private float       getCurrVehiclesDetailsFromUser(float i_MaxAirPressure, string i_Message)
        {
            bool isValid = false;
            string input = null;
            float CurrAirPressure = 0;

            Console.WriteLine(i_Message);

            while (!isValid)
            {
                input = Console.ReadLine();

                if (float.TryParse(input, out CurrAirPressure) && CurrAirPressure >= 0 && CurrAirPressure <= i_MaxAirPressure)
                {
                    isValid = true;
                }
                else
                {
                    throw new ValueOutOfRangeException(1, i_MaxAirPressure);
                }
            }

            return CurrAirPressure;
        }
        
        private string      getInputFromUser(string i_message)
        {
            string licenseNumberInput = null;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine(i_message);
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    licenseNumberInput = input;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again");
                }
            }

            return licenseNumberInput;
        }

        private bool        ifUsingFilter()
        {
            bool ifChoseFilter = false;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Using a filter? Y/N");
                string input = Console.ReadLine();

                if (input == "Y" || input == "y")
                {
                    ifChoseFilter = true;
                    isValid = true;
                }
                else if (input == "N" || input == "n")
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Wrong input' try again");
                    Console.Clear();
                }
            }

            return ifChoseFilter;
        }
    }
}
