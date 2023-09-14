﻿using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<Guid>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}