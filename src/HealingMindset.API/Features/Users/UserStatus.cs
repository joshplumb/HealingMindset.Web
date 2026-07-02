using FluentValidation;
using HealingMindset.Api.Filters;
using HealingMindset.DataAccess.Context;
using HealingMindset.DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace HealingMindset.Api.Features.Users;

private record UserStatusResponse(string UserRole, )
