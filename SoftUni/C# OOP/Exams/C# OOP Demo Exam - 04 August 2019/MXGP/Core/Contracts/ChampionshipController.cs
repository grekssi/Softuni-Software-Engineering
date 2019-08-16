using System;
using System.Linq;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Motorcycles.Models;
using MXGP.Models.Races.Models;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Riders.Models;
using MXGP.Repositories.Models;
using MXGP.Utilities.Messages;

namespace MXGP.Core.Contracts
{
    public class ChampionshipController : IChampionshipController
    {
        MotorcycleRepository motorcycleRepository = new MotorcycleRepository();
        RaceRepository raceRepository = new RaceRepository();
        RiderRepository riderRepository = new RiderRepository();
        public string CreateRider(string riderName)
        {
            if (riderRepository.GetAll().Any(x => x.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            IRider rider = new Rider(riderName);
            riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycleRepository.GetAll().Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle = null;

            switch (type)
            {
                case "Speed":
                    motorcycle = new SpeedMotorcycle(model, horsePower);
                    break;
                case "Power":
                    motorcycle = new PowerMotorcycle(model, horsePower);
                    break;
            }

            motorcycleRepository.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            Race race = new Race(name, laps);
            this.raceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.GetByName(raceName);
            var rider = riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riderRepository.GetByName(riderName);
            var motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, riderName));
            }

            rider.AddMotorcycle(motorcycle);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);

        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetAll().All(x => x.Name != raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var race = raceRepository.GetByName(raceName);
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            int i = 0;
            var sb = new StringBuilder();
            foreach (var rider in race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)))
            {
                if (i == 0)
                {
                    sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, rider.Name, race.Name));
                }

                if (i == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, rider.Name, race.Name));
                }

                if (i == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, rider.Name, race.Name));
                    break;
                }
                Console.WriteLine(rider.Name);
                i++;
            }
            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
