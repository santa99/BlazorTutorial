﻿using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages;

public class EmployeeListBase : ComponentBase
{
    public string Text { get; set; } = "";
    public string Colour { get; set; } = "background-color:red";
    
    public IEnumerable<Employee>? Employees { get; set; }

    public bool ShowFooter { get; set; }

    protected int SelectedEmployeesCount { get; set; } = 0;
    
    [Inject]
    public IEmployeeService EmployeeService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Run(LoadEmployees);
        
        Employees = (await EmployeeService.GetEmployees()).ToList();
    }

    protected void EmployeeSelectionChanged(bool isSelected)
    {
        if (isSelected)
        {
            SelectedEmployeesCount++;
        }
        else
        {
            SelectedEmployeesCount--;
        }
    }
    
    protected async Task EmployeeDeleted()
    {
        Employees = (await EmployeeService.GetEmployees()).ToList();
    }

    private void LoadEmployees()
    {
        // System.Threading.Thread.Sleep(2000);

        // var ItDepartment = new Department { DepartmentId = 1, DepartmentName = "IT" };
        // var HrDepartment = new Department { DepartmentId = 2, DepartmentName = "HR" };
        // var PayrollDepartment = new Department { DepartmentId = 3, DepartmentName = "Payroll" };
        //
        // Employee e1 = new Employee
        // {
        //     EmployeeId = 1,
        //     FirstName = "John",
        //     LastName = "Hastings",
        //     Email = "David@pragimtech.com",
        //     DateOfBrith = new DateTime(1980, 10, 5),
        //     Gender = Gender.Male,
        //     DepartmentId = ItDepartment.DepartmentId,
        //     PhotoPath = "images/john.png"
        // };
        //
        // Employee e2 = new Employee
        // {
        //     EmployeeId = 2,
        //     FirstName = "Sam",
        //     LastName = "Galloway",
        //     Email = "Sam@pragimtech.com",
        //     DateOfBrith = new DateTime(1981, 12, 22),
        //     Gender = Gender.Male,
        //     DepartmentId = HrDepartment.DepartmentId,
        //     PhotoPath = "images/sam.jpg"
        // };
        //
        // Employee e3 = new Employee
        // {
        //     EmployeeId = 3,
        //     FirstName = "Mary",
        //     LastName = "Smith",
        //     Email = "mary@pragimtech.com",
        //     DateOfBrith = new DateTime(1979, 11, 11),
        //     Gender = Gender.Female,
        //     DepartmentId = ItDepartment.DepartmentId,
        //     PhotoPath = "images/mary.png"
        // };
        //
        // Employee e4 = new Employee
        // {
        //     EmployeeId = 3,
        //     FirstName = "Sara",
        //     LastName = "Longway",
        //     Email = "sara@pragimtech.com",
        //     DateOfBrith = new DateTime(1982, 9, 23),
        //     Gender = Gender.Female,
        //     DepartmentId = PayrollDepartment.DepartmentId,
        //     PhotoPath = "images/sara.png"
        // };
        //
        // Employees = new List<Employee> { e1, e2, e3, e4 };
    }
}