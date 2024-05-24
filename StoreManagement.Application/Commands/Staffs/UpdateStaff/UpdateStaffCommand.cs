using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace StoreManagement.Application.Commands.Staffs.UpdateStaff
{
    public class UpdateStaffCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateStaffCommand(Guid id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
