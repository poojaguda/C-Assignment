using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseDemo.practical
{
    class LinqToSql
    {
        static void Main(string[] args)
        {
            displayMenu();
        }
        public static void displayMenu()
        {
            do
            {
                string menu ="PRESS 1 TO ADDEMPLOYEE\nPRESS 2 TO DELETEEMPLOYEE\nPRESS 3 TO UPDATEEMPLOYEE\nPRESS 4 TO GETALLEMPLOYEE\nPRESS 5 to READING RECORDS";
                Console.WriteLine(menu);
                int choice = utilities.GetNumber("enter your choice");
                switch(choice)
                {
                    case 1:
                       
                        Insert();
                        break;
                    case 2:
                        int id = utilities.GetNumber("enter the employee id to delete");
                        deleteRecord(id);
                        break;
                    case 3:
                        int updateid = utilities.GetNumber("enter the employee id to update");
                        updateRecord(updateid);
                        break;
                    case 4:
                        GetAllEmployess();
                        break;
                    case 5:
                        readingRecords();
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (true);
        }
        public static void Insert()
        {
            var rec = new employees9
            {
                id =utilities.GetNumber("Enter the employee id"),
                name = utilities.Prompt("Enter the employee name"),
                address = utilities.Prompt("Enter the employee address"),
                salary = utilities.GetNumber("enter the salary" ),
                deptId = utilities.GetNumber("enter the dept id"),

            };
            addRecord(rec);
        }
               
        private static void addRecord(employees9 rec)
        {
            var context = new DataClasses1DataContext();
            context.employees9s.InsertOnSubmit(rec);
            context.SubmitChanges();
        }
        private static void readingRecords()
        {
            var context = new DataClasses1DataContext();
            var emplist = from emp in context.employees9s
                          select emp;
            foreach (var item in emplist)
            {
                Console.WriteLine($"{item.id} EMPLOYEE: {item.name} from {item.address} having salary {item.salary} working in the department {item.deptId} ");
            }
        }
        private static void updateRecord(int id)
        {
            var context = new DataClasses1DataContext();
            var found = context.employees9s.FirstOrDefault((rec) => rec.id == id);
            if (found == null)
            {
                Console.WriteLine("id not found to update");
            }
            else
            {
                found.name = utilities.Prompt("enter name of the employee to update");
                found.address = utilities.Prompt("enter the address of the employee");
                found.salary = utilities.GetNumber("enter the salary of the employee");
                found.deptId = utilities.GetNumber("enter the dept id");
            }
            context.SubmitChanges();

        }
        private static void deleteRecord(int id)
        {
            var context = new DataClasses1DataContext();
            var found = context.employees9s.FirstOrDefault((rec) => rec.id == id);
            if (found == null)
            {
                Console.WriteLine("id not found to delette");
            }
            else
            {
                context.employees9s.DeleteOnSubmit(found);
            }
            context.SubmitChanges();
        }
        private static void GetAllEmployess()
        {
            var context = new DataClasses1DataContext();
            foreach (var item in context.employees9s)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
    
