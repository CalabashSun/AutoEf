using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calabash.AutoEf.Core.Infrastructure.DependencyManagement;

namespace Calabash.AutoEf.Core.Infrastructure
{
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }
        /// <summary>
        /// 初始化组件的环境
        /// </summary>
        void Initialize();

        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);
        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}
