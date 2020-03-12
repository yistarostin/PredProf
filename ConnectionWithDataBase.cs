using System;
using System.Data.Linq;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
namespace DataBaseThings
{
    [Table(Name = "Departments")]
    public class Department
    {
        [Column(IsPrimaryKey = true)]
        public string DepartureID;
        [Column]
        public string Name;
        static public void ReadFromListOfDepartments(Table<Department> Departments, DataContext db)
        {
            string[] lines = System.IO.File.ReadAllLines("D:\\PredProfMDF\\ListOfDepartments.txt");
            foreach (string line in lines)
            {
                string[] thisline = line.Split('*');
                Department dep = new Department();
                dep.Name = thisline[0];
                dep.DepartureID = thisline[1];
                Departments.InsertOnSubmit(dep);
            }
            db.SubmitChanges();
        }
    }


    [Table(Name = "Employees")]
    public class Employee
    {
        [Column(IsPrimaryKey = true)]
        public string EmployeeID;
        [Column]
        public string Name;
        [Column]
        public string Department;
        [Column]
        public string Position;
        [Column]
        public string SecurityLevel;
        [Column]
        public string BirthDate;
        public Employee()
        { }
        static public void ReadFromListOfEmployess(Table<Employee> Employees, DataContext db) //ONLY 1 TIME
        {
            string[] lines = System.IO.File.ReadAllLines("D:\\PredProfMDF\\ListOfEmployees.txt");
            foreach (string line in lines)
            {
                string[] thisline = line.Split('*');
                Employee emp = new Employee();
                emp.Name = thisline[0];
                emp.BirthDate = thisline[1];
                emp.Position = thisline[2];
                emp.Department = thisline[3];
                emp.SecurityLevel = thisline[4];
                emp.EmployeeID = thisline[5];
                Employees.InsertOnSubmit(emp);
                db.SubmitChanges();
            }
            db.SubmitChanges();
        }
    }


    [Table(Name = "Documents")]
    public class Document
    {
        [Column(IsPrimaryKey = true)]
        public int DocumentID;
        [Column]
        public string Name;
        [Column]
        public string Department;
        [Column]
        public int SecurityLevel;
        [Column]
        public int NumberOfSigned;
        [Column]
        public string EmployeesWhoSigned;
        [Column]
        public bool IsFullySigned;
        static public void ReadFromListOfDocuments(Table<Document> Documents, DataContext db) //ONLY 1 TIME
        {
            string[] lines = System.IO.File.ReadAllLines("D:\\PredProfMDF\\ListOfDocuments.txt");
            foreach (string line in lines)
            {
                string[] thisline = line.Split('*');
                Document doc = new Document();
                doc.DocumentID = int.Parse(thisline[0]);
                doc.Name = thisline[1];
                doc.Department = thisline[2];
                doc.SecurityLevel = int.Parse(thisline[3]);
                doc.NumberOfSigned = int.Parse(thisline[4]);
                Documents.InsertOnSubmit(doc);
                db.SubmitChanges();
            }
            db.SubmitChanges();
        }
        public override string ToString()
        {
            return ("Название: " + Name + "\nОтдел: " + Department + "\nМинимальный уровень доступа: " + SecurityLevel.ToString() + "\nТребуется подписей: " + NumberOfSigned.ToString() + "\nПодписали: " + EmployeesWhoSigned);
        }
    }


    class Sample //для тест, мейн уберем, когда будем соединять с интерфейсом николая, мейн останется только у него
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DataContext db = new DataContext("D:\\PredProfMDF\\db\\DataaaaaaaaaAAAAABaaase.mdf");
            db.DeleteDatabase();
            Table<Employee> Employees = db.GetTable<Employee>();
            Table<Department> Departments = db.GetTable<Department>();
            Table<Document> Documents = db.GetTable<Document>();
            db.CreateDatabase();
            Employee.ReadFromListOfEmployess(Employees, db);
            Department.ReadFromListOfDepartments(Departments, db);
            Document.ReadFromListOfDocuments(Documents, db);
            var q =
             from c in Employees
             select c;
            foreach (var cust in q)
                Console.WriteLine("id = {0}, Name = {1}, Position = {2}, Departure = {3}, SecurityLevel = {4}, BirthDate = {5}", cust.EmployeeID, cust.Name, cust.Position, cust.Department, cust.SecurityLevel, cust.BirthDate);
            var z =
             from c in Departments
             select c;
            foreach (var emp in z)
                Console.WriteLine("id = {0}, Name = {1}", emp.DepartureID, emp.Name);
            var x =
             from c in Documents
             select c;
            foreach (var doc in x)
                Console.WriteLine("id = {0}, Name = {1}, Department = {2}, SecurityLevel = {3}, NumberOfSigned = {4}, isFullySigned = {5}", doc.DocumentID, doc.Name, doc.Department, doc.SecurityLevel, doc.NumberOfSigned, doc.IsFullySigned);
            return;
        }
    }
    static class ConnectionWIthDataBase
    {
        static public DataContext db = new DataContext("D:\\PredProfMDF\\db\\DataaaaaaaaaAAAAABaaase.mdf");
        static public Table<Employee> Employees = db.GetTable<Employee>();
        static public Table<Department> Departments = db.GetTable<Department>();
        static public Table<Document> Documents = db.GetTable<Document>();
        public struct DocumentNameAndIsSigned
        {
            public string name;
            public bool isFullySigned;
        }

        public struct EmployeeNameAndBirthDay
        {
            public string name;
            public string birthday;
            public int ID;
        }
        static public List<DocumentNameAndIsSigned> GetAllDocumentsNames() //Возвращает список структур, содержащих имя документа и буль подписан ли
        {
            List<DocumentNameAndIsSigned> result = new List<DocumentNameAndIsSigned>();
            foreach (Document doc in Documents)
            {
                DocumentNameAndIsSigned d = new DocumentNameAndIsSigned();
                d.name = doc.Name;
                d.isFullySigned = doc.IsFullySigned;
                result.Add(d);
            }
            return result;
        }
        static public String GetInfoAboutDocument(int Documentid)
        {
            foreach (Document doc in Documents)
            {
                if (doc.DocumentID == Documentid)
                    return doc.ToString();
            }
            return null; //impossible
        }

        static public List<EmployeeNameAndBirthDay> GetAllEmployees(string subName) //возвращает список структур, содержащих имя и дату рождения сотрудника, имя которого в данный момент вводится 
        {
            List<EmployeeNameAndBirthDay> result = new List<EmployeeNameAndBirthDay>();
            foreach (Employee emp in Employees)
            {
                if (emp.Name.Contains(subName))
                {
                    EmployeeNameAndBirthDay e = new EmployeeNameAndBirthDay();
                    e.name = emp.Name;
                    e.birthday = emp.BirthDate;
                    e.ID = int.Parse(emp.EmployeeID);
                    result.Add(e);
                }
            }
            return result;
        }

        static public string IsIDValid(int employeeID)
        {
            string code = InformationFromFleshka.InformationAboutFile();
            if (code == "ObmanSuperPuper")
            {
                return "Флеш-карта не прочитана";
            }
            return (int.Parse(code) == employeeID ? "Код корректный" : "Код некорректный");
        }

        static public void SetSigned(int docID, int employeeID) //добавляет тех, кто подписал
        {
            foreach (Document doc in Documents)
            {
                if (doc.DocumentID == docID)
                {
                    foreach (Employee emp in Employees)
                    {
                        if (int.Parse(emp.EmployeeID) == employeeID)
                        {
                            doc.EmployeesWhoSigned += emp.Name + ", ";
                            if (CountHowManyPeopleHaveSigned(doc.Name) == doc.NumberOfSigned)
                                doc.IsFullySigned = true;
                            return;
                        }
                    }
                }
            }
        }
        static private int CountHowManyPeopleHaveSigned(string name)
        {
            int res = 0;
            foreach(char s in name)
            {
                if (s == ',')
                    ++res;
            }
            return res;
        }
    }
}