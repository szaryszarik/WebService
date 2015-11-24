﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models
{
    interface IEmployeeRepository
    {
        Task<List<EmployersDetailsDto>> GetEmployers();
        Task GetEmployers(int id);
        Task PostEmployee(string name, string lastName);
        Task DeleteEmployee(int id);
    }
}