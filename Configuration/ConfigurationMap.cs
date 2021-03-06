﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sfx.Framework.Utils;

namespace Sfx.Framework.Configuration
{
    public class ConfigurationMap<TConfigConsumer, TConfigProvider>
        where TConfigConsumer: class
        where TConfigProvider: ConfigurationElement
    {
        public Type Consumer { get; private set; }
        public Type Provider { get; private set; }
        public List<ConfigurationMapDefinition<TConfigConsumer, TConfigProvider>> Maps { get; private set; }
        public Type FromCollectionType { get; private set; }

        public ConfigurationMap()
        {
            this.Consumer = typeof(TConfigConsumer);
            this.Provider = typeof(TConfigProvider);
            this.Maps = new List<ConfigurationMapDefinition<TConfigConsumer, TConfigProvider>>();
        }

        public ConfigurationMapDefinition<TConfigConsumer, TConfigProvider> 
            Property(Expression<Func<TConfigConsumer, object>> TargetPropertyExpression)
        {
            var targetProperty =
                ExpressionUtil.GetMapPropertyName<TConfigConsumer>(TargetPropertyExpression);

            if (string.IsNullOrEmpty(targetProperty))
                throw new ArgumentNullException("ERROR_MAP_TARGET_NOT_FOUND");

            var propQuery = typeof(TConfigConsumer).GetProperties().Where(c => c.Name == targetProperty);

            if (!propQuery.Any())
                throw new ArgumentNullException("ERROR_MAP_TARGET_NOT_FOUND");

            var mapDefinition = 
                new ConfigurationMapDefinition<TConfigConsumer,TConfigProvider>(propQuery.First());

            this.Maps.Add(mapDefinition);

            return mapDefinition;
        }

        public TConfigConsumer ExtractValues(TConfigProvider Provider)
        {
            var consumer = Activator.CreateInstance<TConfigConsumer>();

            foreach (var configDef in this.Maps)
            {
                object o = configDef.SourceProperty.GetValue(Provider);

                if (o == null || (o.GetType() == typeof(string) && string.IsNullOrEmpty(o.ToString())))
                {
                    if (configDef.IsRequired)
                    {
                        if (configDef.DefaultValue == null)
                            throw new InvalidOperationException("ERROR_REQUIRED_FIELD_MISS_VALUE");
                        else
                            configDef.TargetProperty.SetValue(consumer, configDef.DefaultValue);
                    }
                }
                else
                {
                    configDef.TargetProperty.SetValue(consumer, o);
                }
            }

            return consumer;
        }

        public ConfigurationMap<TConfigConsumer, TConfigProvider> FromCollection<TConfigProviderCollection>()
        {
            this.FromCollectionType = typeof(TConfigProviderCollection);
            return this;
        }
    }
}
