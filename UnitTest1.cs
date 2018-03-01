using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.EquivalencyExpression;
using Xunit;

namespace AutoMapperCollectionRepro77
{
    public class AutoMapperCollectionTests
    {
        [Fact]
        public async Task ConfigShouldBeThreadSafe()
        {
            Action act = () =>
            {
                new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.AddCollectionMappers();
                });
            };
            var tasks = new List<Task>();
            for (var i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(act));
            }

            await Task.WhenAll(tasks.ToArray());
        }
    }
}
