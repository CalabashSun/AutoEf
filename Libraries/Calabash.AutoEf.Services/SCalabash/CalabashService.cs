using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calabash.AutoEf.Core.Caching;
using Calabash.AutoEf.Core.Data;

namespace Calabash.AutoEf.Services.SCalabash
{
    public class CalabashService : ICalabashService
    {
        #region

        private const string Calabash_All_key = "cala.calabash.all";

        #endregion

        #region

        private readonly IRepository<Core.Domain.Calabash> _calabashRepository;
        private readonly ICacheManager _cacheManager;

        #endregion

        #region

        public CalabashService(IRepository<Core.Domain.Calabash> calabashRepository,ICacheManager cacheManager)
        {
            _calabashRepository = calabashRepository;
            _cacheManager = cacheManager;
        }

        #endregion
        public string CalabashName()
        {

            return _calabashRepository.Table.First().Name + "love" + _calabashRepository.Table.First().Grilfriend;
        }

        public IList<Core.Domain.Calabash> GetAll()
        {
            //cache
            var key = string.Format(Calabash_All_key);
            
            return _cacheManager.Get(key, () =>
            {
                var query = _calabashRepository.Table.ToList();
                return query;
            });
        }
    }
}
