using System;
using System.Data.Linq;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Ex1
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
        public string EmployeesWhoSigned = " ";
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
            return ("Отдел: " + Department + "\nМинимальный уровень доступа: " + SecurityLevel.ToString() + "\nТребуется подписей: " + NumberOfSigned.ToString() + "\nПодписали: " + EmployeesWhoSigned);
        }
    }


    public class ConnectionWIthDataBase
    {
        public DataContext db;
        public Table<Employee> Employees;
        public Table<Department> Departments;
        public Table<Document> Documents;
        static public Document ChoosenDocument;
        public ConnectionWIthDataBase()
        {
            db = new DataContext("D:\\PredProfMDF\\DataaaaaaaaaAAAAABaaaaaaaaaaaaaaaase.mdf");
            Employees = db.GetTable<Employee>();
            Departments = db.GetTable<Department>();
            Documents = db.GetTable<Document>();
        }
        public struct DocumentNameAndIsSigned
        {
            public string name;
            public bool isFullySigned;
        }

        public struct EmployeeNameAndBirthDay
        {
            public string name;
            public string birthday;
        }
        public List<DocumentNameAndIsSigned> GetAllDocumentsNames() //Возвращает список структур, содержащих имя документа
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
        public String GetChoosenDocumentInfo() //не должно быть ресколько доков с одним именем
        {
            return ChoosenDocument.Name;
        }
        public string GetAllInfoAboutChoosenInfo()
        {
            return ChoosenDocument.ToString();
        }
        public void SetChoosenDocument(int DocumentIndex)
        {
            ++DocumentIndex;
            foreach(Document doc in Documents)
            {
                if (doc.DocumentID == DocumentIndex)
                {
                    ChoosenDocument = doc;
                    if (doc.EmployeesWhoSigned == null || doc.EmployeesWhoSigned == "")
                    {
                        ChoosenDocument.EmployeesWhoSigned = " ";
                    }
                    
                }
            }
        }
        public List<EmployeeNameAndBirthDay> GetAllEmployees() //возвращает список структур, содержащих имя и дату рождения сотрудника, имя которого в данный момент вводится 
        {
            List<EmployeeNameAndBirthDay> result = new List<EmployeeNameAndBirthDay>();
            foreach (Employee emp in Employees)
            {
                    EmployeeNameAndBirthDay d = new EmployeeNameAndBirthDay();
                    d.name = emp.Name;
                    d.birthday = emp.BirthDate;
                    result.Add(d);
            }
            return result;
        }

        public string IsIDValid(string res)
        {
            Employee empoyee = Employees.First();
            string[] ss = res.Split(',');
            string empname = ss[0];
            string empbirthdate = ss[1].Remove(0, 1); 
            foreach (Employee emp in Employees)
            {
                if (emp.Name == empname && emp.BirthDate == empbirthdate)
                {
                    empoyee = emp;
                }
            }
            if (empoyee.Department == "Бухгалетрия")
            {
                empoyee.Department = "1";
            }
            if (empoyee.Department == "Отдел кадров")
            {
                empoyee.Department = "2";
            }
            if (empoyee.Department == "Техподдержка")
            {
                empoyee.Department = "3";
            }
            if (empoyee.Department == "Отдел продаж")
            {
                empoyee.Department = "4";
            }
            string code = InformationFromFleshka.InformationAboutFile(); //сделать так, чтобы данная функция вызывалась после того, как флешка точно вставлена
            if (code == "ObmanSuperPuper" || code == "ObmanSuperPuperPapkiIliFailaNet")
            {
                return "Флеш-карта не прочитана";
            }
            if (ChoosenDocument.EmployeesWhoSigned.Contains(empoyee.Name))
            {
                return "Уже подписал";
            }
            if ((((int.Parse(empoyee.SecurityLevel) >= ChoosenDocument.SecurityLevel) &&( empoyee.Department == ChoosenDocument.Department)) || (int.Parse(empoyee.SecurityLevel) == 5)) && (empoyee.EmployeeID == code))
            {
                return "Сотрудник подтвержден";
            }
            if (ChoosenDocument.EmployeesWhoSigned.Contains(empoyee.Name))
            {
                return "Уже подписал";
            }
            else
            {
                return "Неверный код";
            }
        }

        public void SetSigned(string name) //добавляет тех, кто подписал
        {
            Employee empoyee = Employees.First();
            string[] ss = name.Split(',');
            string empname = ss[0];
            string empbirthdate = ss[1].Remove(0, 1);
            foreach (Employee emp in Employees)
            {
                if (emp.Name == empname && emp.BirthDate == empbirthdate)
                {
                    empoyee = emp;
                }
            }
            foreach (Document doc in Documents)
            {
                if (doc.DocumentID == ChoosenDocument.DocumentID)
                {
                    if (doc.IsFullySigned)
                    {
                        return;
                    }
                    if (ChoosenDocument.EmployeesWhoSigned == " ")
                    {
                        doc.EmployeesWhoSigned += (empoyee.Name + " ");
                    }
                    else
                    {
                        doc.EmployeesWhoSigned += ("," + empoyee.Name + " ");
                    }
                    if (countHowManyEmpSigned(doc.EmployeesWhoSigned) == doc.NumberOfSigned)
                    {
                        doc.IsFullySigned = true;
                    }
                    db.SubmitChanges();
                }
            }
        }
        static int countHowManyEmpSigned(string s)
        {
            int result = 0;
            foreach(int x in s)
            {
                result += (x == ',') ? 1 : 0;
            }
            return ++result;
        }
    }
}