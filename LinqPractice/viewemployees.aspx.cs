using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LinqPractice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cache["table"] = -1;
                updateEmpTbl();
            }
        }

        protected void orderByDept(object sender, EventArgs e)
        {
            Cache["table"] = 0;
            updateEmpTbl();
        }

        protected void toUpper(object sender, EventArgs e)
        {
            Cache["table"] = 1;
            updateEmpTbl();
        }

        protected void highestSalary(object sender, EventArgs e)
        {
            Cache["table"] = 2;
            updateEmpTbl();
        }

        protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            updateEmpTbl();
            employeetbl.PageIndex = e.NewPageIndex;
            employeetbl.DataBind();
        }

        private void updateEmpTbl()
        {
            int v = (int)Cache["table"];
            Feb1AssignmentEntities fae = new Feb1AssignmentEntities();
            if (v == -1)
            {
                employeetbl.DataSource = fae.spGetAllEmps(-1).ToList();
            }
            else
            {
                try
                {
                    //sort by dept
                    if (v == 0)
                    {
                        employeetbl.DataSource = (from Emp in fae.Employees
                                                  join Dep in fae.Departments on Emp.DeptId equals Dep.DeptID
                                                  orderby Dep.DeptName ascending
                                                  select new { EmployeeName = Emp.EmpName, Salary = Emp.EmpSalary, Department = Dep.DeptName }).ToList();
                    }
                    //toupper
                    else if (v == 1)
                    {
                        employeetbl.DataSource = (from Emp in fae.Employees
                                                  join Dep in fae.Departments on Emp.DeptId equals Dep.DeptID
                                                  select new { EmployeeName = Emp.EmpName.ToUpper(), Salary = Emp.EmpSalary, Department = Dep.DeptName }).ToList();
                    }
                    else
                    {
                        var maxSalary = (from Emp in fae.Employees
                                         select Emp).Max(x => x.EmpSalary);
                        employeetbl.DataSource = (from Emp in fae.Employees
                                                  select Emp).Where(x => x.EmpSalary == maxSalary).ToList();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
                }
            }
            employeetbl.DataBind();
        }

        protected void addNewItems(object sender, EventArgs e)
        {
            Feb1AssignmentEntities fae = new Feb1AssignmentEntities();
            Department dep = new Department();
            dep.DeptName = RandomString(50);
            fae.Departments.Add(dep);
            Employee emp1 = new Employee(), emp2 = new Employee();
            emp1.DeptId = fae.Departments.ToList()[fae.Departments.Count()-1].DeptID;
            emp2.DeptId = fae.Departments.ToList()[fae.Departments.Count() - 1].DeptID;
            emp1.EmpName = RandomString(50);
            emp2.EmpName = RandomString(50);
            emp1.EmpSalary = random.Next(200000);
            emp2.EmpSalary = random.Next(200000);
            fae.Employees.Add(emp1);
            fae.Employees.Add(emp2);
            fae.SaveChanges();
            updateEmpTbl();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}