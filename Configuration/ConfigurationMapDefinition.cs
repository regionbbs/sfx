using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Framework.Configuration
{
    public class ConfigurationMapDefinition<TConfigConsumer, TConfigProvider>
        where TConfigConsumer: class
        where TConfigProvider: ConfigurationElement
    {
        public PropertyInfo SourceProperty { get; private set; } // provider property
        public PropertyInfo TargetProperty { get; private set; } // consumer property
        public bool IsRequired { get; private set; }
        public object DefaultValue { get; private set; }

        internal ConfigurationMapDefinition(PropertyInfo TargetProperty)
        {
            this.TargetProperty = TargetProperty;
        }
        
        public ConfigurationMapDefinition<TConfigConsumer, TConfigProvider> Required()
        {
            this.IsRequired = true;
            return this;
        }

        public ConfigurationMapDefinition<TConfigConsumer, TConfigProvider> Default(object Value)
        {
            this.DefaultValue = Value;
            return this;
        }

        public ConfigurationMapDefinition<TConfigConsumer, TConfigProvider> Map(Expression<Func<TConfigProvider, object>> SourcePropertyExpression)
        {
            var sourceProperty = 
                ExpressionUtil.GetMapPropertyName<TConfigProvider>(SourcePropertyExpression);

            if (string.IsNullOrEmpty(sourceProperty))
                throw new ArgumentNullException("ERROR_MAP_TARGET_NOT_FOUND");

            var propQuery = typeof(TConfigProvider).GetProperties().Where(c => c.Name == sourceProperty);

            if (!propQuery.Any())
                throw new ArgumentNullException("ERROR_MAP_TARGET_NOT_FOUND");

            this.SourceProperty = propQuery.First();

            return this;
        }
    }
}
