using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calabash.AutoEf.Core.Infrastructure
{
    /// <summary>
    /// 提供获取单例的引擎
    /// </summary>
    public class EngineContext
    {
        #region Methods

        /// <summary>
        /// 初始化静态实例
        /// </summary>
        /// <param name="forceRecreate">创建新的工厂实例</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {
            if (Singleton<IEngine>.Instance == null || forceRecreate)
            {
                Singleton<IEngine>.Instance = new Engine();
                Singleton<IEngine>.Instance.Initialize();
            }
            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// 替换引擎 实现自己的引擎
        /// </summary>
        /// <param name="engine"></param>
        /// <remarks></remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 使用单例模式获取引擎，这样可以不用在构造函数中构造
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}
