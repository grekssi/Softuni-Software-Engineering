using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;
using P03_BarraksWars.Attributes;

namespace P03_BarraksWars.Core.Factories
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IUnitFactory unitFactory;
        private readonly IRepository repository;

        public CommandInterpreter(IUnitFactory unitFactory, IRepository repository)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var type = Type.GetType($"P03_BarraksWars.Core.CreateCommands.{commandName}Command", true);
            var result = (IExecutable)Activator.CreateInstance(type, new object[]{ data });
            this.InjectDependencies(result);
            return result;
        }

        public void InjectDependencies(IExecutable command)
        {
            var defaultAttributeType = typeof(Inject);

            var fieldsForInjection = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.GetCustomAttributes().Any(z => z.GetType() == defaultAttributeType));

            var fieldsToInject = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldInfo in fieldsForInjection)
            {
                fieldInfo.SetValue(command, fieldsToInject.First(x => x.FieldType == fieldInfo.FieldType).GetValue(this));
            }
        }
    }
}
