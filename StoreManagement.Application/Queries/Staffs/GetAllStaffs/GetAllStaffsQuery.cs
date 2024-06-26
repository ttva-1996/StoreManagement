﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Queries.Staffs.GetAllStaffs
{
    public class GetAllStaffsQuery : IRequest<IEnumerable<GetAllStaffsQueryResult>>
    {
        public string? SearchText { get; set; }
    }
}
