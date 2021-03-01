using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.CrossCuttingConcerns.Validation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entitites = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entitites)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
