using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Infra.Data.Repository.Repositories;
using users.Infra.Data.Repository.IRepositories;
using users.Domain.Services.Service.Services;
using users.Domain.Services.Service.IServices;

namespace users.Infra.CrossCutting.IoC
{
    public class DependencyInjection
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateUserService>().As<ICreateUserService>();
            builder.RegisterType<DeleteUserService>().As<IDeleteUserService>();
            builder.RegisterType<DisableUserService>().As<IDisableUserService>();
            builder.RegisterType<ReadUserService>().As<IReadUserService>();
            builder.RegisterType<UpdateUserService>().As<IUpdateUserService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
