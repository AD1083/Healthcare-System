using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.WorkflowManagement
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>();
        bool IsRegistered<TService>();
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}
