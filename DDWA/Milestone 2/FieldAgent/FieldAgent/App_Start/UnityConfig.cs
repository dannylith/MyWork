using ADO_Repository.ADO;
using ADO_Repository.Dapper;
using FieldAgent.Data;
using FieldAgent.Domain.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FieldAgent
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFieldAgentRepository, DapperAgentRepository>();
            container.RegisterType<IAssignmentRepository, ADOAssignmentRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}