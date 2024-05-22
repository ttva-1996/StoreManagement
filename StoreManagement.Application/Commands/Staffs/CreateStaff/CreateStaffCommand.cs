using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace StoreManagement.Application.Commands.Staffs.CreateStaff
{
    public class CreateStaffCommand : IRequest<int>
    {
        public string Name { get; set; }

        public CreateStaffCommand(string name)
        {
            Name = name;
        }
    }
}
