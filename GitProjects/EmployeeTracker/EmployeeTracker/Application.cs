using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeTracker
{
    public class Application
    {
        private List<Employee> _employees;
        private string _employeeInfo = "../../../EmployeeRecords_Fulltime.txt";


        public Application()
        {
            _employees = LoadData();
            //display header
            

            //create list for menu options
            List<string> menu = new List<string> { "Add Employee","Remove Employee","Display Payroll","Exit"};

            //create loop to run until user selects exit
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                UI.Header("Employee Tracker");
                Menu mainMenu = new Menu(menu);
                mainMenu.DisplayMenu();
                UI.Separater();
                Console.Write("Please enter your menu selection: ");
                string menuSel = Console.ReadLine();

                //validate
                menuSel = Validation.ValidateString(menuSel);

                //call menuSel method
                runMenu = MenuSelection(menu, menuSel, runMenu);
            }
            
        }

        private bool MenuSelection(List<string> list, string input, bool runMenu)
        {
            /*int inputNum;
            if(!int.TryParse(input,out inputNum))
            {
                input = Validation.ValidateInList(list, input);
                if(input.ToLower() == "add employee")
                {
                    //add employee

                } else if(input.ToLower() == "remove employee")
                {
                    //remove employee

                } else if(input.ToLower() == "display payroll")
                {
                    //display payroll

                } else if(input.ToLower() == "exit")
                {
                    UI.Separater();
                    UI.Footer("Thanks for using Employee Tracker! Goodbye!");
                    runMenu = false;
                }
            } else
            { } */
                int inputNum = Validation.ValidateRange(Validation.ValidateInt(input), 1, 5);

                switch (inputNum)
                {
                    case 1:
                    //add employee
                    _employees = AddEmployee(_employees);
                        break;
                    case 2:
                    //remove employee
                    RemoveData(_employees);
                        break;
                    case 3:
                    //display payroll
                    DisplayEmployees();
                        break;
                    case 4:
                        UI.Separater();
                        UI.Footer("Thanks for using Employee Tracker! Goodbye!");
                        runMenu = false;
                        break;
                    default:
                        break;
                }
            

            return runMenu;
        }//end menu select method

        //Create method to load data from file
        private List<Employee> LoadData()
        {

            List<Employee> employees = new List<Employee>();
            string line;
            if (File.Exists(_employeeInfo))
            {
                using (StreamReader streamReader = new StreamReader(_employeeInfo))
                {
                    string[] lineArr;

                    //create loop to load information
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineArr = line.Split('|');
                        FullTime fullTime = new FullTime(lineArr[0], lineArr[1], decimal.Parse(lineArr[3]));
                        employees.Add(fullTime);
                    }
                }
            } else
            {
                File.Create(_employeeInfo);
                using (StreamReader streamReader = new StreamReader(_employeeInfo))
                {
                    string[] lineArr;

                    //create loop to load information
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineArr = line.Split('|');
                        FullTime fullTime = new FullTime(lineArr[0], lineArr[1], decimal.Parse(lineArr[3]));
                        employees.Add(fullTime);
                    }
                }
            }

            return employees;

        }//end load data method

        //Create method to add to file
        private void AddData(string name, string address, decimal hoursWorked, decimal wage)
        {
            using (StreamWriter streamWriter = File.AppendText(_employeeInfo))
            {
                name = name.ToUpper();
                address = address.ToUpper();
                streamWriter.WriteLine($"{name}|{address}|{hoursWorked}|{wage}");

            }
        }//end of add to file

        //create method to remove from file
        private void RemoveData(List<Employee> employees)
        {
            Console.Clear();
            UI.Header("Remove Employee");
            bool keepDeleting = true;
            while (keepDeleting)
            {
                foreach(Employee employee in employees)
                {
                    if (employee is Hourly)
                    {
                        Console.WriteLine($"{((Hourly)employee).Name,10} {((Hourly)employee).Address,10} {((Hourly)employee).AnnualWage,10}");
                    }
                    else if (employee is Salaried)
                    {
                        Console.WriteLine($"{((Salaried)employee).Name,10} {((Salaried)employee).Address,10} {((Salaried)employee).AnnualWage,10}");
                    }
                }
                Console.WriteLine("Type in the mame you would like to remove:");
                string name = Console.ReadLine();
                name = Validation.ValidateString(name);
                string[] fileArr = File.ReadAllLines(_employeeInfo);
                File.WriteAllText(_employeeInfo, String.Empty);
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] is Hourly && ((Hourly)employees[i]).Name == name.ToUpper())
                    {
                        employees.RemoveAt(i);
                        Console.WriteLine($"Employee: {name} has been removed!");

                    }
                    else if (employees[i] is Salaried && ((Salaried)employees[i]).Name == name.ToUpper())
                    {
                        employees.RemoveAt(i);
                        Console.WriteLine($"Employee: {name} has been removed!");
                    }
                }
                using (StreamWriter writer = new StreamWriter(_employeeInfo))
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        if (employees[i] is Hourly)
                        {
                           
                            writer.WriteLine($"{((Hourly)employees[i]).Name.ToUpper()}||{((Hourly)employees[i]).Address}|{((Hourly)employees[i]).AnnualWage}");
                        }
                    }
                }
                UI.Separater();
                Console.WriteLine("[1] Remove Another Employee");
                Console.WriteLine("[2] Return to Main Menu");
                string nextSel = Console.ReadLine();
                int selNum = Validation.ValidateRange(Validation.ValidateInt(nextSel), 1, 3);
                if(selNum == 2)
                {
                    UI.Footer("Returning to Main Menu");
                    keepDeleting = false;
                }

            }


        }//end of remove data method

        //create add employee method
        private List<Employee> AddEmployee(List<Employee> employees)
        {
            Console.Clear();
            UI.Header("Add Employee");
            List<string> addMenu = new List<string> { "Full Time", "Part Time", "Salaried", "Manager","Main Menu" };
            List<string> contMenu = new List<string> { "Add Employee", "Return to Main Menu" };
            Menu continMenu = new Menu(contMenu);
            
            bool addEmployee = true;
            while (addEmployee)
            {
                
                Menu add = new Menu(addMenu);
                add.DisplayMenu();
                Console.Write("Please enter selection: ");
                string inputString = Console.ReadLine();
                int inputNum = Validation.ValidateRange(Validation.ValidateInt(inputString), 1, 5);
                switch (inputNum)
                {
                    case 1:
                        //employee name
                        Console.Write("Name: ");
                        string employeeName = Console.ReadLine();
                        employeeName = Validation.ValidateString(employeeName);

                        //employee address
                        Console.Write("Address: ");
                        string employeeAddress = Console.ReadLine();
                        employeeAddress = Validation.ValidateString(employeeAddress);

                        //employee pay per hour
                        Console.Write("Hourly Wage: ");
                        string hourlyWageString = Console.ReadLine();
                        decimal hourlyWage = Validation.ValidateDec(hourlyWageString);

                        FullTime fullTimeEmp = new FullTime(employeeName, employeeAddress, hourlyWage);
                        employees.Add(fullTimeEmp);
                        AddData(employeeName, employeeAddress, 40, hourlyWage);
                        Console.WriteLine($"{employeeName} has been added!");

                        break;
                    case 2:
                        //employee name
                        Console.Write("Name: ");
                        employeeName = Console.ReadLine();
                        employeeName = Validation.ValidateString(employeeName);

                        //employee address
                        Console.Write("Address: ");
                        employeeAddress = Console.ReadLine();
                        employeeAddress = Validation.ValidateString(employeeAddress);

                        //employee pay per hour
                        Console.Write("Hourly Wage: ");
                        hourlyWageString = Console.ReadLine();
                        hourlyWage = Validation.ValidateDec(hourlyWageString);

                        //employee hours per week
                        Console.Write("Hours Per Week: ");
                        string hoursString = Console.ReadLine();
                        decimal hours = Validation.ValidateDec(hoursString);

                        PartTime partTimeEmp = new PartTime(employeeName, employeeAddress, hourlyWage, hours);
                        employees.Add(partTimeEmp);
                        AddData(employeeName, employeeAddress, hours, hourlyWage);
                        Console.WriteLine($"{employeeName} has been added!");
                        break;
                    case 3:
                        //employee name
                        Console.Write("Name: ");
                        employeeName = Console.ReadLine();
                        employeeName = Validation.ValidateString(employeeName);

                        //employee address
                        Console.Write("Address: ");
                        employeeAddress = Console.ReadLine();
                        employeeAddress = Validation.ValidateString(employeeAddress);

                        //employee pay per hour
                        Console.Write("Annual Wage: ");
                        string annualWageString = Console.ReadLine();
                        decimal annualWage = Validation.ValidateDec(annualWageString);

                        Salaried salariedEmp = new Salaried(employeeName, employeeAddress, annualWage);
                        employees.Add(salariedEmp);
                        AddData(employeeName, employeeAddress, 0, annualWage);
                        Console.WriteLine($"{employeeName} has been added!");
                        break;
                    case 4:
                        //employee name
                        Console.Write("Name: ");
                        employeeName = Console.ReadLine();
                        employeeName = Validation.ValidateString(employeeName);

                        //employee address
                        Console.Write("Address: ");
                        employeeAddress = Console.ReadLine();
                        employeeAddress = Validation.ValidateString(employeeAddress);

                        //employee pay per hour
                        Console.Write("Annual Wage: ");
                        annualWageString = Console.ReadLine();
                        annualWage = Validation.ValidateDec(annualWageString);

                        Manager managerEmp = new Manager(employeeName, employeeAddress, annualWage);
                        employees.Add(managerEmp);
                        AddData(employeeName, employeeAddress, 0, annualWage);
                        Console.WriteLine($"{employeeName} has been added!");
                        break;
                    default:
                        addEmployee = false;
                        break;
                }
                Console.Clear();
                continMenu.DisplayMenu();
                Console.Write("Enter your selection: ");
                string selString = Console.ReadLine();
                int selNum = Validation.ValidateRange(Validation.ValidateInt(selString), 1, 3);
                if(selNum == 2)
                {
                    UI.Footer("Returning to Main Menu");
                    addEmployee = false;
                }
            }
            return employees;

        }//end add employee method

        private void RemoveEmployee()
        {

        }//end remove employee method

        private void DisplayEmployees()
        {
            UI.Header("Employees");
            foreach(Employee employee in _employees)
            {
                if (employee is Hourly)
                {
                    Console.WriteLine($"{((Hourly)employee).Name, 10} {((Hourly)employee).Address,10} {((Hourly)employee).AnnualWage,10}");
                    UI.EmpUI();
                } else if(employee is Salaried)
                {
                    Console.WriteLine($"{((Salaried)employee).Name,10} {((Salaried)employee).Address,10} {((Salaried)employee).AnnualWage,10}");
                    UI.EmpUI();
                }
            }
            UI.Footer("Press any key to continue");
            Console.ReadLine();
        }//end display employee method


    }
}
